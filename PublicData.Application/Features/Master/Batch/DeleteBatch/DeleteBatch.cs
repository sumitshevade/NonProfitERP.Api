using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;

namespace PublicData.Application.Features.Master.Batch.DeleteBatch
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
                    throw new NotFoundException(nameof(Country), request.Id);
                }

                entity.IsActive = false;
                _batchRepository.Update(entity);
                _unitOfWork.Commit();

                return Task.FromResult(true);
            }
            catch (Exception ex)
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
