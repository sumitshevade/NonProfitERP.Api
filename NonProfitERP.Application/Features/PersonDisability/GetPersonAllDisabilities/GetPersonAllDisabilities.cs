using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.PersonDisability.GetPersonAllDisabilities
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
            return await _personDisabilityRepository.GetList(x => x.PersonId == request.PersonId && x.IsActive == true)
                .ProjectTo<PersonDisabilityModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetPersonAllDisabilitiesQuery : IRequest<IList<PersonDisabilityModel>>
    {
        public int PersonId { get; set; }
    }
}
