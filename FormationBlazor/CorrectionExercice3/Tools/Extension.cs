using CorrectionExercice3.Services;
using CorrectionExercice3.Services.Impl;

namespace CorrectionExercice3.Tools;

public static class Extension
{
    public static void AddServices(this IServiceCollection Services)
    {
        Services.AddScoped<HttpClient>();
        Services.AddScoped<IProductApiService, ProductApiService>();
    }
}