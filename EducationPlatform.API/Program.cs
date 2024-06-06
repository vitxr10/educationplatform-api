using EducationPlatform.Application.Commands.UserCommands;
using EducationPlatform.Application.Mappers;
using EducationPlatform.Core.Repositories;
using EducationPlatform.Infrastructure.Persistence.Context;
using EducationPlatform.Infrastructure.Persistence.Repositories;
using EducationPlatform.Infrastructure.Services.Implementations;
using EducationPlatform.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<FormOptions>(x =>
{
    x.ValueLengthLimit = int.MaxValue;
    x.MultipartBodyLengthLimit = int.MaxValue; // In case of multipart
});

// context
builder.Services.AddDbContext<EducationPlatformDbContext>(options => options.UseInMemoryDatabase("EducationPlatformDb"));

// mediatR
builder.Services.AddMediatR(options => options.RegisterServicesFromAssemblyContaining(typeof(CreateUserCommand)));

// autoMapper
builder.Services.AddAutoMapper(typeof(UserMapper));

// interfaces
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IVideoLessonRepository, VideoLessonRepository>();
builder.Services.AddScoped<IVideoLessonService, VideoLessonService>();
builder.Services.AddScoped<IUserSubscriptionRepository, UserSubscriptionRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

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
