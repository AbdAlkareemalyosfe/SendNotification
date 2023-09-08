using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.Extensions.Configuration;
using SendNotification.Api.Rrepository;
using SendNotification.Api.Sitting;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<INotificationRepo,NotificationRepo>();



builder.Services.Configure<SittingNotification>(builder.Configuration.GetSection("Notification"));

// Initialize Firebase Admin SDK

//...
FirebaseApp.Create(new AppOptions()
{    //Add  Path file of  Privat Key
    Credential = GoogleCredential.FromFile("F:\\SendNotification\\SendNotification.Api\\api-map-app-firebase-adminsdk-18lue-206101868b.json"),
   //Add Id Project
    ProjectId = "api-map-app",
});
//...


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();
  


app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(cors => cors
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowAnyOrigin())
             // allow any origin
             ;
app.UseAuthorization();

app.MapControllers();

app.Run();
