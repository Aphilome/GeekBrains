namespace Catalog.Middleware
{
    public class CheckBrowserMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CheckBrowserMiddleware> _logger;

        public CheckBrowserMiddleware(
            RequestDelegate next,
            ILogger<CheckBrowserMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.UserAgent.ToString().Contains("Edg"))
            {
                context.Response.ContentType = "text/plain; charset=UTF-8";
                await context.Response.WriteAsync("Ваш браузер не поддерживается");
                return;
            }
            await _next(context);
        }
    }
}
