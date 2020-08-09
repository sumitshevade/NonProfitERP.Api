using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PublicData.Application.Shared;
using AutoMapper.QueryableExtensions;

namespace PublicData.Application.Features.Master.Header.GetAllHeaders
{
    public class GetHeadersQueryHandler : IRequestHandler<GetHeadersQuery, IList<HeaderModel>>
    {
        private readonly IHeaderRepository _headerRepository;
        private readonly IMapper _mapper;

        public GetHeadersQueryHandler(IHeaderRepository headerRepository, IMapper mapper)
        {
            _mapper = mapper;
            _headerRepository = headerRepository;
        }

        public async Task<IList<HeaderModel>> Handle(GetHeadersQuery request, CancellationToken cancellationToken)
        {
            return await _headerRepository.GetList()
                .ProjectTo<HeaderModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetHeadersQuery : IRequest<IList<HeaderModel>>
    {
    }
}
