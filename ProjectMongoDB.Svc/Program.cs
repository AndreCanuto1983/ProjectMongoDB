using ProjectMongoDB.Svc.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.MongoDBSettings();
builder.Services.DependencyInjectionSettings();
builder.Services.ServiceExtensionSettings();

builder.Services.AddHealthChecks();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCustomExceptionMiddleware();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/health");

app.UseAuthorization();

app.MapControllers();

app.Run();
