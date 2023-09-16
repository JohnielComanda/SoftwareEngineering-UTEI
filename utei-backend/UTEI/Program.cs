using UTEI.DatabaseSetting;
using UTEI.GPTManager;
using UTEI.Repository;
using UTEI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IEfficiencyTestRepository, EfficiencyTestRepository>();
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
