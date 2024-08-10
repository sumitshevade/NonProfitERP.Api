using AutoMapper;
using MediatR;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.Detail.GetDetailById
{
    public class GetDetailByIdQueryHandler : IRequestHandler<GetDetailByIdQuery, DetailModel>
    {
        private readonly IMapper _mapper;
        private readonly IDetailRepository _detailRepository;

        public GetDetailByIdQueryHandler(IDetailRepository detailRepository, IMapper mapper)
        {
            _mapper = mapper;
            _detailRepository = detailRepository;
        }

        public async Task<DetailModel> Handle(GetDetailByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<DetailModel>(_detailRepository.GetById(request.Id));
            return await Task.FromResult(result);
        }
    }

    public class GetDetailByIdQuery : IRequest<DetailModel>
    {
        public int Id { get; set; }
    }
}
