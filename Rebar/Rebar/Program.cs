using DAL.DataAccess;
using DAL.Models;


//OrderDataAccess db = new OrderDataAccess();
//ShakeDataAccess shakedb = new ShakeDataAccess();
//await shakedb.CreateShake(new ShakeModel() { Name = "Banana", Description = "Amazing banana shake", PriceL = 5.5, PriceM = 4, PriceS = 3.5});
//await db.CreateOrder(new OrderModel("Reotem Cohen", 5));
using DAL.DataAccess;

AccountDataAccess db = new AccountDataAccess();
db.CreateAccount(new AccountModel() { CustomerName = "Levi"});
var accounts = await db.GetAccounts();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
