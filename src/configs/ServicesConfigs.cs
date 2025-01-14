using services;

namespace configs;

public static class ServicesConfigs
{
    public static void AddServicesConfigs(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<AuthServices>()
        .AddScoped<PasswordService>();
    }
}