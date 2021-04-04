using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Interfaces;

namespace PublicData.Application.Features.PersonSocialMediaAccount.CreatePersonSocialMediaAccount
{
    using DAL.Entities;
    using PublicData.Application.Mappings;

    public class CreatePersonSocialMediaAccountCommandHandler : IRequestHandler<CreatePersonSocialMediaAccountCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IPersonSocialMediaAccountRepository _personSocialMediaAccountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePersonSocialMediaAccountCommandHandler(IMapper mapper, IPersonSocialMediaAccountRepository personSocialMediaAccountRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _personSocialMediaAccountRepository = personSocialMediaAccountRepository;
        }

        public Task<int> Handle(CreatePersonSocialMediaAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PersonSocialMediaAccount>(request);

            _personSocialMediaAccountRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreatePersonSocialMediaAccountCommand : IRequest<int>, IMapFrom<PersonSocialMediaAccount>
    {
        public int PersonId { get; set; }
        public int AccountTypeId { get; set; }
        public string OtherAccountType { get; set; }
        public string Link { get; set; }
        public int TypeOfUserId { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePersonSocialMediaAccountCommand, PersonSocialMediaAccount>();
        }
    }
}
