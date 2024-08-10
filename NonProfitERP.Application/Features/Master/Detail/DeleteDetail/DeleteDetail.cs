using MediatR;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.Detail.DeleteDetail
{
    public class DeleteDetailCommandHandler : IRequestHandler<DeleteDetailCommand, bool>
    {
        private readonly IDetailRepository _detailRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDetailCommandHandler(IDetailRepository detailRepository, IUnitOfWork unitOfWork)
        {
            _detailRepository = detailRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteDetailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _detailRepository.GetById(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Country), request.Id);
                }

                entity.IsActive = false;
                _detailRepository.Update(entity);
                _unitOfWork.Commit();

                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }

    /// <summary>
    /// Soft delete for detail
    /// </summary>
    public class DeleteDetailCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
