using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using PublicData.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using PublicData.Application.Shared;
using AutoMapper.QueryableExtensions;

namespace PublicData.Application.Features.Master.Taluka.GetAllTalukasByDistrictId
{
    public class GetAllTalukasByDistrictIdQueryHandler : IRequestHandler<GetAllTalukasByDistrictIdQuery, IList<TalukaModel>>
    {
        private readonly ITalukaRepository _talukaRepository;
        private readonly IMapper _mapper;

        public GetAllTalukasByDistrictIdQueryHandler(ITalukaRepository talukaRepository, IMapper mapper)
        {
            _talukaRepository = talukaRepository;
            _mapper = mapper;
        }

        public async Task<IList<TalukaModel>> Handle(GetAllTalukasByDistrictIdQuery request, CancellationToken cancellationToken)
        {
            return await _talukaRepository.GetList(x => x.DistrictId == request.DistrictId)
                .ProjectTo<TalukaModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetAllTalukasByDistrictIdQuery : IRequest<IList<TalukaModel>>
    {
        public int DistrictId { get; set; }
    }
}
