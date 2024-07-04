using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using LIBAPI.Services;
using Data;
using Data.Repository;
using Data.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using LIBAPI;

var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
try
{
    logger.Debug("init main");
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
    });

    builder.Services.AddDbContext<MyDBContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DBCS")));

    // Register repositories
    builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

    // Register services
    builder.Services.AddScoped<IAuthorService, AuthorService>();
    builder.Services.AddScoped<IAddressService, AddressService>();
    builder.Services.AddScoped<IBookCategoryService, BookCategoryService>();
    builder.Services.AddScoped<IBookService, BookService>();
    builder.Services.AddScoped<ICategoryService, CategoryService>();

    // Register Logger
    builder.Services.AddSingleton<ILoggerManager, LoggerManager>();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    // Add the middleware here
    app.UseMiddleware<ExceptionMiddleware>();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    // NLog: catch setup errors
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    LogManager.Shutdown();
}
