using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BackEnd.Data;
using BackEnd.Areas.Identity.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BackEnd.Service.Models;
using BackEnd.Service.Services;

var builder = WebApplication.CreateBuilder(args);

# region Connection String
var connectionString = builder.Configuration.GetConnectionString("UGymContextConnection") ?? throw new InvalidOperationException("Connection string 'UGymContextConnection' not found.");

builder.Services.AddDbContext<UGymContext>(options =>
    options.UseSqlServer(connectionString));
#endregion

#region Identity
builder.Services.AddIdentity<UGymUser, IdentityRole> (options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequiredLength = 3;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
    })
    .AddEntityFrameworkStores<UGymContext>()
    .AddDefaultTokenProviders();
#endregion

# region Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
});
#endregion

# region Email Configuration
var emailconfig = builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
builder.Services.AddSingleton(emailconfig);
builder.Services.AddScoped<IEmailService, EmailService>();
#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllers();

app.Run();
