using BuberDinner.infrastructure;
using BuberDinner.Application;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Ajout des services nécessaires pour les contrôleurs
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

//builder.Services.AddControllers(options=> options.Filters.Add<ErrorHandlerFilterAttribute>());


// Ajout des services pour la documentation Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}
//app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();

app.UseRouting();


// Autorisation et authentification (si nécessaire)
// app.UseAuthentication(); 
// app.UseAuthorization();

// Mappage des endpoints pour les contrôleurs
app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers(); // Cela permet de mapper les routes vers les actions des contrôleurs
});

app.Run();
