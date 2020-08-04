using MediatR;
using System.Collections.Generic;
using PublicData.Data.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using PublicData.Application.Shared;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace PublicData.Application.Features.PersonContact.GetPersonAllContacts
{
    public class GetPersonAllContactsQueryHandler : IRequestHandler<GetPersonAllContactsQuery, IList<PersonContactModel>>
    {
        private readonly IMapper _mapper;
        private readonly IPersonContactRepository _personContactRepository;

        public GetPersonAllContactsQueryHandler(IPersonContactRepository personContactRepository, IMapper mapper)
        {
            _personContactRepository = personContactRepository;
            _mapper = mapper;
        }

        public async Task<IList<PersonContactModel>> Handle(GetPersonAllContactsQuery request, CancellationToken cancellationToken)
        {
            return await _personContactRepository.GetList(x => x.PersonId == request.PersonId)
                .ProjectTo<PersonContactModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetPersonAllContactsQuery : IRequest<IList<PersonContactModel>>
    {
        public int PersonId { get; set; }
    }
}
