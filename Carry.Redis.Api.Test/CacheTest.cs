using Carry.Redis.Api.Controllers;
using Carry.Redis.Domain.Dto;
using Carry.Redis.Domain.Response;
using FluentAssertions;
using MediatR;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Carry.Redis.Api.Test
{
    [TestFixture]
    public class CacheTest
    {

        Mock<IMediator> _mock;

        RedisController _controller;

        [SetUp]
        public void Setup()
        {
            this._mock = new Mock<IMediator>();
            _controller = new RedisController(_mock.Object);
        }


        [Test, Description("Add a data to redis")]
        public async Task Add_Data_To_Cache()
        {

            var addBuidler = new AddBuilder().AddKey("keykey")
                                             .AddValue("Do you love me")
                                             .Build();

            var commandResponse = new CommandResponse
            {
                Message = "Success",
                StatusCode = 201
            };

            var expected = this._mock.Setup(x => x.Send(addBuidler, new CancellationToken())).ReturnsAsync(commandResponse);

            var actual = await this._controller.AddToCache(addBuidler);

            actual.StatusCode.Should().Be(201);
            actual.Message.Should().Be("Success");
        }




        [Test, Description("Query cache data")]
        public async Task Query_Data_In_Redis_Cache()
        {

            var queryResponse = new QueryResponse
            {
                Result = "Some Data"
            };

            var expected = this._mock.Setup(x => x.Send(It.IsAny<QueryDto>(), new CancellationToken())).ReturnsAsync(queryResponse);

            var actual = await this._controller.GetCachedData("someKey");

            actual.Result.Should().Be("Some Data");
        }








    }
}
