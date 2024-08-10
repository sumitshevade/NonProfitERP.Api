using MediatR;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.Batch.DeleteBatch
{
    using DAL.Entities;

    public class DeleteBatchCommandHandler : IRequestHandler<DeleteBatchCommand, bool>
    {
        private readonly IBatchRepository _batchRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBatchCommandHandler(IBatchRepository batchRepository, IUnitOfWork unitOfWork)
        {
            _batchRepository = batchRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteBatchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _batchRepository.GetById(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Batch), request.Id);
                }

                entity.IsActive = false;
                _batchRepository.Update(entity);
                _unitOfWork.Commit();

                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeleteBatchCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
