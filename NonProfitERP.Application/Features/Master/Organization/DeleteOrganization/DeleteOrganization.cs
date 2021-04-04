using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;

namespace PublicData.Application.Features.Master.Organization.DeleteOrganization
{
    using DAL.Entities;

    public class DeleteOrganizationCommandHandler : IRequestHandler<DeleteOrganizationCommand, bool>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrganizationCommandHandler(IOrganizationRepository organizationRepository, IUnitOfWork unitOfWork)
        {
            _organizationRepository = organizationRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteOrganizationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _organizationRepository.GetById(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Organization), request.Id);
                }

                entity.IsActive = false;
                _organizationRepository.Update(entity);
                _unitOfWork.Commit();

                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeleteOrganizationCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
