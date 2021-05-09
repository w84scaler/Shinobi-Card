using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using server.Data;
using server.Helpers;
using server.Interfaces;
using server.Services;

namespace server.Extensions
{
    public static class AppServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options => {
                options.UseSqlServer(config.GetConnectionString("DefConnection"));
            });
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITokenService, TokenService >();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            //services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            //services.AddScoped<IPhotoService, PhotoService>();
            return services;
        }
    }
}