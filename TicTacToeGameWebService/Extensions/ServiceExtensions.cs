using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Contracts;
using Repository;
using GameLogicService;
using LoggerService;
using Microsoft.Extensions.Options;

namespace TicTacToeGameAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(policy =>
            {
                policy.AddPolicy("CorsPolicy", opt => opt
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });
        }

        public static void ConfigureMsSqlContext(this IServiceCollection services, IConfiguration config)
        {
            string? connectionString = config.GetConnectionString("sqlConnection");

            services.AddDbContext<TicTacToeGameContext>(opts => 
                opts.UseSqlServer(connectionString,
                sqlServerOptionsAction: sqlOption =>
                {
                    sqlOption.MigrationsAssembly("TicTacToeGameWebService");
                    sqlOption.EnableRetryOnFailure();
                }
                ));
        }
        public static void ConfigureLogging(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureGameLogicService(this IServiceCollection services)
        {
            services.AddScoped<IGameLogicService, GameLogicService.GameLogicService>();
        }
    }
}
