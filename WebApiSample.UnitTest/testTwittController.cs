using Moq;
using WebAPISample.Services;
using Xunit;

namespace WebApiSample.UnitTest
{
    public class testTwittController
    {
        [Fact]
        public async Task GetSuccess_StatusCode200()
        {
            var mockTwittRepo = new Mock<ITwittRepsitory>();

            //mockTwittRepo.Setups()
        }
    }
}