using AutoMapper;
using MediatR;
using NonProfitERP.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;

namespace NonProfitERP.Application.Features.Master.Detail.GetDetails
{
    public class GetDetailsQueryHandler : IRequestHandler<GetDetailsQuery, IList<DetailModel>>
    {
        private readonly IMapper _mapper;
        private readonly IDetailRepository _detailRepository;

        public GetDetailsQueryHandler(IDetailRepository detailRepository, IMapper mapper)
        {
            _mapper = mapper;
            _detailRepository = detailRepository;
        }

        public async Task<IList<DetailModel>> Handle(GetDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _detailRepository.GetList(x => x.IsActive == true)
                .ProjectTo<DetailModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetDetailsQuery : IRequest<IList<DetailModel>>
    {
    }
}
