using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;
using AutoMapper;

namespace PublicData.Application.Features.PersonContact.UpdatePersonContactByContactId
{
    using Data.Entities;
    using PublicData.Application.Mappings;

    public class UpdatePersonContactByContactIdCommandHandler : IRequestHandler<UpdatePersonContactByContactIdCommand, bool>
    {
        private readonly IPersonContactRepository _personContactRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePersonContactByContactIdCommandHandler(IPersonContactRepository personContactRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _personContactRepository = personContactRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdatePersonContactByContactIdCommand request, CancellationToken cancellationToken)
        {
            var result = _personContactRepository.Exists(x => x.Id == request.Id);
            if (!result)
            {
                throw new NotFoundException(nameof(PersonContact), request.Id);
            }

            var entity = _mapper.Map<PersonContact>(request);
            _personContactRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdatePersonContactByContactIdCommand : IRequest<bool>, IMapFrom<PersonContact>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int? ContactTypeId { get; set; }
        public string Detail { get; set; }
        public bool IsDefault { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePersonContactByContactIdCommand, PersonContact>();
        }
    }
}
