using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.PersonLanguage.GetPersonAllLanguages
{
    public class GetPersonAllLanguagesQueryHandler : IRequestHandler<GetPersonAllLanguagesQuery, IList<PersonLanguageModel>>
    {
        private readonly IMapper _mapper;
        private readonly IPersonLanguageRepository _personLanguageRepository;

        public GetPersonAllLanguagesQueryHandler(IPersonLanguageRepository personLanguageRepository, IMapper mapper)
        {
            _personLanguageRepository = personLanguageRepository;
            _mapper = mapper;
        }

        public async Task<IList<PersonLanguageModel>> Handle(GetPersonAllLanguagesQuery request, CancellationToken cancellationToken)
        {
            return await _personLanguageRepository.GetList(x => x.PersonId == request.PersonId && x.IsActive == true)
                .ProjectTo<PersonLanguageModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }


    public class GetPersonAllLanguagesQuery : IRequest<IList<PersonLanguageModel>>
    {
        public int PersonId { get; set; }
    }
}
