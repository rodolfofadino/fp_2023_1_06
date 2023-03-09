using fiap.application.Interfaces;
using fiap.application.Services;
using fiap.infrastructure.Clients;
using fiap.infrastructure.Providers;
using fiap.persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace fiap.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfigurationBuilder configuration)
        {
            var connection = "Server=(localdb)\\mssqllocaldb;Database=fiap-musicas;Trusted_Connection=True;MultipleActiveResultSets=true";

            services.AddDbContext<MusicaContext>(o => o.UseSqlServer(connection));

            services.AddTransient<IDateTimeProvider, DateTimeProvider>();
            services.AddTransient<INoticiaService, NoticiaService>();
            services.AddTransient<INoticiaReader, NoticiaGloboRssClient>();
            
        }
    }
}