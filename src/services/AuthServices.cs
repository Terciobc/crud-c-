using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using data;
using entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace services;

public class AuthServices 
{
    public JwtSecurityToken GenerateAcessToken(IEnumerable<Claim> claims, IConfiguration _configuration)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]!));

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidAudience"],
            audience: _configuration["JWT:ValidIssuer"],
            claims: claims,
            notBefore: DateTime.Now, // Definir NotBefore como o tempo atual em UTC
            expires: DateTime.Now.AddHours(double.Parse(_configuration["JWT:ExpireHours"]!)),
            signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
        );

        return token;
    }

    public async Task<UserEntity?> GetUserByEmailAsync(Data _context, string Email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == Email);
    }
}