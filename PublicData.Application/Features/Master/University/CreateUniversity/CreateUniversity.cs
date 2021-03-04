using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Interfaces;
using PublicData.Application.Mappings;

namespace PublicData.Application.Features.Master.University.CreateUniversity
{
    using DAL.Entities;

    public class CreateUniversityCommandHandler : IRequestHandler<CreateUniversityCommand, int>
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUniversityCommandHandler(IUniversityRepository universityRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _universityRepository = universityRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<int> Handle(CreateUniversityCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<University>(request);

            _universityRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreateUniversityCommand : IRequest<int>, IMapFrom<University>
    {
        public string Name { get; set; }
        public int CityId { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUniversityCommand, University>();
        }
    }
}
