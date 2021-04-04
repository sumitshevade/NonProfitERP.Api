using AutoMapper;
using MediatR;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.Header.GetHeaderById
{
    public class GetHeaderByIdQueryHandler : IRequestHandler<GetHeaderByIdQuery, HeaderModel>
    {
        private readonly IHeaderRepository _headerRepository;
        private readonly IMapper _mapper;

        public GetHeaderByIdQueryHandler(IHeaderRepository headerRepository, IMapper mapper)
        {
            _headerRepository = headerRepository;
            _mapper = mapper;
        }

        public async Task<HeaderModel> Handle(GetHeaderByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<HeaderModel>(_headerRepository.GetById(request.Id)));
        }
    }

    public class GetHeaderByIdQuery : IRequest<HeaderModel>
    {
        public int Id { get; set; }
    }
}
