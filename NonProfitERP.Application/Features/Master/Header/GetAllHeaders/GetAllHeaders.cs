using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.Header.GetAllHeaders
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
            return await _headerRepository.GetList(x => x.IsActive == true)
                .ProjectTo<HeaderModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetHeadersQuery : IRequest<IList<HeaderModel>>
    {
    }
}
