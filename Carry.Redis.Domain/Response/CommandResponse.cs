using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carry.Redis.Domain.Response
{
    public class CommandResponse : IRequest 
    {

        public int StatusCode { get; set; }

        public string Message { get; set; }
    }
}
