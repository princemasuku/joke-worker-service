using learn_worker.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_worker.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<JokeServiceSettingsModel>(configuration.GetSection("JokeSettings"));
            services.AddSingleton<JokeServiceSettingsModel>(sp => sp.GetRequiredService<IOptions<JokeServiceSettingsModel>>().Value);
            return services;
        }
    }
}
