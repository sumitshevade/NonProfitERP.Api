using MediatR;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;
using PublicData.DAL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PublicData.Application.Features.PersonFamilyDetail.DeletePersonFamilyDetail
{
    using DAL.Entities;

    public class DeletePersonFamilyDetailByIdCommandHandler : IRequestHandler<DeletePersonFamilyDetailByIdCommand, bool>
    {
        private readonly IPersonFamilyDetailsRepository _personFamilyDetailsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonFamilyDetailByIdCommandHandler(IPersonFamilyDetailsRepository personFamilyDetailsRepository, IUnitOfWork unitOfWork)
        {
            _personFamilyDetailsRepository = personFamilyDetailsRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeletePersonFamilyDetailByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _personFamilyDetailsRepository.GetById(request.FamilyMemberId);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(PersonEducation), request.FamilyMemberId);
                }

                entity.IsActive = false;
                _personFamilyDetailsRepository.Update(entity);

                return Task.FromResult(_unitOfWork.Commit());
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeletePersonFamilyDetailByIdCommand : IRequest<bool>
    {
        public int FamilyMemberId { get; set; }
    }
}
