using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using PublicData.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using PublicData.Application.Shared;
using AutoMapper.QueryableExtensions;

namespace PublicData.Application.Features.Master.SubProgram.GetSubPrograms
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
