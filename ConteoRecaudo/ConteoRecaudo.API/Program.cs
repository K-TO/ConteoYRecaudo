using ConteoRecaudo.Business;
using ConteoRecaudo.Business.Interface;
using ConteoRecaudo.Data.Context;
using ConteoRecaudo.Data.Interface;
using ConteoRecaudo.Data.Repository;
using ConteoRecaudo.Infraestructure;
using ConteoRecaudo.Infraestructure.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Cors for angular APP
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
{
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));


if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(
            policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins("*");
            });
    });
}

builder.Services.AddControllers();

builder.Services.AddDbContext<ConteoRecaudoContext>(options =>
                options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddHttpContextAccessor()
    .AddAuthorization()
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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

//Repositories
builder.Services.AddScoped(typeof(IRecaudoRepository), typeof(RecaudoRepository));
builder.Services.AddScoped(typeof(IUsuarioRepository), typeof(UsuarioRepository));

//Services
builder.Services.AddScoped<IRecaudoBusiness, RecaudoBusiness>();
builder.Services.AddScoped<IUsuarioBusiness, UsuarioBusiness>();
builder.Services.AddScoped<IJwtUtils, JwtUtils>();

//Automaper
builder.Services.AddAutoMapper(typeof(AutoMapperConfig).Assembly);

string CORSOpenPolicy = "OpenCORSPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(
      name: CORSOpenPolicy,
      builder => {
          builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
      });
});

var app = builder.Build();

app.UseAuthentication();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
    .WithOrigins("http://localhost:4200"));

app.UseCors(CORSOpenPolicy);
app.UseAuthorization();

app.MapControllers();

app.Run();