using FormationBlazor.Components;
using FormationBlazor.Components.Services;
using FormationBlazor.Services;
using Microsoft.AspNetCore.SignalR.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<IGreetingService, GreetingService>();
builder.Services.AddSingleton<SharedService>();

builder.Services.AddScoped<EventAggregator>();

builder.Services.AddScoped<HubConnection>(sp =>
{
    return new HubConnectionBuilder().WithUrl("http://localhost:5217/chathub").Build();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();