using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using NonProfitERP.DAL.Interfaces;
using NonProfitERP.Application.Shared;

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
