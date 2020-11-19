using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;
using AutoMapper;

namespace PublicData.Application.Features.PersonEducation.UpdatePersonEducationByEducationId
{
    using DAL.Entities;
    using PublicData.Application.Mappings;

    public class UpdatePersonEducationByEducationIdCommandHandler : IRequestHandler<UpdatePersonEducationByEducationIdCommand, bool>
    {
        private readonly IPersonEducationRepository _personEducationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePersonEducationByEducationIdCommandHandler(IPersonEducationRepository personEducationRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _personEducationRepository = personEducationRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdatePersonEducationByEducationIdCommand request, CancellationToken cancellationToken)
        {
            var result = _personEducationRepository.Exists(x => x.Id == request.Id);
            if (result)
            {
                throw new NotFoundException(nameof(PersonEducation), request.Id);
            }

            var entity = _mapper.Map<PersonEducation>(request);
            entity.IsActive = true;
            _personEducationRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdatePersonEducationByEducationIdCommand : IRequest<bool>, IMapFrom<PersonEducation>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int? SchoolId { get; set; }
        public string OtherSchool { get; set; }
        public int? FromStdId { get; set; }
        public int? ToStdId { get; set; }
        public int? MediumId { get; set; }
        public string OtherMedium { get; set; }
        public int FromYear { get; set; }
        public int? ToYear { get; set; }
        public int? UniversityBoardId { get; set; }
        public string OtherUniversityBoard { get; set; }
        public int? DegreeId { get; set; }
        public string OtherDegree { get; set; }
        public int? CourseId { get; set; }
        public string OtherCourse { get; set; }
        public string Specialization { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePersonEducationByEducationIdCommand, PersonEducation>();
        }
    }
}
