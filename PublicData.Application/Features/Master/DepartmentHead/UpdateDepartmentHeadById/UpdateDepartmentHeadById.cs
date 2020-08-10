using MediatR;
using AutoMapper;
using PublicData.Application.Mappings;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;
using PublicData.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PublicData.Application.Features.Master.DepartmentHead.UpdateDepartmentHeadById
{
    using DAL.Entities;

    public class UpdateDepartmentHeadByIdCommandHandler : IRequestHandler<UpdateDepartmentHeadByIdCommand, bool>
    {
        private readonly IDepartmentHeadRepository _departmentHeadRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDepartmentHeadByIdCommandHandler(IDepartmentHeadRepository departmentHeadRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _departmentHeadRepository = departmentHeadRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdateDepartmentHeadByIdCommand request, CancellationToken cancellationToken)
        {
            var result = _departmentHeadRepository.Exists(x => x.Id == request.Id);
            if (!result)
            {
                throw new NotFoundException(nameof(DepartmentHead), request.Id);
            }

            var entity = _mapper.Map<DepartmentHead>(request);
            _departmentHeadRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdateDepartmentHeadByIdCommand : IRequest<bool>, IMapFrom<DepartmentHead>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int DepartmentId { get; set; }
        public int FromYear { get; set; }
        public int? ToYear { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DepartmentHead, UpdateDepartmentHeadByIdCommand>();
        }
    }
}
