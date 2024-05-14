using Microsoft.EntityFrameworkCore;
using PWIWEBAPI.DataContext;
using PWIWEBAPI.Logger;
using PWIWEBAPI.Services.Gfactiond;
using PWIWEBAPI.Services.Glinkd;
using PWIWEBAPI.Services.User;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
	.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IGlinkd, GlinkdService>();
builder.Services.AddScoped<IGfactiond, GfactiondService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")));
});
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

Loggers.InitLogger();
DatasPw.StartAll();




app.Run();


