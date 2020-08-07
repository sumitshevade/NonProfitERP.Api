using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using PublicData.DAL.Interfaces;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PublicData.Application.Shared;

namespace PublicData.Application.Features.PersonWorkExperience.GetPersonAllWorkExperiences
{
    public class GetPersonAllWorkExperiencesQueryHandler : IRequestHandler<GetPersonAllWorkExperiencesQuery, IList<PersonWorkExperienceModel>>
    {
        private readonly IMapper _mapper;
        private readonly IPersonWorkExperienceRepository _personWorkExperienceRepository;

        public GetPersonAllWorkExperiencesQueryHandler(IPersonWorkExperienceRepository personWorkExperienceRepository, IMapper mapper)
        {
            _personWorkExperienceRepository = personWorkExperienceRepository;
            _mapper = mapper;
        }

        public async Task<IList<PersonWorkExperienceModel>> Handle(GetPersonAllWorkExperiencesQuery request, CancellationToken cancellationToken)
        {
            return await _personWorkExperienceRepository.GetList(x => x.PersonId == request.PersonId)
                .ProjectTo<PersonWorkExperienceModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetPersonAllWorkExperiencesQuery : IRequest<IList<PersonWorkExperienceModel>>
    {
        public int PersonId { get; set; }
    }
}
