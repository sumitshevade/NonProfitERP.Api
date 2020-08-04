using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.Data.Interfaces;
using PublicData.Application.Shared;

namespace PublicData.Application.Features.PersonLanguage.GetPersonLanguageByLanguageId
{
    public class GetPersonLanguageByLanguageIdQueryHandler : IRequestHandler<GetPersonLanguageByLanguageIdQuery, PersonLanguageModel>
    {
        private readonly IMapper _mapper;
        private readonly IPersonLanguageRepository _personLanguageRepository;

        public GetPersonLanguageByLanguageIdQueryHandler(IMapper mapper, IPersonLanguageRepository personLanguageRepository)
        {
            _personLanguageRepository = personLanguageRepository;
            _mapper = mapper;
        }

        public async Task<PersonLanguageModel> Handle(GetPersonLanguageByLanguageIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<PersonLanguageModel>(_personLanguageRepository.GetById(request.LanguageId)));
        }
    }

    public class GetPersonLanguageByLanguageIdQuery : IRequest<PersonLanguageModel>
    {
        public int LanguageId { get; set; }
    }
}
