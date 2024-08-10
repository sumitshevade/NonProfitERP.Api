using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.SubProgram.GetSubPrograms
{
    public class GetSubProgramsQueryHandler : IRequestHandler<GetSubProgramsQuery, IList<SubProgramModel>>
    {
        private readonly IMapper _mapper;
        private readonly ISubProgramRepository _subProgramRepository;

        public GetSubProgramsQueryHandler(ISubProgramRepository subProgramRepository, IMapper mapper)
        {
            _mapper = mapper;
            _subProgramRepository = subProgramRepository;
        }

        public async Task<IList<SubProgramModel>> Handle(GetSubProgramsQuery request, CancellationToken cancellationToken)
        {
            return await _subProgramRepository.GetList(x => x.IsActive == true)
                .ProjectTo<SubProgramModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetSubProgramsQuery : IRequest<IList<SubProgramModel>>
    {
    }
}
