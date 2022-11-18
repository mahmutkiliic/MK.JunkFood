using Microsoft.AspNetCore.Mvc;
using MK.JunkFood.API.Errors;
using MK.JunkFood.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace MK.JunkFood.API.Extensions
{
    /*
     This class should be static.
     */
    public static class ApplicationServicesExtensions
    {
        // If you want to configure something related to Controllers you must code it below .AddControllers()
        public static void ConfigureApiBehaviorOptions(this IServiceCollection services) =>
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

        

        public static void DBContextAddition(this IServiceCollection services) => 
            services.AddDbContext<StoreContext>(options =>
        {
            var builder = WebApplication.CreateBuilder();
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

    }
}

