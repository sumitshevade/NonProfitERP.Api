using AutoMapper;
using MediatR;
using PublicData.Application.Shared;
using PublicData.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PublicData.Application.Features.Master.Course.GetCourseById
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, CourseModel>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;

        public GetCourseByIdQueryHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        public async Task<CourseModel> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<CourseModel>(_courseRepository.GetById(request.Id)));
        }
    }

    public class GetCourseByIdQuery : IRequest<CourseModel>
    {
        public int Id { get; set; }
    }
}
