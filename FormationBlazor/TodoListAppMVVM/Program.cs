using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.SignalR.Client;
using TodoListAppMVVM;
using TodoListAppMVVM.Services;
using TodoListAppMVVM.ViewModels;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<TaskViewModel>();
builder.Services.AddSingleton<TaskState>();

builder.Services.AddScoped<HubConnection>(sp =>
{
    return new HubConnectionBuilder().WithUrl("http://localhost:5217/task").Build();
});

await builder.Build().RunAsync();