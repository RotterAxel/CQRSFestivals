using System;
using Application.Common.Mappings;
using Application.Festivals.Queries.GetFestivalDetail;
using Application.Festivals.Queries.GetFestivals;
using AutoMapper;
using Domain.Entities;
using Xunit;

namespace Application.UnitTests.Mappings
{
    public class MappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = _configuration.CreateMapper();
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }
        
        [Theory]
        [InlineData(typeof(Festival), typeof(FestivalDto))]
        [InlineData(typeof(Festival), typeof(FestivalDetailVm))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);

            _mapper.Map(instance, source, destination);
        }
    }
}