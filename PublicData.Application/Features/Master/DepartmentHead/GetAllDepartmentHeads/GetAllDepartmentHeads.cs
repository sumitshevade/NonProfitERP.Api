using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using PublicData.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using PublicData.Application.Shared;
using AutoMapper.QueryableExtensions;

namespace PublicData.Application.Features.Master.DepartmentHead.GetAllDepartmentHeads
{
    public class GetAllDepartmentHeadsQueryHandler : IRequestHandler<GetAllDepartmentHeadsQuery, IList<DepartmentHeadModel>>
    {
        private readonly IDepartmentHeadRepository _departmentHeadRepository;
        private readonly IMapper _mapper;

        public GetAllDepartmentHeadsQueryHandler(IDepartmentHeadRepository departmentHeadRepository, IMapper mapper)
        {
            _departmentHeadRepository = departmentHeadRepository;
            _mapper = mapper;
        }

        public async Task<IList<DepartmentHeadModel>> Handle(GetAllDepartmentHeadsQuery request, CancellationToken cancellationToken)
        {
            return await _departmentHeadRepository.GetList(x => x.IsActive == true)
                .ProjectTo<DepartmentHeadModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetAllDepartmentHeadsQuery : IRequest<IList<DepartmentHeadModel>>
    {
    }
}
