using AutoMapper;
using MediatR;
using NonProfitERP.Application.Mappings;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.PersonWorkExperience.UpdatePersonWorkExperienceByExperienceId
{
    using DAL.Entities;

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
            if (!result)
            {
                throw new NotFoundException(nameof(PersonWorkExperience), request.Id);
            }

            var entity = _mapper.Map<PersonWorkExperience>(request);
            entity.IsActive = true;
            _personWorkExperienceRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdatePersonWorkExperienceByExperienceIdCommand : IRequest<bool>, IMapFrom<PersonWorkExperience>
    {
        public int Id { get; set; }
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
            profile.CreateMap<UpdatePersonWorkExperienceByExperienceIdCommand, PersonWorkExperience>();
        }
    }
}
