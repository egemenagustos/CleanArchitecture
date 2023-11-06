namespace CleanArchitecture.WebAPI.Middleware
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder useMiddlewareExtensions(this IApplicationBuilder app)
        {
          app.UseMiddleware<ExceptionMiddleware>();
            return app;
        }
    }
}
