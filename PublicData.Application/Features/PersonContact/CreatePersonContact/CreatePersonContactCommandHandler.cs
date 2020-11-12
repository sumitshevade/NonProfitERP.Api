using AutoMapper;
using MediatR;
using PublicData.Common.Interfaces;
using PublicData.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PublicData.Application.Features.PersonContact.CreatePersonContact
{
    using DAL.Entities;
    using PublicData.Application.Mappings;

    public class CreatePersonContactCommandHandler : IRequestHandler<CreatePersonContactCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IPersonContactRepository _personContactRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePersonContactCommandHandler(IMapper mapper, IPersonContactRepository personContactRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _personContactRepository = personContactRepository;
        }

        public Task<int> Handle(CreatePersonContactCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PersonContact>(request);

            _personContactRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreatePersonContactCommand : IRequest<int>, IMapFrom<PersonContact>
    {
        public int PersonId { get; set; }
        public int? ContactTypeId { get; set; }
        public string Detail { get; set; }
        public bool IsDefault { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePersonContactCommand, PersonContact>();
        }
    }
}
