using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.Course.GetCoursesBySubProgId
{
    public class GetCoursesBySubProgIdQuery : IRequestHandler<GetCoursesBySubProgId, IList<CourseModel>>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;

        public GetCoursesBySubProgIdQuery(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<IList<CourseModel>> Handle(GetCoursesBySubProgId request, CancellationToken cancellationToken)
        {
            return await _courseRepository.GetList(x => x.SubProgramId == request.SubProrgamId && x.IsActive == true)
                .ProjectTo<CourseModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetCoursesBySubProgId : IRequest<IList<CourseModel>>
    {
        public int SubProrgamId { get; set; }
    }
}
