using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using NonProfitERP.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;
using AutoMapper.QueryableExtensions;

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
