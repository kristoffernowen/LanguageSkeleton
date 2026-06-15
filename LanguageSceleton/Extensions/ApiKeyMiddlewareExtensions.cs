using LanguageSkeleton.Api.Middleware;

namespace LanguageSkeleton.Api.Extensions
{
    public static class ApiKeyMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiKeyValidation(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ApiKeyMiddleware>();
        }
    }
}
