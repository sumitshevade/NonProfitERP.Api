using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using NonProfitERP.DAL.Interfaces;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.Application.Mappings;

namespace NonProfitERP.Application.Features.PersonSocialMediaAccount.UpdatePersonSocialMediaAccountByAccountId
{
    using DAL.Entities;

    public class UpdatePersonSocialMediaAccountQueryHandler : IRequestHandler<UpdatePersonSocialMediaAccountQuery, bool>
    {
        private readonly IPersonSocialMediaAccountRepository _personSocialMediaAccountRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePersonSocialMediaAccountQueryHandler(IPersonSocialMediaAccountRepository personSocialMediaAccountRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _personSocialMediaAccountRepository = personSocialMediaAccountRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdatePersonSocialMediaAccountQuery request, CancellationToken cancellationToken)
        {
            var result = _personSocialMediaAccountRepository.Exists(x => x.Id == request.Id);
            if (!result)
            {
                throw new NotFoundException(nameof(PersonSocialMediaAccount), request.Id);
            }

            var entity = _mapper.Map<PersonSocialMediaAccount>(request);
            entity.IsActive = true;
            _personSocialMediaAccountRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdatePersonSocialMediaAccountQuery : IRequest<bool>, IMapFrom<PersonSocialMediaAccount>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int AccountTypeId { get; set; }
        public string OtherAccountType { get; set; }
        public string Link { get; set; }
        public int TypeOfUserId { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePersonSocialMediaAccountQuery, PersonSocialMediaAccount>();
        }
    }
}
