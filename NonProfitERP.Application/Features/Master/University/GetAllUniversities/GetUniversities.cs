using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using NonProfitERP.DAL.Interfaces;
using System.Collections.Generic;
using NonProfitERP.Application.Shared;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace NonProfitERP.Application.Features.Master.University.GetAllUniversities
{
    public class GetAllUniversitiesQueryHandler : IRequestHandler<GetAllUniversitiesQuery, IList<UniversityModel>>
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly IMapper _mapper;

        public GetAllUniversitiesQueryHandler(IUniversityRepository universityRepository, IMapper mapper)
        {
            _universityRepository = universityRepository;
            _mapper = mapper;
        }

        public async Task<IList<UniversityModel>> Handle(GetAllUniversitiesQuery request, CancellationToken cancellationToken)
        {
            return await _universityRepository.GetList(x => x.IsActive == true)
                .ProjectTo<UniversityModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetAllUniversitiesQuery : IRequest<IList<UniversityModel>>
    {
    }
}
