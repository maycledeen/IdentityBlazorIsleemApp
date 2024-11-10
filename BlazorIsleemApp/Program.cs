using Blazored.Toast;
using Blazored.Toast.Services;
using BlazorIsleemApp.Components;
using BlazorIsleemApp.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Radzen;

using ToastService = BlazorIsleemApp.ToastMessage.ToastService;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRadzenQueryStringThemeService();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<ToastService>();
builder.Services.AddRadzenComponents();
builder.Services.AddBlazoredToast();
builder.Services.AddBlazorBootstrap();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.Name = "authCookie";
                options.AccessDeniedPath = ("/accessdenied");
                options.LoginPath = ("/LogIn");
               // options.LogoutPath = new PathString("/SignOut");
               options.Cookie.MaxAge= TimeSpan.FromMicroseconds(30);
            });
builder.Services.AddAuthentication();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddDbContext<PDbContext>(Options =>
{
    var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    Options.UseSqlServer(ConnectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapRazorComponents<BlazorIsleemApp.Components.App>()
    .AddInteractiveServerRenderMode();

app.Run();
