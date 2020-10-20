using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Festivals.Queries.GetFestivals
{
    public class GetFestivalsQuery : IRequest<FestivalsVm>
    {
    }
    
    public class GetFestivalsQueryHandler : IRequestHandler<GetFestivalsQuery, FestivalsVm>
    {
        private readonly IFestivalDbContext _context;
        private readonly IMapper _mapper;

        public GetFestivalsQueryHandler(IFestivalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FestivalsVm> Handle(GetFestivalsQuery request, CancellationToken cancellationToken)
        {
            
            return new FestivalsVm()
            {
                Festivals = await _context.Festivals
                    .ProjectTo<FestivalDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}