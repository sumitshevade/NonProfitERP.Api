using AutoMapper;
using MediatR;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.PersonDisability.CreatePersonDisability
{
    using DAL.Entities;
    using NonProfitERP.Application.Mappings;

    public class CreatePersonDisabilityCommandHandler : IRequestHandler<CreatePersonDisabilityCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IPersonDisabilityRepository _personDisabilityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePersonDisabilityCommandHandler(IMapper mapper, IPersonDisabilityRepository personDisabilityRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _personDisabilityRepository = personDisabilityRepository;
        }

        public Task<int> Handle(CreatePersonDisabilityCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PersonDisability>(request);

            _personDisabilityRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreatePersonDisabilityCommand : IRequest<int>, IMapFrom<PersonDisability>
    {
        public int PersonId { get; set; }
        public string Problem { get; set; }
        public string Detail { get; set; }
        public int? FromYear { get; set; }
        public int? ToYear { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePersonDisabilityCommand, PersonDisability>();
        }
    }
}
