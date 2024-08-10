using AutoMapper;
using MediatR;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.PersonHealthDetail.GetPersonHealthDetailsByHealthId
{
    public class GetPersonHealthDetailsByHealthIdQueryHandler : IRequestHandler<GetPersonHealthDetailsByHealthIdQuery, PersonHealthDetailModel>
    {
        private readonly IMapper _mapper;
        private readonly IPersonHealthDetailsRepository _personHealthDetailsRepository;

        public GetPersonHealthDetailsByHealthIdQueryHandler(IMapper mapper, IPersonHealthDetailsRepository personHealthDetailsRepository)
        {
            _personHealthDetailsRepository = personHealthDetailsRepository;
            _mapper = mapper;
        }

        public async Task<PersonHealthDetailModel> Handle(GetPersonHealthDetailsByHealthIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<PersonHealthDetailModel>(_personHealthDetailsRepository.GetById(request.HealthId)));
        }
    }

    public class GetPersonHealthDetailsByHealthIdQuery : IRequest<PersonHealthDetailModel>
    {
        public int HealthId { get; set; }
    }
}
