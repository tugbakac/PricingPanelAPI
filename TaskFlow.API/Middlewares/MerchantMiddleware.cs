namespace TaskFlow.API.Middlewares
{
    public class MerchantMiddleware
    {
        private readonly RequestDelegate _next;

        public MerchantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var merchantId = context.Request.Headers["merchant-id"].ToString();

            if (!string.IsNullOrEmpty(merchantId))
            {
                context.Items["MerchantId"] = merchantId;
            }

            await _next(context);
        }
    }
}
