using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using PublicData.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using PublicData.Application.Shared;
using AutoMapper.QueryableExtensions;

namespace PublicData.Application.Features.Master.Course.GetCourses
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
