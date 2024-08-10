using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.Department.GetAllDepartments
{
    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, IList<DepartmentModel>>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public GetAllDepartmentsQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<IList<DepartmentModel>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            return await _departmentRepository.GetList(x => x.IsActive == true)
                .ProjectTo<DepartmentModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetAllDepartmentsQuery : IRequest<IList<DepartmentModel>>
    {
    }
}
