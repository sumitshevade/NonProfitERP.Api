using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.Course.GetCoursesByProgId
{
    public class GetCoursesByProgIdQuery : IRequestHandler<GetCoursesByProgId, IList<CourseModel>>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;

        public GetCoursesByProgIdQuery(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<IList<CourseModel>> Handle(GetCoursesByProgId request, CancellationToken cancellationToken)
        {
            return await _courseRepository.GetList(x => x.ProgramId == request.ProgramId && x.IsActive == true)
                .ProjectTo<CourseModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetCoursesByProgId : IRequest<IList<CourseModel>>
    {
        public int ProgramId { get; set; }
    }
}
