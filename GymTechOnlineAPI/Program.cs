using GymTechOnlineAPI.Models;
using GymTechOnlineAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<GymTechOnlineDatabaseSettings>(
    builder.Configuration.GetSection("GymTechOnlineDatabase"));

builder.Services.AddSingleton<PeopleService>();
builder.Services.AddSingleton<ScheduleService>();
builder.Services.AddSingleton<PaymentService>();
builder.Services.AddSingleton<FormatService>();


builder.Services.AddControllers().AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            //builder.WithOrigins("http://localhost:19006").WithHeaders("Access-Control-Allow-Origin");
            builder.WithOrigins("http://localhost:19006").AllowAnyHeader().AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
