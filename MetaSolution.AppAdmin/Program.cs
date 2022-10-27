using FluentValidation;
using MetaSolution.IntegrationAPI.Users;
using MetaSolution.ViewModels.Users;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";
        options.AccessDeniedPath = "/User/Forbidden/";
    });

builder.Services.AddControllersWithViews();
builder.Services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IUserService, UserService>();

IMvcBuilder builder1 = builder.Services.AddRazorPages();
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

#if DEBUG
if (environment == Environments.Development)
{
    builder1.AddRazorRuntimeCompilation();
}    
#endif

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.UseEndpoints(endpoints => {
    endpoints.MapControllerRoute("default", "{controller = Home}/{action = Index}/{id?}");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
