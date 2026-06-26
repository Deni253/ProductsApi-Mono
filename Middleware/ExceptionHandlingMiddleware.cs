using System.Reflection.Metadata.Ecma335;

namespace ProductsApi.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next) 
        {
            this._next = next;
        }
        public async Task InvokeAsync (HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e) {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new { error = e.Message, inner = e.InnerException?.Message });
            }
            
        }
    }
}
