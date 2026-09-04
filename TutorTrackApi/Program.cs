using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TutorTrackApi.Data;
using TutorTrackApi.Helpers;
using TutorTrackApi.IMappers;
using TutorTrackApi.IRepositories;
using TutorTrackApi.IServices;
using TutorTrackApi.Mapper;
using TutorTrackApi.Models;
using TutorTrackApi.Repositories;
using TutorTrackApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RouteOptions>(options => 
{
    options.LowercaseUrls = true;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularDevPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200", "http://127.0.0.1:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IIncomeRepository, IncomeRepository>();
builder.Services.AddScoped<IIncomeService, IncomeService>();
builder.Services.AddScoped<IIncomeMapper, IncomeMapper>();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentMapper, StudentMapper>();

builder.Services.AddScoped<IIncomeGoalRepository, IncomeGoalRepository>();
builder.Services.AddScoped<IIncomeGoalService, IncomeGoalService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

builder.Services.AddSwaggerGen();

var jwtSection = builder.Configuration.GetSection("Jwt");
var jwtKey = jwtSection["Key"] ?? throw new InvalidOperationException(
    "Jwt:Key non configurata. Impostala con: dotnet user-secrets set \"Jwt:Key\" \"<chiave-segreta>\"");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSection["Issuer"],
            ValidAudience = jwtSection["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AngularDevPolicy");

app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("index.html");

await MigrateDatabaseAsync(app);
await SeedDefaultUserAsync(app);

app.Run();

static async Task MigrateDatabaseAsync(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.MigrateAsync();
}

static async Task SeedDefaultUserAsync(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();

    if (await userRepository.AnyAsync())
    {
        return;
    }

    var username = app.Configuration["Auth:Username"];
    var password = app.Configuration["Auth:Password"];

    if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
    {
        app.Logger.LogWarning(
            "Nessun utente presente e Auth:Username/Auth:Password non configurati: il login non sarà possibile finché non li imposti con dotnet user-secrets.");
        return;
    }

    await userRepository.AddAsync(new User
    {
        Username = username,
        PasswordHash = PasswordHasher.Hash(password)
    });

    await userRepository.SaveChangesAsync();

    app.Logger.LogInformation("Utente iniziale '{Username}' creato.", username);
}