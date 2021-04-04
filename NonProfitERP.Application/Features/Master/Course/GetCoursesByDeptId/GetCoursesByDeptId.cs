using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using NonProfitERP.DAL.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;
using AutoMapper.QueryableExtensions;

namespace NonProfitERP.Application.Features.Master.Course.GetCoursesByDeptId
{
    public class GetCoursesByDeptIdQuery : IRequestHandler<GetCoursesByDeptId, IList<CourseModel>>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;

        public GetCoursesByDeptIdQuery(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<IList<CourseModel>> Handle(GetCoursesByDeptId request, CancellationToken cancellationToken)
        {
            return await _courseRepository.GetList(x => x.DepartmentId == request.DepartmentId && x.IsActive == true)
                .ProjectTo<CourseModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetCoursesByDeptId : IRequest<IList<CourseModel>>
    {
        public int DepartmentId { get; set; }
    }
}
