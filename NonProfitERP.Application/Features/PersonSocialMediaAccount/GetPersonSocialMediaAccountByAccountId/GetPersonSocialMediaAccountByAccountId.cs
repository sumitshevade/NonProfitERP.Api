using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using NonProfitERP.DAL.Interfaces;
using NonProfitERP.Application.Shared;

namespace NonProfitERP.Application.Features.PersonSocialMediaAccount.GetPersonSocialMediaAccountByAccountId
{
    public class GetPersonSocialMediaAccountByAccountIdQueryHandler : IRequestHandler<GetPersonSocialMediaAccountByAccountIdQuery, PersonSocialMediaAccountModel>
    {
        private readonly IMapper _mapper;
        private readonly IPersonSocialMediaAccountRepository _personSocialMediaAccountRepository;

        public GetPersonSocialMediaAccountByAccountIdQueryHandler(IPersonSocialMediaAccountRepository personSocialMediaAccountRepository, IMapper mapper)
        {
            _personSocialMediaAccountRepository = personSocialMediaAccountRepository;
            _mapper = mapper;
        }

        public async Task<PersonSocialMediaAccountModel> Handle(GetPersonSocialMediaAccountByAccountIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<PersonSocialMediaAccountModel>(_personSocialMediaAccountRepository.GetById(request.SocialMediaAccountId)));
        }
    }

    public class GetPersonSocialMediaAccountByAccountIdQuery : IRequest<PersonSocialMediaAccountModel>
    {
        public int SocialMediaAccountId { get; set; }
    }
}
