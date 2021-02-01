using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Carry.Redis.Data
{
    public static class Dependency
    {
        public static void AddRedisDepndency(this IServiceCollection service, string host)
        {
            var redis = ConnectionMultiplexer.Connect(host);
            service.AddScoped(r => redis.GetDatabase());
        }

        public static void AddDataDependency(this IServiceCollection service)
        {
            service.AddScoped<IRedisCommand, RedisCommand>();
            service.AddScoped<IRedisQuery, RedisQuery>();
        } 

    }
}
