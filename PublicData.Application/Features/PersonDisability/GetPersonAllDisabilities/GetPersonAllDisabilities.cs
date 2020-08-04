using System.Collections.Generic;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PublicData.Data.Interfaces;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PublicData.Application.Shared;

namespace PublicData.Application.Features.PersonDisability.GetPersonAllDisabilities
{
    public class GetPersonAllDisabilitiesQueryHandler : IRequestHandler<GetPersonAllDisabilitiesQuery, IList<PersonDisabilityModel>>
    {

        private readonly IMapper _mapper;
        private readonly IPersonDisabilityRepository _personDisabilityRepository;

        public GetPersonAllDisabilitiesQueryHandler(IPersonDisabilityRepository personDisabilityRepository, IMapper mapper)
        {
            _personDisabilityRepository = personDisabilityRepository;
            _mapper = mapper;
        }

        public async Task<IList<PersonDisabilityModel>> Handle(GetPersonAllDisabilitiesQuery request, CancellationToken cancellationToken)
        {
            return await _personDisabilityRepository.GetList(x => x.PersonId == request.PersonId)
                .ProjectTo<PersonDisabilityModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetPersonAllDisabilitiesQuery : IRequest<IList<PersonDisabilityModel>>
    {
        public int PersonId { get; set; }
    }
}
