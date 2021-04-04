using AutoMapper;
using MediatR;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.SubProgram.GetSubProgramById
{
    public class GetSubProgramByIdQueryHandler : IRequestHandler<GetSubProgramByIdQuery, SubProgramModel>
    {
        private readonly IMapper _mapper;
        private readonly ISubProgramRepository _subProgramRepository;

        public GetSubProgramByIdQueryHandler(ISubProgramRepository subProgramRepository, IMapper mapper)
        {
            _mapper = mapper;
            _subProgramRepository = subProgramRepository;
        }

        public async Task<SubProgramModel> Handle(GetSubProgramByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<SubProgramModel>(_subProgramRepository.GetById(request.Id)));
        }
    }

    public class GetSubProgramByIdQuery : IRequest<SubProgramModel>
    {
        public int Id { get; set; }
    }
}
