using MediatR;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;
using PublicData.DAL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PublicData.Application.Features.PersonDisability.DeletePersonDisabilityByDisabilityId
{
    using Data.Entities;

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
            catch (Exception ex)
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
