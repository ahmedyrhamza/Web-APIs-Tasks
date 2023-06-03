using TicketSystem.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TicketSystem.BL;

var builder = WebApplication.CreateBuilder(args);

// Default Services
// Add services to the container.

#region DefaultServices
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region Context
var connectionString = builder.Configuration.GetConnectionString("TicketSystem_ConString");
builder.Services.AddDbContext<TicketsContext>(options => options.UseSqlServer(connectionString));
#endregion

#region Repos
builder.Services.AddScoped<ITicketsRepo, TicketRepo>();
builder.Services.AddScoped<IDepartmentsRepo, DepartmentsRepo>();
#endregion

#region Manager
builder.Services.AddScoped<ITicketsManager, TicketsManager>();
builder.Services.AddScoped<IDepartmentsManager, DepartmentsManager>();
#endregion

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
