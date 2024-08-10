using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.School.GetAllSchools
{
    public class GetAllSchoolsQueryHandler : IRequestHandler<GetAllSchoolsQuery, IList<SchoolModel>>
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper _mapper;

        public GetAllSchoolsQueryHandler(ISchoolRepository schoolRepository, IMapper mapper)
        {
            _schoolRepository = schoolRepository;
            _mapper = mapper;
        }

        public async Task<IList<SchoolModel>> Handle(GetAllSchoolsQuery request, CancellationToken cancellationToken)
        {
            return await _schoolRepository.GetList(x => x.IsActive == true)
                .ProjectTo<SchoolModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetAllSchoolsQuery : IRequest<IList<SchoolModel>>
    {
    }
}
