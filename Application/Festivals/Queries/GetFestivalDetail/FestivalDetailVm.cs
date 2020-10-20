using System;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Festivals.Queries.GetFestivalDetail
{
    //TODO: Test RowVersion for Festival & Address
    public class FestivalDetailVm : IMapFrom<Festival>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Website { get; set; }
        public DateTime FestivalRowVersion { get; set; }
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public DateTime AddressRowVersion { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Festival, FestivalDetailVm>()
                .ForMember(d => d.FestivalRowVersion,
                    opt => opt
                        .MapFrom(s => s.RowVersion))
                .ForMember(d => d.Street,
                    opt => opt
                        .MapFrom(s => s.Address.Street))
                .ForMember(d => d.Number,
                    opt => opt
                        .MapFrom(s => s.Address.Number))
                .ForMember(d => d.PostalCode,
                    opt => opt
                        .MapFrom(s => s.Address.PostalCode))
                .ForMember(d => d.State,
                    opt => opt
                        .MapFrom(s => s.Address.State))
                .ForMember(d => d.Country,
                    opt => opt
                        .MapFrom(s => s.Address.Country))
                .ForMember(d => d.AddressRowVersion,
                    opt => opt
                        .MapFrom(s => s.Address.RowVersion));;
        }
    }
}