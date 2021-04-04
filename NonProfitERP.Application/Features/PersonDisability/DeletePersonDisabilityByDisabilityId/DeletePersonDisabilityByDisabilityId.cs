using MediatR;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.PersonDisability.DeletePersonDisabilityByDisabilityId
{
    using DAL.Entities;

    public class DeletePersonDisabilityByDisabilityIdCommandHandler : IRequestHandler<DeletePersonDisabilityByDisabilityIdCommand, bool>
    {
        private readonly IPersonDisabilityRepository _personDisabilityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonDisabilityByDisabilityIdCommandHandler(IPersonDisabilityRepository personDisabilityRepository, IUnitOfWork unitOfWork)
        {
            _personDisabilityRepository = personDisabilityRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeletePersonDisabilityByDisabilityIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _personDisabilityRepository.GetById(request.DisabilityId);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(PersonDisability), request.DisabilityId);
                }

                entity.IsActive = false;
                _personDisabilityRepository.Update(entity);

                return Task.FromResult(_unitOfWork.Commit());
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeletePersonDisabilityByDisabilityIdCommand : IRequest<bool>
    {
        public int DisabilityId { get; set; }
    }
}
