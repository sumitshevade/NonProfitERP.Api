using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Interfaces;
using PublicData.Application.Mappings;

namespace PublicData.Application.Features.PersonWorkExperience.CreatePersonWorkExperience
{
    using DAL.Entities;

    public class CreatePersonWorkExperienceQueryHandler : IRequestHandler<CreatePersonWorkExperienceQuery, int>
    {
        private readonly IMapper _mapper;
        private readonly IPersonWorkExperienceRepository _personWorkExperienceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePersonWorkExperienceQueryHandler(IMapper mapper, IPersonWorkExperienceRepository personWorkExperienceRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _personWorkExperienceRepository = personWorkExperienceRepository;
        }

        public Task<int> Handle(CreatePersonWorkExperienceQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PersonWorkExperience>(request);

            _personWorkExperienceRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreatePersonWorkExperienceQuery : IRequest<int>, IMapFrom<PersonWorkExperience>
    {
        public int PersonId { get; set; }
        public int? OrganizationId { get; set; }
        public string OtherOrganization { get; set; }
        public int? WorkTypeId { get; set; }
        public string OtherWorkType { get; set; }
        public int? DepartmentId { get; set; }
        public string OtherDepartment { get; set; }
        public int? DesignationId { get; set; }
        public string OtherDesignation { get; set; }
        public int? FromYear { get; set; }
        public int? ToYear { get; set; }
        public string Specialization { get; set; }
        public bool? IsFreeLance { get; set; }
        public bool? IsFullTime { get; set; }
        public string LongText { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePersonWorkExperienceQuery, PersonWorkExperience>();
        }
    }
}
