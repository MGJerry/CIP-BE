using CIP.Models;
using CIP.Repository;
using CIP.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("corsapp",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Register CustomerRepository and CustomerService in the DI container
builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<CustomerService>();

builder.Services.AddScoped<TransactionRepository>();
builder.Services.AddScoped<TransactionService>();

builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductService>();

builder.Services.AddScoped<TransactionDetailRepository>();
builder.Services.AddScoped<TransactionDetailService>();

// Add HTTPS redirection middleware
/*
builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = int.Parse(Environment.GetEnvironmentVariable("ASPNETCORE_HTTPS_PORT") ?? "8081"); // Specify the HTTPS port
});
*/

// Add DbContext before building the app
builder.Services.AddDbContext<CipContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ContractsDB"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("corsapp");
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
