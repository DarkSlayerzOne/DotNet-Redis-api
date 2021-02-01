using Carry.Redis.Domain.Dto;
using Carry.Redis.Domain.Response;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Carry.Redis.Service
{
    public class RedisCommandHandler : IRequestHandler<AddDto, CommandResponse>, IRequestHandler<DeleteDto, CommandResponse>
    {

        private readonly IRedisCommandService _service;

        public RedisCommandHandler(IRedisCommandService service)
        {
            this._service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<CommandResponse> Handle(AddDto request, CancellationToken cancellationToken)
        {
            return await this._service.AddDataToCacheAsync(request).ConfigureAwait(false);
        }

        public async Task<CommandResponse> Handle(DeleteDto request, CancellationToken cancellationToken)
        {
            return await this._service.DeleteCacheAsync(request.Key).ConfigureAwait(false);
        }
    }
}
