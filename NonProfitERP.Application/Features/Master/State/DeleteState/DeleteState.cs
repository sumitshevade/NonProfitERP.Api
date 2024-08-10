using MediatR;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.State.DeleteState
{
    using DAL.Entities;

    public class DeleteStateCommandHandler : IRequestHandler<DeleteStateCommand, bool>
    {
        private readonly IStateRepository _stateRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStateCommandHandler(IStateRepository stateRepository, IUnitOfWork unitOfWork)
        {
            _stateRepository = stateRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteStateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _stateRepository.GetById(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(State), request.Id);
                }

                entity.IsActive = false;
                _stateRepository.Update(entity);
                _unitOfWork.Commit();

                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeleteStateCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
