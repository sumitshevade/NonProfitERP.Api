using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using NonProfitERP.DAL.Interfaces;
using NonProfitERP.Application.Shared;

namespace NonProfitERP.Application.Features.Master.State.GetStateById
{
    public class GetStateByIdQueryHandler : IRequestHandler<GetStateByIdQuery, StateModel>
    {
        private readonly IMapper _mapper;
        private readonly IStateRepository _stateRepository;

        public GetStateByIdQueryHandler(IStateRepository stateRepository, IMapper mapper)
        {
            _mapper = mapper;
            _stateRepository = stateRepository;
        }

        public async Task<StateModel> Handle(GetStateByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<StateModel>(_stateRepository.GetById(request.Id)));
        }
    }

    public class GetStateByIdQuery : IRequest<StateModel>
    {
        public int Id { get; set; }
    }
}
