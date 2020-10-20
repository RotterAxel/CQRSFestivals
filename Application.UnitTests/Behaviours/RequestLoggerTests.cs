using Application.Festivals.Commands.CreateFestival;
using Microsoft.Extensions.Logging;
using Moq;

namespace Application.UnitTests.Behaviours
{
    public class RequestLoggerTests
    {
        private readonly Mock<ILogger<CreateFestivalCommand>> _logger;


        public RequestLoggerTests()
        {
            _logger = new Mock<ILogger<CreateFestivalCommand>>();
        }

        // [Fact]
        // public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
        // {
        //     _currentUserService.Setup(x => x.UserId).Returns("Administrator");
        //
        //     var requestLogger = new LoggingBehaviour<CreateFestivalCommand>(_logger.Object, _currentUserService.Object /*, _identityService.Object*/);
        //
        //     await requestLogger.Process(new CreateFestivalCommand { Title = "title" }, new CancellationToken());
        //     
        //     // _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Once);
        // }
        //
        // [Fact]
        // public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
        // {
        //     var requestLogger = new LoggingBehaviour<CreateFestivalCommand>(_logger.Object, _currentUserService.Object/*, _identityService.Object*/);
        //
        //     await requestLogger.Process(new CreateFestivalCommand { Title = "title" }, new CancellationToken());
        //
        //     // _identityService.Verify(i => i.GetUserNameAsync(null), Times.Never);
        // }
    }
}