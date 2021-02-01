using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carry.Redis.Domain.Response
{
    public class QueryResponse : IRequest
    {
        public string Result { get; set; }

    }
}
