using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;

namespace PublicData.Application.Features.Master.Taluka.DeleteTaluka
{
    using DAL.Entities;

    public class DeleteTalukaCommandHandler : IRequestHandler<DeleteTalukaCommand, bool>
    {
        private readonly ITalukaRepository _talukaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTalukaCommandHandler(ITalukaRepository talukaRepository, IUnitOfWork unitOfWork)
        {
            _talukaRepository = talukaRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteTalukaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _talukaRepository.GetById(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(School), request.Id);
                }

                entity.IsActive = false;
                _talukaRepository.Update(entity);
                _unitOfWork.Commit();

                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeleteTalukaCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
