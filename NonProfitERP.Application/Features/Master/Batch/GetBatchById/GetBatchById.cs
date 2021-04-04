using AutoMapper;
using MediatR;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.Batch.GetBatchById
{
    public class GetBatchByIdQueryHandler : IRequestHandler<GetBatchByIdQuery, BatchModel>
    {
        private readonly IMapper _mapper;
        private readonly IBatchRepository _batchRepository;

        public GetBatchByIdQueryHandler(IBatchRepository batchRepository, IMapper mapper)
        {
            _mapper = mapper;
            _batchRepository = batchRepository;
        }

        public async Task<BatchModel> Handle(GetBatchByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<BatchModel>(_batchRepository.GetById(request.Id)));
        }
    }

    public class GetBatchByIdQuery : IRequest<BatchModel>
    {
        public int Id { get; set; }
    }
}
