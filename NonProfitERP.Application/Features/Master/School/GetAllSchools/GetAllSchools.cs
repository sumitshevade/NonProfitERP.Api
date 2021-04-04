using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using PublicData.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using PublicData.Application.Shared;
using AutoMapper.QueryableExtensions;

namespace PublicData.Application.Features.Master.School.GetAllSchools
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
