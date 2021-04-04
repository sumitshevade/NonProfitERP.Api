using AutoMapper;
using MediatR;
using PublicData.Application.Shared;
using PublicData.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PublicData.Application.Features.Master.SubProgram.GetSubProgramByProgramId
{
    public class GetSubProgramByProgramIdQueryHandler : IRequestHandler<GetSubProgramByProgramIdQuery, SubProgramModel>
    {
        private readonly IMapper _mapper;
        private readonly ISubProgramRepository _subProgramRepository;

        public GetSubProgramByProgramIdQueryHandler(ISubProgramRepository subProgramRepository, IMapper mapper)
        {
            _mapper = mapper;
            _subProgramRepository = subProgramRepository;
        }

        public async Task<SubProgramModel> Handle(GetSubProgramByProgramIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<SubProgramModel>(_subProgramRepository.GetById(request.ProgramId)));
        }
    }

    public class GetSubProgramByProgramIdQuery : IRequest<SubProgramModel>
    {
        public int ProgramId { get; set; }
    }
}
