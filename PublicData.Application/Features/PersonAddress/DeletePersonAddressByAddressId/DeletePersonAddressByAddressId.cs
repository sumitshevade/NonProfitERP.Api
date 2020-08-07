using MediatR;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;
using PublicData.DAL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PublicData.Application.Features.PersonAddress.DeletePersonAddressByAddressId
{
    using Data.Entities;

    public class DeletePersonAddressByAddressIdCommandHandler : IRequestHandler<DeletePersonAddressByAddressIdCommand, bool>
    {
        private IPersonAddressRepository _personAddressRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonAddressByAddressIdCommandHandler(IPersonAddressRepository personAddressRepository, IUnitOfWork unitOfWork)
        {
            _personAddressRepository = personAddressRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeletePersonAddressByAddressIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _personAddressRepository.GetById(request.AddressId);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(PersonAddress), request.AddressId);
                }

                entity.IsActive = false;
                _personAddressRepository.Update(entity);

                return Task.FromResult(_unitOfWork.Commit());
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeletePersonAddressByAddressIdCommand : IRequest<bool>
    {
        public int AddressId { get; set; }
    }
}
