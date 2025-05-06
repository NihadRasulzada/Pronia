using Pronia.MVC.Abstractions.Storage;
using Pronia.MVC.Services.Storage;

namespace Pronia.MVC
{
    public static class ServiceRegistration
    {
        public static void AddStorage<T>(this IServiceCollection services) where T : Storage, IStorage
        {
            services.AddScoped<IStorage, T>();
        }
    }
}
