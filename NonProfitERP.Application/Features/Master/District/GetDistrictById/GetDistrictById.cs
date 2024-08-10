using AutoMapper;
using MediatR;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.District.GetDistrictById
{
    public class GetDistrictByIdQueryHandler : IRequestHandler<GetDistrictByIdQuery, DistrictModel>
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IMapper _mapper;

        public GetDistrictByIdQueryHandler(IDistrictRepository districtRepository, IMapper mapper)
        {
            _districtRepository = districtRepository;
            _mapper = mapper;
        }

        public async Task<DistrictModel> Handle(GetDistrictByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<DistrictModel>(_districtRepository.GetById(request.Id)));
        }
    }

    public class GetDistrictByIdQuery : IRequest<DistrictModel>
    {
        public int Id { get; set; }
    }
}
