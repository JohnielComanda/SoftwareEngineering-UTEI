using UTEI.DatabaseSetting;
using UTEI.GPTManager.AccuracyUnitTest;
using UTEI.GPTManager.EnhanceUnitTest;
using UTEI.GPTManager.GenerateUnitTest;
using UTEI.Repository.EnhanceUnitTest;
using UTEI.Repository.GenerateUnitTest;
using UTEI.Service;
using UTEI.Service.AccuracyUnitTest;
using UTEI.Service.EnhanceUnitTest;
using UTEI.Service.GenerateUnitTest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IGenerateTestRepository, GenerateTestRepository>();
builder.Services.AddScoped<IGenerateTestService, GenerateTestService>();
builder.Services.AddScoped<IUnitTestGenerator, UnitTestGenerator>();
builder.Services.AddScoped<IEfficiencyTestRepository, EfficiencyTestRepository>();
builder.Services.AddScoped<IAccuracyTestService, AccuracyTestService>();
builder.Services.AddScoped<IAccuracyTest, AccuracyTest>();
builder.Services.AddScoped<IEfficiencyTestService, EfficiencyTestService>();
builder.Services.AddScoped<IAnalyzer, Analyzer>();
builder.Services.AddScoped<IEfficiencyTestEnhancer, EfficiencyTestEnhancer>();
builder.Services.AddHttpClient();
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
