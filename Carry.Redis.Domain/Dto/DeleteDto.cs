using Carry.Redis.Domain.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carry.Redis.Domain.Dto
{
    public class DeleteDto : IRequest<CommandResponse>
    {
        public string Key { get; set; }
    }
}
