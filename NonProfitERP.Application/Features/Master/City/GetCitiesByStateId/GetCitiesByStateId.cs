using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using NonProfitERP.DAL.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;
using AutoMapper.QueryableExtensions;

namespace NonProfitERP.Application.Features.Master.City.GetCitiesByStateId
{
    public class GetCitiesByStateIdQuery : IRequestHandler<GetCitiesByStateId, IList<CityModel>>
    {
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;

        public GetCitiesByStateIdQuery(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<IList<CityModel>> Handle(GetCitiesByStateId request, CancellationToken cancellationToken)
        {
            return await _cityRepository.GetList(x => x.StateId == request.StateId && x.IsActive == true)
                .ProjectTo<CityModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetCitiesByStateId : IRequest<IList<CityModel>>
    {
        public int StateId { get; set; }
    }
}
