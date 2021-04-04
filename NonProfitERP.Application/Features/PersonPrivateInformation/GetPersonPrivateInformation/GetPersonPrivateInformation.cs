using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using NonProfitERP.DAL.Interfaces;
using NonProfitERP.Application.Shared;

namespace NonProfitERP.Application.Features.PersonPrivateInformation.GetPersonPrivateInformation
{
    public class GetPersonPrivateInformationQueryHandler : IRequestHandler<GetPersonPrivateInformationQuery, PersonPrivateInformationModel>
    {
        private readonly IMapper _mapper;
        private readonly IPersonPrivateInformationRepository _personPrivateInformationRepository;

        public GetPersonPrivateInformationQueryHandler(IMapper mapper, IPersonPrivateInformationRepository personPrivateInformationRepository)
        {
            _personPrivateInformationRepository = personPrivateInformationRepository;
            _mapper = mapper;
        }

        public async Task<PersonPrivateInformationModel> Handle(GetPersonPrivateInformationQuery request, CancellationToken cancellationToken)
        {
            var result = await Task.FromResult(_mapper.Map<PersonPrivateInformationModel>(
                _personPrivateInformationRepository.GetFirstOrDefault(x => x.PersonId == request.PersonId)));
            return result;
        }
    }

    public class GetPersonPrivateInformationQuery : IRequest<PersonPrivateInformationModel>
    {
        public int PersonId { get; set; }
    }
}
