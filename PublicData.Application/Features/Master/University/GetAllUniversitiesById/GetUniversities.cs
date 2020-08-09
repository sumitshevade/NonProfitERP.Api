using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using System.Collections.Generic;
using PublicData.Application.Shared;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace PublicData.Application.Features.Master.University.GetAllUniversitiesById
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
            return await _universityRepository.GetList()
                .ProjectTo<UniversityModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetAllUniversitiesQuery : IRequest<IList<UniversityModel>>
    {
    }
}
