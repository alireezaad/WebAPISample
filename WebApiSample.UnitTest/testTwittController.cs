using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPISample.Controllers;
using WebAPISample.Services;
using Xunit;

namespace WebApiSample.UnitTest
{
    public class testTwittController
    {
        [Fact]
        public void GetSuccess_StatusCode200()
        {
            // arrange

            //var mockTwittRepo = new Mock<ITwittRepsitory>();
            var controller = new TwittController();
            //mockTwittRepo.Setups()

            // act
            var result =(OkObjectResult)controller.GetAll();

            // assert

            result.StatusCode.Should().Be(200);
        }
    }
}