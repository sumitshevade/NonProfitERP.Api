using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;

namespace PublicData.Application.Features.PersonLanguage.UpdatePersonLanguageByLanguageId
{
    using DAL.Entities;
    using PublicData.Application.Mappings;

    public class UpdatePersonLanguageByLanguageIdCommandHandler : IRequestHandler<UpdatePersonLanguageByLanguageIdCommand, bool>
    {
        private readonly IPersonLanguageRepository _personLanguageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePersonLanguageByLanguageIdCommandHandler(IPersonLanguageRepository personLanguageRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _personLanguageRepository = personLanguageRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdatePersonLanguageByLanguageIdCommand request, CancellationToken cancellationToken)
        {
            var result = _personLanguageRepository.Exists(x => x.Id == request.Id);
            if (result)
            {
                throw new NotFoundException(nameof(PersonLanguage), request.Id);
            }

            var entity = _mapper.Map<PersonLanguage>(request);
            entity.IsActive = true;
            _personLanguageRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdatePersonLanguageByLanguageIdCommand : IRequest<bool>, IMapFrom<PersonLanguage>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int LanguageId { get; set; }
        public string OtherLanguage { get; set; }
        public bool IsMotherTongue { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePersonLanguageByLanguageIdCommand, PersonLanguage>();
        }
    }
}
