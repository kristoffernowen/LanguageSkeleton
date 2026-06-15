namespace LanguageSkeleton.Api.Middleware
{
    public class ApiKeyMiddleware(RequestDelegate next, IConfiguration config)
    {
        private readonly string[] _allowedClients = config.GetSection("AllowedClients").Get<string[]>()
                                                    ?? Array.Empty<string>();

        public async Task InvokeAsync(HttpContext context)
        {
            var provided = context.Request.Headers["x-api-key"].FirstOrDefault();

            if (!_allowedClients.Contains(provided))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid client id");
                return;
            }

            await next(context);
        }
    }
}

