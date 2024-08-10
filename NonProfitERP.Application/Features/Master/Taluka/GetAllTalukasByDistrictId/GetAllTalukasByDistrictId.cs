using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.Taluka.GetAllTalukasByDistrictId
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
            return await _talukaRepository.GetList(x => x.DistrictId == request.DistrictId && x.IsActive == true)
                .ProjectTo<TalukaModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetAllTalukasByDistrictIdQuery : IRequest<IList<TalukaModel>>
    {
        public int DistrictId { get; set; }
    }
}
