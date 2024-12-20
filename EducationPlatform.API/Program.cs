using EducationPlatform.Application.Commands.SubscriptionCommands;
using EducationPlatform.Application.Commands.UserCommands;
using EducationPlatform.Application.Common;
using EducationPlatform.Application.Mappers;
using EducationPlatform.Core.Entities;
using EducationPlatform.Core.Repositories;
using EducationPlatform.Infrastructure.Persistence.Context;
using EducationPlatform.Infrastructure.Persistence.Repositories;
using EducationPlatform.Infrastructure.Services.Implementations;
using EducationPlatform.Infrastructure.Services.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "EducationPlatform.API",
        Version = "v1"
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header usando o esquema Bearer."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });


builder.Services.Configure<FormOptions>(x =>
{
    x.ValueLengthLimit = int.MaxValue;
    x.MultipartBodyLengthLimit = int.MaxValue; // In case of multipart
});

// context
var connectionString = builder.Configuration.GetConnectionString("EducationPlatformDb");
builder.Services.AddDbContext<EducationPlatformDbContext>(options => options.UseSqlServer(connectionString));


//builder.Services.AddDbContext<EducationPlatformDbContext>(options => options.UseInMemoryDatabase("Database"));
//var dbContext = builder.Services.AddDbContext<EducationPlatformDbContext>(options => options.UseInMemoryDatabase("Database")).BuildServiceProvider().GetService<EducationPlatformDbContext>();


//dbContext.Database.EnsureCreated();

//var newUser = new User
//{
//    FullName = "ademar",
//    Document = "19328324084",
//    Email = "ademar@email.com",
//    Password = "1b062911e0beee616a35fa27770513493742c099e1c7314af8f73eaca5c40aea",
//    Phone = "11987655678",
//    BirthDate = DateTime.Now.AddYears(-18),
//    Role = "Administrator"
//};

//dbContext.Users.Add(newUser);
//dbContext.SaveChanges();

// mediatR
builder.Services.AddMediatR(options => options.RegisterServicesFromAssemblyContaining(typeof(CreateUserCommand)));

// autoMapper
builder.Services.AddAutoMapper(typeof(UserMapper));

// fluentValidation
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommand>());

// interfaces
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IVideoLessonRepository, VideoLessonRepository>();
builder.Services.AddScoped<IVideoLessonService, VideoLessonService>();
builder.Services.AddScoped<IUserSubscriptionRepository, UserSubscriptionRepository>();
builder.Services.AddScoped<IModuleRepository, ModuleRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<IUserLessonsCompletedRepository, UserLessonsCompletedRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IPdfService, PdfService>();

var app = builder.Build();

app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
