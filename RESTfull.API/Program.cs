using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<RESTfull.Infrastructure.Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RESTfullAPIContext") ?? throw new InvalidOperationException("Connection string 'RESTfullAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RESTfull.Infrastructure.Context>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddCors(policy => {

    policy.AddPolicy("Policy_Name", builder =>
      builder.WithOrigins("https://localhost:7276/")
        .SetIsOriginAllowedToAllowWildcardSubdomains()
        .AllowAnyOrigin()


 );
});



var app = builder.Build();
app.UseCors("Policy_Name");

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


