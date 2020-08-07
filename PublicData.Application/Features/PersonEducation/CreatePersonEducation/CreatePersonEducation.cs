using AutoMapper;
using MediatR;
using PublicData.Common.Interfaces;
using PublicData.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PublicData.Application.Features.PersonEducation.CreatePersonEducation
{
    using DAL.Entities;
    using PublicData.Application.Mappings;

    public class CreatePersonEducationCommandHandler : IRequestHandler<CreatePersonEducationCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IPersonEducationRepository _personEducationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePersonEducationCommandHandler(IMapper mapper, IPersonEducationRepository personEducationRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _personEducationRepository = personEducationRepository;
        }

        public Task<int> Handle(CreatePersonEducationCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PersonEducation>(request);

            _personEducationRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreatePersonEducationCommand : IRequest<int>, IMapFrom<PersonEducation>
    {
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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePersonEducationCommand, PersonEducation>();
        }
    }
}
