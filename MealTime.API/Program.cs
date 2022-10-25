using Autofac;
using Autofac.Extensions.DependencyInjection;
using MealTime.API.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder().SetBasePath
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new MealTimeApplicationModule(""));
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/MealTime.API/v1/swagger.json","MealTime.APi v1"));
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoint =>
{
    endpoint.MapControllers();
});

app.Run();
