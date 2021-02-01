using Carry.Redis.Domain.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carry.Redis.Domain.Dto
{
    public class AddDto : IRequest<CommandResponse>
    {
        public string Key { get; set; }

        public string Value { get; set; }

    }
}
