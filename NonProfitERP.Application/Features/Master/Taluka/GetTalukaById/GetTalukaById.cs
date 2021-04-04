using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using NonProfitERP.DAL.Interfaces;
using NonProfitERP.Application.Shared;

namespace NonProfitERP.Application.Features.Master.Taluka.GetTalukaById
{
    public class GetDistrictByIdQueryHandler : IRequestHandler<GetTalukaByIdQuery, TalukaModel>
    {
        private readonly ITalukaRepository _talukaRepository;
        private readonly IMapper _mapper;

        public GetDistrictByIdQueryHandler(ITalukaRepository talukaRepository, IMapper mapper)
        {
            _talukaRepository = talukaRepository;
            _mapper = mapper;
        }

        public async Task<TalukaModel> Handle(GetTalukaByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<TalukaModel>(_talukaRepository.GetById(request.Id)));
        }
    }

    public class GetTalukaByIdQuery : IRequest<TalukaModel>
    {
        public int Id { get; set; }
    }
}
