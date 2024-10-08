using Microsoft.EntityFrameworkCore;
using DictionaryAPI.Data;
using DictionaryAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5000");

// Add services to the container.

// Add the DbContext service to connect to SQLite
builder.Services.AddDbContext<DictionaryContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddScoped<DatabaseSeeder>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Use CORS policy
app.UseCors("AllowAllOrigins");

// Seed the database on startup
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    var seeder = services.GetRequiredService<DatabaseSeeder>();

//    // Seed the translations (you can wrap this in try-catch if error handling is needed)
//    seeder.SeedTranslations();
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
