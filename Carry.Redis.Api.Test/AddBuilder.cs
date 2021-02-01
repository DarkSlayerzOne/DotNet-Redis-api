using Carry.Redis.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carry.Redis.Api.Test
{
    public class AddBuilder
    {

        private readonly AddDto _add;

        public AddBuilder()
        {
            _add = new AddDto();
        }


        public AddDto Build()
        {
            return _add;
        }

        public AddBuilder AddKey(string key)
        {
            this._add.Key = key;
            return this;
        }


        public AddBuilder AddValue(string value)
        {
            this._add.Value = value;
            return this;
        }



    }
}
