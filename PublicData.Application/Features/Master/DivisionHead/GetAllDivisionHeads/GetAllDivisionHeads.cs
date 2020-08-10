using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using PublicData.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using PublicData.Application.Shared;
using AutoMapper.QueryableExtensions;

namespace PublicData.Application.Features.Master.DivisionHead.GetAllDivisionHeads
{
    public class GetAllDivisionHeadsQueryHandler : IRequestHandler<GetAllDivisionHeadsQuery, IList<DivisionHeadModel>>
    {
        private readonly IDivisionHeadRepository _divisionHeadRepository;
        private readonly IMapper _mapper;

        public GetAllDivisionHeadsQueryHandler(IDivisionHeadRepository divisionHeadRepository, IMapper mapper)
        {
            _divisionHeadRepository = divisionHeadRepository;
            _mapper = mapper;
        }

        public async Task<IList<DivisionHeadModel>> Handle(GetAllDivisionHeadsQuery request, CancellationToken cancellationToken)
        {
            return await _divisionHeadRepository.GetList()
                .ProjectTo<DivisionHeadModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetAllDivisionHeadsQuery : IRequest<IList<DivisionHeadModel>>
    {
    }
}
