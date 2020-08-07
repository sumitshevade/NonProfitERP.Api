using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;

namespace PublicData.Application.Features.PersonWorkExperience.UpdatePersonWorkExperienceByExperienceId
{
    using Data.Entities;
    using PublicData.Application.Mappings;

    public class UpdatePersonWorkExperienceByExperienceIdCommandHandler : IRequestHandler<UpdatePersonWorkExperienceByExperienceIdCommand, bool>
    {
        private readonly IPersonWorkExperienceRepository _personWorkExperienceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePersonWorkExperienceByExperienceIdCommandHandler(IPersonWorkExperienceRepository personWorkExperienceRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _personWorkExperienceRepository = personWorkExperienceRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdatePersonWorkExperienceByExperienceIdCommand request, CancellationToken cancellationToken)
        {
            var result = _personWorkExperienceRepository.Exists(x => x.Id == request.Id);
            if (result)
            {
                throw new NotFoundException(nameof(PersonSocialMediaAccount), request.Id);
            }

            var entity = _mapper.Map<PersonWorkExperience>(request);
            _personWorkExperienceRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdatePersonWorkExperienceByExperienceIdCommand : IRequest<bool>, IMapFrom<PersonWorkExperience>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int IndustryId { get; set; }
        public string OtherIndustry { get; set; }
        public int? WorkTypeId { get; set; }
        public string OtherWorkType { get; set; }
        public int? StatusId { get; set; }
        public string OtherStatus { get; set; }
        public string CompanyName { get; set; }
        public string ActualWork { get; set; }
        public int? FromYear { get; set; }
        public int? ToYear { get; set; }
        public string LongText { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePersonWorkExperienceByExperienceIdCommand, PersonWorkExperience>();
        }
    }
}
