using AutoMapper;
using MediatR;
using PublicData.Application.Shared;
using PublicData.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PublicData.Application.Features.Master.CourseHead.GetCourseHeadById
{
    public class GetCourseHeadByIdQueryHandler : IRequestHandler<GetCourseHeadByIdQuery, CourseHeadModel>
    {
        private readonly IMapper _mapper;
        private readonly ICourseHeadRepository _courseHeadRepository;

        public GetCourseHeadByIdQueryHandler(ICourseHeadRepository courseHeadRepository, IMapper mapper)
        {
            _mapper = mapper;
            _courseHeadRepository = courseHeadRepository;
        }

        public async Task<CourseHeadModel> Handle(GetCourseHeadByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<CourseHeadModel>(_courseHeadRepository.GetById(request.Id)));
        }
    }

    public class GetCourseHeadByIdQuery : IRequest<CourseHeadModel>
    {
        public int Id { get; set; }
    }
}
