using MediatR;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.PersonContact.DeletePersonContactByPersonId
{
    using DAL.Entities;

    public class DeletePersonContactByPersonIdCommandHandler : IRequestHandler<DeletePersonContactByPersonIdCommand, bool>
    {
        private IPersonContactRepository _personContactRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonContactByPersonIdCommandHandler(IPersonContactRepository personContactRepository, IUnitOfWork unitOfWork)
        {
            _personContactRepository = personContactRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeletePersonContactByPersonIdCommand request, CancellationToken cancellationToken)
        {
            var entity = _personContactRepository.GetList(x => x.PersonId == request.PersonId).ToList();

            if (entity == null)
            {
                throw new NotFoundException(nameof(PersonContact), request.PersonId);
            }

            foreach (var item in entity)
            {
                item.IsActive = false;
                _personContactRepository.Update(item);
                _unitOfWork.Commit();
            }

            return Task.FromResult(true);
        }
    }

    public class DeletePersonContactByPersonIdCommand : IRequest<bool>
    {
        public int PersonId { get; set; }
    }
}
