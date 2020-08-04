using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.Data.Interfaces;
using PublicData.Application.Shared;

namespace PublicData.Application.Features.PersonDisability.GetPersonDisabilityByDisabilityId
{
    public class GetPersonDisabilityByDisabilityIdQueryHandler : IRequestHandler<GetPersonDisabilityByDisabilityIdQuery, PersonDisabilityModel>
    {
        private readonly IMapper _mapper;
        private readonly IPersonDisabilityRepository _personDisabilityRepository;

        public GetPersonDisabilityByDisabilityIdQueryHandler(IMapper mapper, IPersonDisabilityRepository personDisabilityRepository)
        {
            _personDisabilityRepository = personDisabilityRepository;
            _mapper = mapper;
        }

        public async Task<PersonDisabilityModel> Handle(GetPersonDisabilityByDisabilityIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<PersonDisabilityModel>(_personDisabilityRepository.GetById(request.DisabilityId)));
        }
    }

    public class GetPersonDisabilityByDisabilityIdQuery : IRequest<PersonDisabilityModel>
    {
        public int DisabilityId { get; set; }
    }
}
