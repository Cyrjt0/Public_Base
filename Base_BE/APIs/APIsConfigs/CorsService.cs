#pragma warning disable

public static class CorsService
{
    public static void AddCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("_myAllowSpecificOrigins", policy =>
            {
                policy.AllowAnyHeader()
                      .AllowAnyMethod()
                      .SetIsOriginAllowed(origin => true)
                      .AllowCredentials();
            });
        });
    }

    public static void UseCors(this IApplicationBuilder app)
    {
        app.UseCors("_myAllowSpecificOrigins");
    }
}
