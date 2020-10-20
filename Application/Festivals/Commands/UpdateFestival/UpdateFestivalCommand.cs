using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Festivals.Commands.UpdateFestival
{
    //TODO: Test RowVersion for Festival
    public class UpdateFestivalCommand : IRequest
    {
        public int FestivalId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Website { get; set; }
        public DateTime RowVersion { get; set; }
    }
    
    public class UpdateFestivalCommandHandler : IRequestHandler<UpdateFestivalCommand>
    {
        private readonly IFestivalDbContext _context;

        public UpdateFestivalCommandHandler(IFestivalDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateFestivalCommand request, CancellationToken cancellationToken)
        {
            var festivalEntity = await _context.Festivals.FindAsync(request.FestivalId);
            
            if (festivalEntity == null)
            {
                throw new NotFoundException(nameof(Festival), request.FestivalId);
            }

            festivalEntity.Title = request.Title;
            festivalEntity.Description = request.Description;
            festivalEntity.StartDate = request.StartDate;
            festivalEntity.EndDate = request.EndDate;
            festivalEntity.Website = request.Website;
            festivalEntity.RowVersion = request.RowVersion;

            _context.SaveChanges();

            return Unit.Value;
        }
    }
}