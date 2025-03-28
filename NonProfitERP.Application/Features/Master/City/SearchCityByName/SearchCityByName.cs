using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.City.GetCityById
{
    public class SearchCityByNameQueryHandler : IRequestHandler<SearchCityByNameQuery, IList<CityModel>>
    {
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;

        public SearchCityByNameQueryHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
        }

        public async Task<IList<CityModel>> Handle(SearchCityByNameQuery request, CancellationToken cancellationToken)
        {
            return await _cityRepository.SearchCity(request.Name)
                .ProjectTo<CityModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class SearchCityByNameQuery : IRequest<IList<CityModel>>
    {
        public string Name { get; set; }
    }
}
