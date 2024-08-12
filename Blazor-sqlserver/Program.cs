using Task.Broker.Storages;
using Blazor_sqlserver.Components;
using Blazor.Services;
using Arora.Blazor.StateContainer;
using services.Foundation;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(new StorageBroker(builder.Configuration));
builder.Services.AddTransient<StorageBroker>();
builder.Services.AddScoped<ProductServices>()
                .AddScoped<LoginServices>()
                .AddScoped<UserService>()
                .AddStateContainer()
                .AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
    app.UseExceptionHandler("/Error", createScopeForErrors: true).UseHsts();

app.UseHttpsRedirection().UseStaticFiles().UseAntiforgery();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();