using MediatR;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.PersonContact.DeletePersonContactByContactId
{
    using DAL.Entities;

    public class DeletePersonContactByContactIdCommandHandler : IRequestHandler<DeletePersonContactByContactIdCommand, bool>
    {
        private readonly IPersonContactRepository _personContactRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonContactByContactIdCommandHandler(IPersonContactRepository personContactRepository, IUnitOfWork unitOfWork)
        {
            _personContactRepository = personContactRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeletePersonContactByContactIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _personContactRepository.GetById(request.ContactId);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(PersonContact), request.ContactId);
                }

                entity.IsActive = false;
                _personContactRepository.Update(entity);

                return Task.FromResult(_unitOfWork.Commit());
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeletePersonContactByContactIdCommand : IRequest<bool>
    {
        public int ContactId { get; set; }
    }
}
