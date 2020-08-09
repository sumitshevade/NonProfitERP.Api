using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using PublicData.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using PublicData.Application.Shared;
using AutoMapper.QueryableExtensions;

namespace PublicData.Application.Features.Master.District.GetAllDistrictByStateId
{
    public class GetAllDistrictByStateIdQueryHandler : IRequestHandler<GetAllDistrictByStateIdQuery, IList<DistrictModel>>
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IMapper _mapper;

        public GetAllDistrictByStateIdQueryHandler(IDistrictRepository districtRepository, IMapper mapper)
        {
            _districtRepository = districtRepository;
            _mapper = mapper;
        }

        public async Task<IList<DistrictModel>> Handle(GetAllDistrictByStateIdQuery request, CancellationToken cancellationToken)
        {
            return await _districtRepository.GetList(x => x.StateId == request.StateId)
                .ProjectTo<DistrictModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetAllDistrictByStateIdQuery : IRequest<IList<DistrictModel>>
    {
        public int StateId { get; set; }
    }
}
