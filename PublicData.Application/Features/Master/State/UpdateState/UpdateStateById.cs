using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Application.Mappings;

namespace PublicData.Application.Features.Master.State.UpdateStateById
{
    using DAL.Entities;

    public class UpdateStateCommndHandler : IRequestHandler<UpdateStateCommnd, bool>
    {
        private readonly IStateRepository _stateRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateStateCommndHandler(IStateRepository stateRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _stateRepository = stateRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdateStateCommnd request, CancellationToken cancellationToken)
        {
            var result = _stateRepository.Exists(x => x.Id == request.Id);
            if (!result)
            {
                throw new NotFoundException(nameof(State), request.Id);
            }

            var entity = _mapper.Map<State>(request);
            _stateRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdateStateCommnd : IRequest<bool>, IMapFrom<State>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }
    }
}
