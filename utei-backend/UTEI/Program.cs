using AspNetCore.Identity.MongoDbCore.Extensions;
using AspNetCore.Identity.MongoDbCore.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using System.Text;
using UTEI.DatabaseSetting;
using UTEI.GPTManager.AccuracyUnitTest;
using UTEI.GPTManager.EnhanceUnitTest;
using UTEI.GPTManager.GenerateUnitTest;
using UTEI.Models.AuthenticationModel;
using UTEI.Repository.AccuracyUnitTest;
using UTEI.Repository.EnhanceUnitTest;
using UTEI.Repository.GenerateUnitTest;
using UTEI.Service;
using UTEI.Service.AccuracyUnitTest;
using UTEI.Service.EnhanceUnitTest;
using UTEI.Service.GenerateUnitTest;

var builder = WebApplication.CreateBuilder(args);

// Configure services
ConfigureServices(builder);

BsonSerializer.RegisterSerializer(new GuidSerializer(MongoDB.Bson.BsonType.String));
BsonSerializer.RegisterSerializer(new DateTimeSerializer(MongoDB.Bson.BsonType.String));
BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(MongoDB.Bson.BsonType.String));


DotNetEnv.Env.Load();

//add mongoIdentityConfiguration...
var mongoDbIdentityConfig = new MongoDbIdentityConfiguration
{
    MongoDbSettings = new MongoDbSettings
    {
        ConnectionString = Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING"),
        DatabaseName = "UTEI"
    },
    IdentityOptionsAction = options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireLowercase = false;

        //lockout
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
        options.Lockout.MaxFailedAccessAttempts = 5;

        options.User.RequireUniqueEmail = true;
    }
};


builder.Services.ConfigureMongoDbIdentity<ApplicationUser, ApplicationRole, Guid>(mongoDbIdentityConfig)
    .AddUserManager<UserManager<ApplicationUser>>()
    .AddSignInManager<SignInManager<ApplicationUser>>()
    .AddRoleManager<RoleManager<ApplicationRole>>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;


}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = true;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = "http://localhost:3000",
        ValidAudience = "http://localhost:3000",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("ISSUER_SIGNING_KEY")!)),
        ClockSkew = TimeSpan.Zero
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline
ConfigurePipeline(app);

app.Run();


// Service registration method
void ConfigureServices(WebApplicationBuilder builder)
{
    // Register repositories and services
    builder.Services.AddScoped<IGenerateTestRepository, GenerateTestRepository>();
    builder.Services.AddScoped<IGenerateTestService, GenerateTestService>();
    builder.Services.AddScoped<IUnitTestGenerator, UnitTestGenerator>();
    builder.Services.AddScoped<IEfficiencyTestRepository, EfficiencyTestRepository>();
    builder.Services.AddScoped<IAccuracyTestRepository, AccuracyTestRepository>();
    builder.Services.AddScoped<IAccuracyTestService, AccuracyTestService>();
    builder.Services.AddScoped<IAccuracyTest, AccuracyTest>();
    builder.Services.AddScoped<IEfficiencyTestService, EfficiencyTestService>();
    builder.Services.AddScoped<IAnalyzer, Analyzer>();
    builder.Services.AddScoped<IEfficiencyTestEnhancer, EfficiencyTestEnhancer>();
    builder.Services.AddHttpClient();
    builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddAuthorization();
    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });
}

// Configure HTTP request pipeline method
void ConfigurePipeline(WebApplication app)
{
    app.UseSwagger();
    if (app.Environment.IsDevelopment())
    {
        
        app.UseSwaggerUI();
    }

    app.UseCors();
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
}