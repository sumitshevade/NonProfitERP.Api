using MediatR;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;
using PublicData.DAL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PublicData.Application.Features.Master.Header.DeleteHeader
{
    using DAL.Entities;

    public class DeleteHeaderCommandHandler : IRequestHandler<DeleteHeaderCommand, bool>
    {
        private readonly IHeaderRepository _headerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteHeaderCommandHandler(IHeaderRepository headerRepository, IUnitOfWork unitOfWork)
        {
            _headerRepository = headerRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteHeaderCommand request, CancellationToken cancellationToken)
        {
            // TODO: handle detail delete
            try
            {
                var entity = _headerRepository.GetById(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Header), request.Id);
                }

                entity.IsActive = false;
                _headerRepository.Update(entity);
                _unitOfWork.Commit();

                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeleteHeaderCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
