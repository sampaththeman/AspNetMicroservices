using Discount.API.Extentions;
using Discount.API.Respository;
using Microsoft.OpenApi.Models;
using Npgsql.TypeMapping;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.



builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Discount.API", Version = "v1" });
});

builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Build().MigrateDatabase<Program>().Run();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseAuthorization();

app.MapControllers();

app.Run();


