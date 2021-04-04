using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using NonProfitERP.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;
using AutoMapper.QueryableExtensions;

namespace NonProfitERP.Application.Features.Master.Program.GetAllPrograms
{
    public class GetAllProgramsQueryHandler : IRequestHandler<GetAllProgramsQuery, IList<ProgramModel>>
    {
        private readonly IProgramRepository _programRepository;
        private readonly IMapper _mapper;

        public GetAllProgramsQueryHandler(IProgramRepository programRepository, IMapper mapper)
        {
            _programRepository = programRepository;
            _mapper = mapper;
        }

        public async Task<IList<ProgramModel>> Handle(GetAllProgramsQuery request, CancellationToken cancellationToken)
        {
            return await _programRepository.GetList(x => x.IsActive == true)
                .ProjectTo<ProgramModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetAllProgramsQuery : IRequest<IList<ProgramModel>>
    {
    }
}
