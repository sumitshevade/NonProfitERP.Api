using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;
using AutoMapper;

namespace PublicData.Application.Features.PersonDisability.UpdatePersonDisabilityByDisabilityId
{
    using DAL.Entities;
    using PublicData.Application.Mappings;

    public class UpdatePersonDisabilityByDisabilityIdCommandHandler : IRequestHandler<UpdatePersonDisabilityByDisabilityIdCommand, bool>
    {
        private readonly IPersonDisabilityRepository _personDisabilityRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePersonDisabilityByDisabilityIdCommandHandler(IPersonDisabilityRepository personDisabilityRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _personDisabilityRepository = personDisabilityRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdatePersonDisabilityByDisabilityIdCommand request, CancellationToken cancellationToken)
        {
            var result = _personDisabilityRepository.Exists(x => x.Id == request.Id);
            if (result)
            {
                throw new NotFoundException(nameof(PersonDisability), request.Id);
            }

            var entity = _mapper.Map<PersonDisability>(request);
            entity.IsActive = true;
            _personDisabilityRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdatePersonDisabilityByDisabilityIdCommand : IRequest<bool>, IMapFrom<PersonDisability>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Problem { get; set; }
        public string Detail { get; set; }
        public int? FromYear { get; set; }
        public int? ToYear { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePersonDisabilityByDisabilityIdCommand, PersonDisability>();
        }
    }
}
