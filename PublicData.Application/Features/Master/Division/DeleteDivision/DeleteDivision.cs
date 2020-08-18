using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;

namespace PublicData.Application.Features.Master.Division.DeleteDivision
{
    using DAL.Entities;

    public class DeleteDivisionCommandHandler : IRequestHandler<DeleteDivisionCommand, bool>
    {
        private readonly IDivisionRepository _divisionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDivisionCommandHandler(IDivisionRepository divisionRepository, IUnitOfWork unitOfWork)
        {
            _divisionRepository = divisionRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteDivisionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _divisionRepository.GetById(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Division), request.Id);
                }

                entity.IsActive = false;
                _divisionRepository.Update(entity);
                _unitOfWork.Commit();

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeleteDivisionCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
