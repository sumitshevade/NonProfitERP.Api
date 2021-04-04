using System;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Interfaces;
using PublicData.Application.Mappings;

namespace PublicData.Application.Features.Master.Department.CreateDepartment
{
    using DAL.Entities;

    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, int>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDepartmentCommandHandler(IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<int> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Department>(request);

            _departmentRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreateDepartmentCommand : IRequest<int>, IMapFrom<Department>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ContactNo { get; set; }
        public string EmailId { get; set; }
        public string WebLink { get; set; }
        public string LongText { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDepartmentCommand, Department>();
        }
    }
}
