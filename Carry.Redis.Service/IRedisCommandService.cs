using Carry.Redis.Domain.Dto;
using Carry.Redis.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carry.Redis.Service
{
    public interface IRedisCommandService
    {

        Task<CommandResponse> AddDataToCacheAsync(AddDto addCache);

        Task<CommandResponse> DeleteCacheAsync(string key);

    }
}
