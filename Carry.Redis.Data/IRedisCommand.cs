using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carry.Redis.Data
{
    public interface IRedisCommand
    {
        Task AddToCacheAsync(KeyValuePair<string, string> value);


        Task DeleteCacheAsync(string key);

        
    }
}
