using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using System.Collections.Generic;
using PublicData.Application.Shared;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace PublicData.Application.Features.Master.Detail.GetDetailByHeaderId
{
    public class GetDetailsByHeaderIdQueryHandler : IRequestHandler<GetDetailsByHeaderIdQuery, IList<HeaderModel>>
    {
        private readonly IMapper _mapper;
        private readonly IDetailRepository _detailRepository;

        public GetDetailsByHeaderIdQueryHandler(IDetailRepository detailRepository, IMapper mapper)
        {
            _detailRepository = detailRepository;
            _mapper = mapper;
        }

        public async Task<IList<HeaderModel>> Handle(GetDetailsByHeaderIdQuery request, CancellationToken cancellationToken)
        {
            return await _detailRepository.GetList(x => x.HeaderId == request.HeaderId)
                .ProjectTo<HeaderModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetDetailsByHeaderIdQuery : IRequest<IList<HeaderModel>>
    {
        public int HeaderId { get; set; }
    }
}
