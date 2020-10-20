using System;
using System.Threading.Tasks;
using Application.Festivals.Commands.CreateFestival;
using Domain.Entities;
using FluentAssertions;
using Xunit;
using ValidationException = FluentValidation.ValidationException;

namespace Application.IntegrationTests.Festivals.Commands.CreateFestival
{
    public class CreateFestivalCommandTests : TestBase
    {
        [Fact]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreateFestivalCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }
        
        [Fact]
        public async Task ShouldCreateFestival()
        {
            //var userId = await RunAsDefaultUserAsync();
            
            var command = new CreateFestivalCommand
            {
                Title = "Title",
                Description = "Description",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(4),
                Street = "Street",
                Number = "112",
                PostalCode = "12345",
                State = "state",
                Country = "country"
            };
            
            var festivalId = await SendAsync(command);

            var item = await FindAsync<Festival>(festivalId);

            item.Should().NotBeNull();
            item.Title.Should().Be(command.Title);
            item.Created.Should().BeCloseTo(DateTime.UtcNow, 10000);
            item.LastModifiedBy.Should().BeNull();
            item.RowVersion.Should().BeCloseTo(DateTime.UtcNow, 10000);
        }
    }
}