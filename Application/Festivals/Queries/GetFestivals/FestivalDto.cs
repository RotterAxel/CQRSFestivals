using System;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Festivals.Queries.GetFestivals
{
    //TODO: Test RowVersion for Festival
    public class FestivalDto : IMapFrom<Festival>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Website { get; set; }
        public DateTime RowVersion { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Festival, FestivalDto>();
        }
    }
}