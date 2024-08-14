using Microsoft.EntityFrameworkCore;
using Talabat.Repository.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection")));

var app = builder.Build();

//to ask the clr to apply all new migration evey Run
using var scope = app.Services.CreateScope();
var sevices = scope.ServiceProvider;
var _dbContext = sevices.GetRequiredService<StoreContext>();

var loggerFactory = sevices.GetRequiredService<ILoggerFactory>();

try
{
    await _dbContext.Database.MigrateAsync();
    await SeedData.SeedAsync(_dbContext);
}
catch (Exception e)
{
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(e,"an error has been occured during apply the migration");
}


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