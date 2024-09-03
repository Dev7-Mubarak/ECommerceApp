using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace ECommerceApp.API.Extentions
{
    public static class ExceptionMiddlewareExtention
    {
        public static void configureExceptionErrorHandler(this IApplicationBuilder app)
        {

            app.UseExceptionHandler(e =>
            {
                e.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorDetiles
                        {
                            StutsCode = context.Response.StatusCode,
                            Message = "Internal server error"
                        }.ToString());
                    }
                });
            });
        }
    }
}
