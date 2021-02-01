using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Carry.Redis.Api.Key
{
    public class KeyFilter : Attribute, IAsyncActionFilter
    {

        private const string HeaderName = "X-Carry-Redis-Key";

        private const string AppSettingsValue = "ApiKey";

         
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            if (!context.HttpContext.Request.Headers.TryGetValue(HeaderName, out var redisKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var config = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var key = config.GetValue<string>(AppSettingsValue);
              
            if (!key.Equals(redisKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();

        }
    }
}
