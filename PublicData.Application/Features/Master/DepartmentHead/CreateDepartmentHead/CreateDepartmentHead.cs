using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Interfaces;
using PublicData.Application.Mappings;

namespace PublicData.Application.Features.Master.DepartmentHead.CreateDepartmentHead
{
    using DAL.Entities;

    public class CreateDepartmentHeadCommandHandler : IRequestHandler<CreateDepartmentHeadCommand, int>
    {
        private readonly IDepartmentHeadRepository _departmentHeadRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDepartmentHeadCommandHandler(IDepartmentHeadRepository departmentHeadRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _departmentHeadRepository = departmentHeadRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<int> Handle(CreateDepartmentHeadCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<DepartmentHead>(request);

            _departmentHeadRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreateDepartmentHeadCommand : IRequest<int>, IMapFrom<DepartmentHead>
    {
        public int PersonId { get; set; }
        public int DepartmentId { get; set; }
        public int FromYear { get; set; }
        public int? ToYear { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DepartmentHead, CreateDepartmentHeadCommand>();
        }
    }
}
