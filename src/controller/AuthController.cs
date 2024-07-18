using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using data;
using dto;
using entities;
using exceptionError;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using services;

namespace controller;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthServices _authService;
    private readonly Data _context;
    private readonly IConfiguration _configuration;
    private readonly PasswordService _passwordService;

    public AuthController(AuthServices authService, Data context, 
    IConfiguration configuration, PasswordService passwordService)
    {
        _authService = authService;
        _context = context;
        _configuration = configuration;
        _passwordService = passwordService;
    }

    [HttpPost("register")]
    public async Task<ActionResult> RegisterUser([FromBody] RegisterDTO model)
    {
        var userByEmail = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

        if (userByEmail != null)
            return Conflict(new ResponseDTO { Status = "Error", Message = "User already exists!" });

        try
        {
            var password = _passwordService.CreatePassword(model.Password);

            UserEntity user = new()
            {
                Id = Guid.NewGuid().ToString(),
                Email = model.Email,
                Password = password,
                DateUpgraded = DateTime.Now,
                DateCreated = DateTime.Now,
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Created("/Register", new ResponseDTO { Status = "Success", Message = "User created successfully" });

        }
        catch (Exception ex)
        {
            return this.InternalServerError(ex);
        }

    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginDTO model)
    {
        var userByEmail = await _authService.GetUserByEmailAsync(_context, model.Email);
        if (userByEmail == null)
            return BadRequest(new ResponseDTO { Status = "Error", Message = "Invalid email or password!" });

        var verifyPassword = _passwordService.VerifyPassword(userByEmail.Password!, model.Password);
        if (verifyPassword == false)
            return BadRequest(new ResponseDTO { Status = "Error", Message = "Invalid email or password!" });

        if (userByEmail != null && verifyPassword == true)
        {

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, userByEmail.Email!),
                new Claim(ClaimTypes.NameIdentifier, userByEmail.Id!),
            };

            var token = _authService.GenerateAcessToken(authClaims, _configuration);


            return Ok(new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            });
        }
        else
        {
            return BadRequest(new ResponseDTO { Status = "Success", Message = "Incorrect email or password" });
        }
    }
}