using Blazor.Data;
using Blazor_sqlserver.Components;
using Microsoft.EntityFrameworkCore;
using Blazor.Services;
using Arora.Blazor.StateContainer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDBcontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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