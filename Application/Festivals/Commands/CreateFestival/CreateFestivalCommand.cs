using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Festivals.Commands.CreateFestival
{
    //TODO: Test RowVersion for Address and for Festival
    public class CreateFestivalCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Website { get; set; }
        public DateTime FestivalRowVersion { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public DateTime AddressRowVersion { get; set; }
        
        public class Handler : IRequestHandler<CreateFestivalCommand, int>
        {
            private readonly IFestivalDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IFestivalDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<int> Handle(CreateFestivalCommand request, CancellationToken cancellationToken)
            {
                var entity = new Festival
                {
                    Title = request.Title,
                    Description = request.Description,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    Website = request.Website,
                    RowVersion = request.FestivalRowVersion,
                    Address = new Address
                    {
                        Street = request.Street,
                        Number = request.Number,
                        PostalCode = request.PostalCode,
                        State = request.State,
                        Country = request.Country,
                        RowVersion = request.AddressRowVersion
                    }
                };

                _context.Festivals.Add(entity);

                _context.SaveChanges();

                return entity.Id;
            }
        }
    }
}