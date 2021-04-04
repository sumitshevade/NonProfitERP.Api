using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using NonProfitERP.DAL.Interfaces;
using NonProfitERP.Application.Shared;

namespace NonProfitERP.Application.Features.Master.Department.GetDepartmentById
{
    public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, DepartmentModel>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public GetDepartmentByIdQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<DepartmentModel> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<DepartmentModel>(_departmentRepository.GetById(request.Id)));
        }
    }

    public class GetDepartmentByIdQuery : IRequest<DepartmentModel>
    {
        public int Id { get; set; }
    }
}
