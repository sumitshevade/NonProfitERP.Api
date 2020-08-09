using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using PublicData.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using PublicData.Application.Shared;
using AutoMapper.QueryableExtensions;

namespace PublicData.Application.Features.Master.Division.GetAllDivisions
{
    public class GetAllDivisionsQueryHandler : IRequestHandler<GetAllDivisionsQuery, IList<DivisionModel>>
    {
        private readonly IDivisionRepository _divisionRepository;
        private readonly IMapper _mapper;

        public GetAllDivisionsQueryHandler(IDivisionRepository divisionRepository, IMapper mapper)
        {
            _divisionRepository = divisionRepository;
            _mapper = mapper;
        }

        public async Task<IList<DivisionModel>> Handle(GetAllDivisionsQuery request, CancellationToken cancellationToken)
        {
            return await _divisionRepository.GetList()
                .ProjectTo<DivisionModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetAllDivisionsQuery : IRequest<IList<DivisionModel>>
    {
    }
}
