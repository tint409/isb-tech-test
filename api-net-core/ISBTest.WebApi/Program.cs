using ISBTest.DAL.Contracts;
using ISBTest.DAL;
using ISBTest.DAL.DataProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ISBTest.DAL.Entities;
using ISBTest.BL;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ISBTestDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ISBTestDbConnection")));

builder.Services.AddAutoMapper(typeof(Program));

AddGenericServices(builder.Services)
    .AddScoped<IUnitOfWork, UnitOfWork>()
    .AddScoped<IPropertyCrudProcessor, PropertyCrudProcessor>();

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

app.UseHttpsRedirection();

app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});

app.UseAuthorization();

app.MapControllers();

app.Run();

static IServiceCollection AddGenericServices(IServiceCollection services)
{
    // [DEMO NOTE]
    // Normally, we want these registration logic to be implemented in each project.
    // But I keep all here to simplify the demo.

    var allTypes = typeof(DataAccessRegistration).Assembly.GetTypes();
    foreach (var entityType in allTypes)
    {
        if (entityType.Namespace == typeof(Property).Namespace)
        {
            services.AddScoped(typeof(IRepository<>).MakeGenericType(entityType), typeof(Repository<>).MakeGenericType(entityType));
            services.AddScoped(typeof(IDataLoader<>).MakeGenericType(entityType), typeof(DataLoader<>).MakeGenericType(entityType));
        }
    }
    return services;
}