namespace Library.CORS
{
    public class CorsConfig
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder
                        .AllowAnyOrigin() // Tillåt anrop från alla ursprung
                        .AllowAnyMethod() // Tillåt alla HTTP-metoder (GET, POST, etc.)
                        .AllowAnyHeader()); // Tillåt alla headers
            });
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowAllOrigins"); // Använd den CORS-policy som skapades ovan
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
