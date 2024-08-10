using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.CourseHead.GetCourseHeads
{
    public class GetCourseHeadsQueryHandler : IRequestHandler<GetCourseHeadsQuery, IList<CourseHeadModel>>
    {
        private readonly IMapper _mapper;
        private readonly ICourseHeadRepository _courseHeadRepository;

        public GetCourseHeadsQueryHandler(ICourseHeadRepository courseHeadRepository, IMapper mapper)
        {
            _mapper = mapper;
            _courseHeadRepository = courseHeadRepository;
        }

        public async Task<IList<CourseHeadModel>> Handle(GetCourseHeadsQuery request, CancellationToken cancellationToken)
        {
            return await _courseHeadRepository.GetList(x => x.IsActive == true)
                .ProjectTo<CourseHeadModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetCourseHeadsQuery : IRequest<IList<CourseHeadModel>>
    {
    }
}
