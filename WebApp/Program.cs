using Application;
using Data;

var builder = WebApplication.CreateBuilder(args);
// http://localhost:5189/swagger/index.html 
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureDataLayer();
builder.Services.ConfigureApplicationLayer();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    SeedData(app);
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
return;

void SeedData(WebApplication webApp)
{
    using var scope = webApp.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    DataSeeder.DataSeeder.SeedData(context);
}