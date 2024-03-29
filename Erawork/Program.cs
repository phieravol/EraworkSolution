using AppModules.Categories.Manage;
using AppModules.Categories.Public;
using AppModules.GeneralModule;
using AppModules.Pakages.Provider;
using AppModules.Posts.Admin;
using AppModules.Posts.Public;
using AppModules.Services.Admin;
using AppModules.Services.Public;
using AppModules.SubCategories.Admin;
using AppModules.SubCategories.Public;
using AppModules.System.Role;
using AppModules.Users.Manage;
using AppModules.Users.Public;
using Data.EntityDbContext;
using Data.Models;
using Erawork.Pages.Shared.Components.PublicCategories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Erawork.Hubs;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<EraWorkContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("EraWorkDb")
    ));

//config for identity
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<EraWorkContext>()
  .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(op =>
{
    op.LoginPath = "/User/Login";
    op.AccessDeniedPath = "/Admin/AccessDenied";
});

//config authentication cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/user/Login";
            options.LogoutPath = "/user/Logout";
            options.AccessDeniedPath = "/user/AccessDenied";
        });

//Config for authen author
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("ProviderOnly", policy => policy.RequireRole("Provider"));
    options.AddPolicy("ClientOnly", policy => policy.RequireRole("Client"));
});


// Add services DIs
builder.Services.AddTransient<IManageCategory, ManageCategory>();
builder.Services.AddTransient<IPublicCategory, PublicCategory>();

builder.Services.AddTransient<IPublicUser, PublicUser>();
builder.Services.AddTransient<IManageAccount, ManageAccount>();

builder.Services.AddTransient<IPublicRole, PublicRole>();

builder.Services.AddTransient<IManageSubcates, ManageSubcates>();
builder.Services.AddTransient<IPublicSubcate, PublicSubcate>();

builder.Services.AddTransient<IManageServices, ManageServices>();
builder.Services.AddTransient<IPublicServices, PublicServices>();

builder.Services.AddTransient<ISaveImage, SaveImage>();

builder.Services.AddTransient<IManagePosts, ManagePosts>();
builder.Services.AddTransient<IPublicPost, PublicPost>();

builder.Services.AddTransient<IManagePakages, ManagePakages>();


builder.Services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
builder.Services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
builder.Services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();

// Add cache service register
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSignalR();

// Add session service
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(60*60*24);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddScoped<CategoriesMenuComponent>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();
app.MapHub<ChatHub>("/chatHub");
app.MapRazorPages();

app.Run();
