using InnoClinic.DocumentsAPI.Application.Services;
using InnoClinic.DocumentsAPI.Application.Services.Abstractions;
using InnoClinic.DocumentsAPI.Core.Contracts.Repositories.UserRepositories;
using InnoClinic.DocumentsAPI.Infrastructure.Repository;
using InnoClinic.DocumentsAPI.Middlewares;
using Serilog;

namespace InnoClinic.DocumentsAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
           services.AddCors(options =>
           {
               options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
           });

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IDocumentService, DocumentService>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();
        }

        public static void ConfigureLogger(this ILoggingBuilder logging, IConfiguration configuration)
        {
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
            logging.ClearProviders();
            logging.AddSerilog(logger);
        }

        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
