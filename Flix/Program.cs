using Application.Authorization;
using Infra;
using Infra.Persistence;

namespace Flix
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost", policy =>
                {
                    policy.WithOrigins("http://127.0.0.1:5500/").SetIsOriginAllowed(isOriginAllowed: _ => true)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("UsuarioExistente",
                    policy => policy.AddRequirements(new UsuarioExistente(false))
                );
            });

            builder.Services.AddControllers();
            builder.Services.AddApplicationServices(builder.Configuration);
            builder.Services.AddInfrastructureServices(builder.Configuration);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();


            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseDeveloperExceptionPage();
            app.UseMigrationsEndPoint();

            // Initialise and seed database
            using var scope = app.Services.CreateScope();
            var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
            await initialiser.InitialiseAsync();

            app.UseHttpsRedirection();

            app.UseCors("AllowLocalhost");
            app.UseAuthorization();




            app.MapControllers();

            app.Run();
        }
    }
}
