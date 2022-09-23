using Firebase.Auth.Middleware;
using Firebase.Auth.Middleware.Implementation;
using Firebase.Auth.Services.Implementation;
using Firebase.Auth.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/***
 *  Dependency Injection
 */

builder.Services.AddSingleton<IFirebaseServices>(sp => new FirebaseServices("firebase_app_settings.json"));
builder.Services.AddTransient<IFirebaseMiddleware, FirebaseMiddleware>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
