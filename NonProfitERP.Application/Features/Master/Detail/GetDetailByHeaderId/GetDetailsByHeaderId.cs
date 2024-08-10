using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.Detail.GetDetailByHeaderId
{
    public class GetDetailsByHeaderIdQueryHandler : IRequestHandler<GetDetailsByHeaderIdQuery, IList<DetailModel>>
    {
        private readonly IMapper _mapper;
        private readonly IDetailRepository _detailRepository;

        public GetDetailsByHeaderIdQueryHandler(IDetailRepository detailRepository, IMapper mapper)
        {
            _detailRepository = detailRepository;
            _mapper = mapper;
        }

        public async Task<IList<DetailModel>> Handle(GetDetailsByHeaderIdQuery request, CancellationToken cancellationToken)
        {
            return await _detailRepository.GetList(x => x.HeaderId == request.HeaderId && x.IsActive == true)
                .ProjectTo<DetailModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetDetailsByHeaderIdQuery : IRequest<IList<DetailModel>>
    {
        public int HeaderId { get; set; }
    }
}
