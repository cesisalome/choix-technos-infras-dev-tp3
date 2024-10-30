using Choix_des_technos_et_infras_de_développement___TP3.Application.UserAccount.Commands;
using Choix_des_technos_et_infras_de_développement___TP3.Application.UserAccount.Queries;
using Choix_des_technos_et_infras_de_développement___TP3.Persistence;
using Microsoft.EntityFrameworkCore;
using MQTTnet.Client;
using MQTTnet;

var builder = WebApplication.CreateBuilder(args);

// Ajouter le contexte de base de données avec SQLite
builder.Services.AddDbContext<TP3Context>(options =>
    options.UseSqlite("Data Source=TP3.db"));

// Add services to the container.
// Ajouter le UserService pour l'injection de dépendance
builder.Services.AddScoped<GetUserAccountsCommand>();
builder.Services.AddScoped<AddUserAccountCommand>();
builder.Services.AddScoped<UpdateUserAccountCommand>();
builder.Services.AddScoped<DeleteUserAccountsCommand>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

var broker = "http://localhost";
var port = 1883;
var clientId = Guid.NewGuid().ToString();

// Create a MQTT client factory
var factory = new MqttFactory();

// Create a MQTT client instance
var mqttClient = factory.CreateMqttClient();

// Create MQTT client options
var options = new MqttClientOptionsBuilder()
    .WithTcpServer(broker, port) // MQTT broker address and port
    .WithClientId(clientId)
    .WithCleanSession()
    .Build();