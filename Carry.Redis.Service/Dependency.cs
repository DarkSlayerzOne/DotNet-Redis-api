using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carry.Redis.Service
{
    public static class Dependency
    {

        public static void AddServiceDependency(this IServiceCollection service)
        {
            service.AddScoped<IRedisCommandService, RedisCommandService>();
            service.AddScoped<IRedisQueryService, RedisQueryService>();
                
        }


    }
}
