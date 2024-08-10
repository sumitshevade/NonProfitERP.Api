using AutoMapper;
using MediatR;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.PersonWorkExperience.GetPersonWorkExperienceByExperienceId
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
