using EducationPlatform.Application.Commands.UserCommands;
using EducationPlatform.Application.Mappers;
using EducationPlatform.Core.Repositories;
using EducationPlatform.Infrastructure.Persistence.Context;
using EducationPlatform.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// context
builder.Services.AddDbContext<EducationPlatformDbContext>(options => options.UseInMemoryDatabase("EducationPlatformDb"));

// mediatR
builder.Services.AddMediatR(options => options.RegisterServicesFromAssemblyContaining(typeof(CreateUserCommand)));

// autoMapper
builder.Services.AddAutoMapper(typeof(UserMapper));

// interfaces
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

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
