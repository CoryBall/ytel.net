using System;
using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;

namespace Ytel.Configuration
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddYtel(this IServiceCollection serviceCollection, Action<YtelConfiguration> configureOptions)
        {
            serviceCollection.Configure(configureOptions);

            serviceCollection.AddHttpClient<YtelService>(client =>
            {
                client.BaseAddress = new Uri("https://api.ytel.com/api/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            return serviceCollection;
        }
    }
}