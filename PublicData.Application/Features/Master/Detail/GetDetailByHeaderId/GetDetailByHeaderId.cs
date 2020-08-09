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
    public class GetDetailByHeaderIdQueryHandler : IRequestHandler<GetDetailByHeaderIdQuery, IList<HeaderModel>>
    {
        private readonly IMapper _mapper;
        private readonly IDetailRepository _detailRepository;

        public GetDetailByHeaderIdQueryHandler(IDetailRepository detailRepository, IMapper mapper)
        {
            _detailRepository = detailRepository;
            _mapper = mapper;
        }

        public async Task<IList<HeaderModel>> Handle(GetDetailByHeaderIdQuery request, CancellationToken cancellationToken)
        {
            return await _detailRepository.GetList(x => x.HeaderId == request.HeaderId)
                .ProjectTo<HeaderModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetDetailByHeaderIdQuery : IRequest<IList<HeaderModel>>
    {
        public int HeaderId { get; set; }
    }
}
