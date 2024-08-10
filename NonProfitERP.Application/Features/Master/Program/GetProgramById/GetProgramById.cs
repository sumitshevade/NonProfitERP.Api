using AutoMapper;
using MediatR;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.Program.GetProgramById
{
    public class GetProgramByIdQueryHandler : IRequestHandler<GetProgramByIdQuery, ProgramModel>
    {
        private readonly IProgramRepository _programRepository;
        private readonly IMapper _mapper;

        public GetProgramByIdQueryHandler(IProgramRepository programRepository, IMapper mapper)
        {
            _programRepository = programRepository;
            _mapper = mapper;
        }

        public async Task<ProgramModel> Handle(GetProgramByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<ProgramModel>(_programRepository.GetById(request.Id)));
        }
    }

    public class GetProgramByIdQuery : IRequest<ProgramModel>
    {
        public int Id { get; set; }
    }
}
