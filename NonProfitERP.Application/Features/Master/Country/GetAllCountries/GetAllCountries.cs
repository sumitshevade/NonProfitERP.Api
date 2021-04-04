using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using NonProfitERP.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;
using AutoMapper.QueryableExtensions;

namespace NonProfitERP.Application.Features.Master.Country.GetAllCountries
{
    public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, IList<CountryModel>>
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        public GetCountriesQueryHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
        }

        public async Task<IList<CountryModel>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            return await _countryRepository.GetList(x => x.IsActive == true)
                .ProjectTo<CountryModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetCountriesQuery : IRequest<IList<CountryModel>>
    {
    }
}
