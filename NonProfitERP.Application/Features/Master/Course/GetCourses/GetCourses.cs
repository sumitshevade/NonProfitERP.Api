using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.Course.GetCourses
{
    public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, IList<CourseModel>>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;

        public GetCoursesQueryHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        public async Task<IList<CourseModel>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            return await _courseRepository.GetList(x => x.IsActive == true)
                .ProjectTo<CourseModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetCoursesQuery : IRequest<IList<CourseModel>>
    {
    }
}
