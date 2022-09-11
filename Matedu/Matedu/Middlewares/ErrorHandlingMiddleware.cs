using Matedu.Data.Exceptions;

namespace Matedu.Middlewares
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (ResourceNotFoundException e)
            {
                context.Response.Redirect("/Error/ResourceNotFound");
            }
            catch (ResourceAlreadyExistsException e)
            {
                context.Response.Redirect("/Error/ResourceAlreadyExists");
            }
            catch (ReviewAlreadyExistsException e)
            {
                context.Response.Redirect("/Error/ReviewAlreadyExists");
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new { Error = "Something went wrong" });
            }

        }
    }
}
