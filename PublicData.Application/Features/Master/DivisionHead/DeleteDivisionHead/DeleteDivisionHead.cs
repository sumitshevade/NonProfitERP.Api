using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;

namespace PublicData.Application.Features.Master.DivisionHead.DeleteDivisionHead
{
    using DAL.Entities;

    public class DeleteDivisionHeadCommandHandler : IRequestHandler<DeleteDivisionHeadCommand, bool>
    {
        private readonly IDivisionHeadRepository _divisionHeadRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDivisionHeadCommandHandler(IDivisionHeadRepository divisionHeadRepository, IUnitOfWork unitOfWork)
        {
            _divisionHeadRepository = divisionHeadRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteDivisionHeadCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _divisionHeadRepository.GetById(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Division), request.Id);
                }

                entity.IsActive = false;
                _divisionHeadRepository.Update(entity);
                _unitOfWork.Commit();
                
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeleteDivisionHeadCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
