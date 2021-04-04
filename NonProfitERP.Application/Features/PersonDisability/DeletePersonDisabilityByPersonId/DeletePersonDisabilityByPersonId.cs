using MediatR;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.PersonDisability.DeletePersonDisabilityByPersonId
{
    public class DeletePersonDisabilityByPersonIdCommandHandler : IRequestHandler<DeletePersonDisabilityByPersonIdCommand, bool>
    {
        private readonly IPersonDisabilityRepository _personDisabilityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonDisabilityByPersonIdCommandHandler(IPersonDisabilityRepository personDisabilityRepository, IUnitOfWork unitOfWork)
        {
            _personDisabilityRepository = personDisabilityRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeletePersonDisabilityByPersonIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _personDisabilityRepository.GetList(x => x.PersonId == request.PersonId).ToList();
                if (entity == null)
                {
                    throw new NotFoundException(nameof(PersonDisability), request.PersonId);
                }

                foreach (var item in entity)
                {
                    item.IsActive = false;
                    _personDisabilityRepository.Update(item);

                    _unitOfWork.Commit();
                }

                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }


    public class DeletePersonDisabilityByPersonIdCommand : IRequest<bool>
    {
        public int PersonId { get; set; }
    }
}
