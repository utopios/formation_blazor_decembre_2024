using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CorrectionExercice3;
using CorrectionExercice3.Services;
using CorrectionExercice3.Services.Impl;
using CorrectionExercice3.Tools;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// builder.Services.AddScoped<HttpClient>();
// builder.Services.AddScoped<IProductApiService, ProductApiService>();

builder.Services.AddServices();

await builder.Build().RunAsync();