using MediatR;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NonProfitERP.Common.Exceptions;

namespace NonProfitERP.Application.Features.PersonAddress.DeletePersonAddressByPersonId
{
    using DAL.Entities;

    public class DeletePersonAddressByPersonIdCommandHandler : IRequestHandler<DeletePersonAddressByPersonIdCommand, bool>
    {
        private readonly IPersonAddressRepository _personAddressRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonAddressByPersonIdCommandHandler(IPersonAddressRepository personAddressRepository, IUnitOfWork unitOfWork)
        {
            _personAddressRepository = personAddressRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeletePersonAddressByPersonIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _personAddressRepository.GetList(x => x.PersonId == request.PersonId).ToList();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(PersonContact), request.PersonId);
                }

                foreach (var item in entity)
                {
                    item.IsActive = false;
                    _personAddressRepository.Update(item);
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

    public class DeletePersonAddressByPersonIdCommand : IRequest<bool>
    {
        public int PersonId { get; set; }
    }
}
