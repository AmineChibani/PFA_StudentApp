namespace StudentApp.Middlewares
{

    public class ResponseVerificationMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseVerificationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == 404)
            {
                context.Response.Redirect("/Error/Errors404Basic");
            }
            else if (context.Response.StatusCode == 500)
            {
                context.Response.Redirect("/Error/Errors500");
            }
        }
    }


}
