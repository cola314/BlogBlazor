using BlazorStyled;
using BlogBlazor.Data;
using BlogBlazor.Services;
using BlogBlazor.Shared.Styles;
using Fluxor;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazorStyled();

builder.Services.AddFluxor(o =>
{
    o.ScanAssemblies(typeof(Program).Assembly);

    if (builder.Environment.IsDevelopment())
        o.UseReduxDevTools();
});

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseInMemoryDatabase("db");
});

builder.Services.AddSingleton<Palette>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
});

app.Run();
