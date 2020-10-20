using System;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using Xunit;

namespace Persistence.IntegrationTests
{
    public class FestivalDbContextTests : IDisposable
    {
         private readonly string _userId;
        private readonly DateTime _dateTime;
        private readonly Mock<IDateTime> _dateTimeMock;
        private readonly Mock<ICurrentUserService> _currentUserServiceMock;
        private readonly IFestivalDbContext _sut;

        public FestivalDbContextTests()
        {
            _dateTime = new DateTime(3001, 1, 1);
            _dateTimeMock = new Mock<IDateTime>();
            _dateTimeMock.Setup(m => m.UtcNow).Returns(_dateTime);

            _userId = "00000000-0000-0000-0000-000000000000";
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _currentUserServiceMock.Setup(m => m.UserId).Returns(_userId);

            var options = new DbContextOptionsBuilder<FestivalsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _sut = new FestivalsDbContext(options, _currentUserServiceMock.Object, _dateTimeMock.Object);

            _sut.Festivals.Add(new Festival
            {
                Title = "Title",
                Description = "Description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(3),
                Website = "htttp asdoin"
            });

            _sut.SaveChanges();
        }

        [Fact]
        public void SaveChangesAsync_GivenNewFestival_ShouldSetCreatedProperties()
        {
            var festival = new Festival
            {
                Title = "Title",
                Description = "Description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(3),
                Website = "htttp asdoin"
            };

            _sut.Festivals.Add(festival);

            _sut.SaveChanges();

            festival.Created.ShouldBe(_dateTime);
            festival.CreatedBy.ShouldBe(_userId);
        }

        [Fact]
        public async Task SaveChangesAsync_GivenExistingProduct_ShouldSetLastModifiedProperties()
        {
            var festival = await _sut.Festivals.FindAsync(1);
        
            festival.Description = "New Description";
        
            _sut.SaveChanges();
        
            festival.RowVersion.ShouldNotBeNull();
            festival.RowVersion.ShouldBe(_dateTime);
            festival.LastModifiedBy.ShouldBe(_userId);
        }
        
        public void Dispose()
        {
        }
    }
}