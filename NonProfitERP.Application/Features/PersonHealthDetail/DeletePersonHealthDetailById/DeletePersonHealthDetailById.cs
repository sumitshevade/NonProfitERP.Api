using MediatR;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.PersonHealthDetail.DeletePersonHealthDetailById
{
    using DAL.Entities;

    public class DeletePersonHealthDetailByIdCommandHandler : IRequestHandler<DeletePersonHealthDetailByIdCommand, bool>
    {
        private readonly IPersonHealthDetailsRepository _personHealthDetailsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonHealthDetailByIdCommandHandler(IPersonHealthDetailsRepository personHealthDetailsRepository, IUnitOfWork unitOfWork)
        {
            _personHealthDetailsRepository = personHealthDetailsRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeletePersonHealthDetailByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _personHealthDetailsRepository.GetById(request.HealthDetailId);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(PersonHealthDetail), request.HealthDetailId);
                }

                entity.IsActive = false;
                _personHealthDetailsRepository.Update(entity);

                return Task.FromResult(_unitOfWork.Commit());
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeletePersonHealthDetailByIdCommand : IRequest<bool>
    {
        public int HealthDetailId { get; set; }
    }
}
