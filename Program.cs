using hostello.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//serviços views e controllers
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option=>
    {
        option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        option.SlidingExpiration = true;
        option.AccessDeniedPath = "/Home/Proibida";
        option.LoginPath = "/Usuario/Login";
        option.LogoutPath = "/Usuario/Logout";
    }
);
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data source=data.db");
}); //adição do serviço do banco de dados

var app = builder.Build();


//pipeline vvv
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapDefaultControllerRoute(); //define a utilização da rota padrão
app.Run();
