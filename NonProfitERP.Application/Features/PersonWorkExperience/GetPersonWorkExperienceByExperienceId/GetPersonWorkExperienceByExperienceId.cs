using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Application.Shared;

namespace PublicData.Application.Features.PersonWorkExperience.GetPersonWorkExperienceByExperienceId
{
    public class GetPersonWorkExperienceByExperienceIdQueryHandler : IRequestHandler<GetPersonWorkExperienceByExperienceIdQuery, PersonWorkExperienceModel>
    {
        private readonly IMapper _mapper;
        private readonly IPersonWorkExperienceRepository _personWorkExperienceRepository;

        public GetPersonWorkExperienceByExperienceIdQueryHandler(IPersonWorkExperienceRepository personWorkExperienceRepository, IMapper mapper)
        {
            _personWorkExperienceRepository = personWorkExperienceRepository;
            _mapper = mapper;
        }

        public async Task<PersonWorkExperienceModel> Handle(GetPersonWorkExperienceByExperienceIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<PersonWorkExperienceModel>(_personWorkExperienceRepository.GetById(request.WorkExperienceId)));
        }
    }

    public class GetPersonWorkExperienceByExperienceIdQuery : IRequest<PersonWorkExperienceModel>
    {
        public int WorkExperienceId { get; set; }
    }
}
