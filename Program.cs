using Microsoft.EntityFrameworkCore;
using ShopAzure.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>(options =>
{
    options.UseCosmos(
        builder.Configuration.GetValue<string>("Azure:CosmosDb:Uri"),
        builder.Configuration.GetValue<string>("Azure:CosmosDb:Key"),
        builder.Configuration.GetValue<string>("Azure:CosmosDb:DatabaseName"));
});
var app = builder.Build();



app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.Run();
