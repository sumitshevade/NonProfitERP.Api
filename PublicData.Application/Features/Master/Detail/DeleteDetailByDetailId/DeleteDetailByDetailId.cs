using System;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Interfaces;
using PublicData.Common.Exceptions;

namespace PublicData.Application.Features.Master.Detail.DeleteDetailByDetailId
{
    public class DeleteDetailByDetailIdCommandHandler : IRequestHandler<DeleteDetailByDetailIdCommand, bool>
    {
        private readonly IDetailRepository _detailRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDetailByDetailIdCommandHandler(IDetailRepository detailRepository, IUnitOfWork unitOfWork)
        {
            _detailRepository = detailRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteDetailByDetailIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _detailRepository.GetById(request.DetailId);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Country), request.DetailId);
                }

                entity.IsActive = false;
                _detailRepository.Update(entity);
                _unitOfWork.Commit();

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }

    /// <summary>
    /// Soft delete for detail
    /// </summary>
    public class DeleteDetailByDetailIdCommand : IRequest<bool>
    {
        public int DetailId { get; set; }
    }
}
