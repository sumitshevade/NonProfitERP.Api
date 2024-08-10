using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.PersonContact.GetPersonAllContacts
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
            return await _personContactRepository.GetList(x => x.PersonId == request.PersonId && x.IsActive == true).Include(x => x.ContactTypeDetail)
                .ProjectTo<PersonContactModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetPersonAllContactsQuery : IRequest<IList<PersonContactModel>>
    {
        public int PersonId { get; set; }
    }
}
