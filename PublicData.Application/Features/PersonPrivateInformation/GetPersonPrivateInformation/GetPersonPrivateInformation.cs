using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Application.Shared;

namespace PublicData.Application.Features.PersonPrivateInformation.GetPersonPrivateInformation
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
            return await Task.FromResult(
                _mapper.Map<PersonPrivateInformationModel>(_personPrivateInformationRepository.GetSingleOrDefault(x => x.PersonId == request.PersonId))
            );
        }
    }

    public class GetPersonPrivateInformationQuery : IRequest<PersonPrivateInformationModel>
    {
        public int PersonId { get; set; }
    }
}
