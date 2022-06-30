using Cwiczenia_6.DAL;
using Cwiczenia_6.Persistance;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

var connectionString = builder.Configuration.GetConnectionString("Db");
services.AddDbContext<ClinicDbContext>(x => x.UseSqlServer(connectionString));

using (var context = services.BuildServiceProvider().GetService<ClinicDbContext>())
{
    context.Database.EnsureCreated();
}

services.AddTransient<IClinicServices, ClinicServices>();

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

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
