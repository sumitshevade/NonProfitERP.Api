using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Interfaces;
using PublicData.Common.Exceptions;

namespace PublicData.Application.Features.PersonHealthDetail.DeletePersonHealthDetailById
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
                    throw new NotFoundException(nameof(PersonEducation), request.HealthDetailId);
                }

                entity.IsActive = false;
                _personHealthDetailsRepository.Update(entity);

                return Task.FromResult(_unitOfWork.Commit());
            }
            catch (Exception ex)
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
