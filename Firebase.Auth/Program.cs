using Firebase.Auth.Middleware;
using Firebase.Auth.Middleware.Implementation;
using Firebase.Auth.Services.Implementation;
using Firebase.Auth.Services.Interfaces;
using FirebaseAdmin.Messaging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

/***
 *  Dependency Injection
 */

builder.Services.AddSingleton<IFirebaseServices>(sp => new FirebaseServices("firebase_app_settings.json"));
builder.Services.AddTransient<IFirebaseMiddleware,FirebaseMiddleware>();


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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
