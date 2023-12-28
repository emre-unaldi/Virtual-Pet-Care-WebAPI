using Autofac;
using Autofac.Extensions.DependencyInjection;
using VirtualPetCareWebAPI.Business.DependencyResolves.Autofac;
using VirtualPetCareWebAPI.Core.DependencyResolves;
using VirtualPetCareWebAPI.Core.Exceptions;
using VirtualPetCareWebAPI.Core.Extensions;
using VirtualPetCareWebAPI.DataAccess.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Resolves
builder.Services.AddDependencyResolvers([ new CoreModule() ]);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));

builder.Services.AddMvc();

// Controllers
builder.Services.AddControllers();

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Exception Middleware
app.UseCustomExceptionMiddleware();

app.MapControllers();

app.UseCors("AllowSpecificOrigin");

app.Run();
