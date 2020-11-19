using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Interfaces;
using PublicData.Application.Mappings;

namespace PublicData.Application.Features.PersonLanguage.CreatePersonLanguage
{
    using DAL.Entities;

    public class CreatePersonLanguageCommandHandler : IRequestHandler<CreatePersonLanguageCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IPersonLanguageRepository _personLanguageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePersonLanguageCommandHandler(IMapper mapper, IPersonLanguageRepository personLanguageRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _personLanguageRepository = personLanguageRepository;
        }

        public Task<int> Handle(CreatePersonLanguageCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PersonLanguage>(request);

            _personLanguageRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreatePersonLanguageCommand : IRequest<int>, IMapFrom<PersonLanguage>
    {
        public int PersonId { get; set; }
        public int LanguageId { get; set; }
        public string OtherLanguage { get; set; }
        public bool IsMotherTongue { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePersonLanguageCommand, PersonLanguage>();
        }
    }
}
