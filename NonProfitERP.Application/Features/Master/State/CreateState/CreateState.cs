using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using NonProfitERP.DAL.Interfaces;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.Application.Mappings;

namespace NonProfitERP.Application.Features.Master.State.CreateState
{
    using DAL.Entities;

    public class CreateStateCommandHandler : IRequestHandler<CreateStateCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IStateRepository _stateRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateStateCommandHandler(IStateRepository stateRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _stateRepository = stateRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<int> Handle(CreateStateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<State>(request);

            _stateRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreateStateCommand : IRequest<int>, IMapFrom<State>
    {
        public string Name { get; set; }
        public int? CountryId { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateStateCommand, State>();
        }
    }
}
