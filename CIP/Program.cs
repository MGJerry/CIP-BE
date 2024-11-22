using CIP.Models;
using CIP.Repository;
using CIP.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins(
            "https://localhost:5173",
            "https://14.225.212.43",
            "https://localhost:5174",
            "https://localhost:5175",
            "https://localhost:5275",
            "http://localhost:8080",
            "https://localhost:8081",
            "https://14.225.212.43:3000"
        )
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
    options.AddPolicy("corsapp",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
//builder.Services..UseCors("AllowSpecificOrigins");

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
builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = int.Parse(Environment.GetEnvironmentVariable("ASPNETCORE_HTTPS_PORT") ?? "8081"); // Specify the HTTPS port
});

// Add DbContext before building the app
builder.Services.AddDbContext<CipContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ContractsDB"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseCors("corsapp");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
