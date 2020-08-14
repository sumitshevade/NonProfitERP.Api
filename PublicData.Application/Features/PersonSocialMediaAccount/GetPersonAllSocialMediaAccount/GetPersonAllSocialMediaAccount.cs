using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using PublicData.DAL.Interfaces;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PublicData.Application.Shared;

namespace PublicData.Application.Features.PersonSocialMediaAccount.GetPersonAllSocialMediaAccount
{
    public class GetPersonAllSocialMediaAccountsQueryHandler : IRequestHandler<GetPersonAllSocialMediaAccountsQuery, IList<PersonSocialMediaAccountModel>>
    {
        private readonly IMapper _mapper;
        private readonly IPersonSocialMediaAccountRepository _personSocialMediaAccountRepository;

        public GetPersonAllSocialMediaAccountsQueryHandler(IPersonSocialMediaAccountRepository personSocialMediaAccountRepository, IMapper mapper)
        {
            _personSocialMediaAccountRepository = personSocialMediaAccountRepository;
            _mapper = mapper;
        }

        public async Task<IList<PersonSocialMediaAccountModel>> Handle(GetPersonAllSocialMediaAccountsQuery request, CancellationToken cancellationToken)
        {
            return await _personSocialMediaAccountRepository.GetList(x => x.PersonId == request.PersonId && x.IsActive == true)
                .ProjectTo<PersonSocialMediaAccountModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetPersonAllSocialMediaAccountsQuery : IRequest<IList<PersonSocialMediaAccountModel>>
    {
        public int PersonId { get; set; }
    }
}
