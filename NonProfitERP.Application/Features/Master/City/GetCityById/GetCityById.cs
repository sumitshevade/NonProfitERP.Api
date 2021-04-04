using AutoMapper;
using MediatR;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.City.GetCityById
{
    public class GetCityByIdQueryHandler : IRequestHandler<GetCityByIdQuery, CityModel>
    {
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;

        public GetCityByIdQueryHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
        }

        public async Task<CityModel> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<CityModel>(_cityRepository.GetById(request.Id)));
        }
    }

    public class GetCityByIdQuery : IRequest<CityModel>
    {
        public int Id { get; set; }
    }
}
