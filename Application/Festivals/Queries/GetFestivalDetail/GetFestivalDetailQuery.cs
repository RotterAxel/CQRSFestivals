using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Festivals.Queries.GetFestivalDetail
{
    public class GetFestivalDetailQuery : IRequest<FestivalDetailVm>
    {
        public int Id { get; set; }

        public class GetFestivalDetailQueryHandler : IRequestHandler<GetFestivalDetailQuery, FestivalDetailVm>
        {
            private readonly IFestivalDbContext _context;
            private readonly IMapper _mapper;

            public GetFestivalDetailQueryHandler(IFestivalDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<FestivalDetailVm> Handle(GetFestivalDetailQuery request,
                CancellationToken cancellationToken)
            {
                return await _context.Festivals
                    .Include(f => f.Address)
                    .Where(f => f.Id == request.Id)
                    .ProjectTo<FestivalDetailVm>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(cancellationToken);
            }
        }
    }
}