using MediatR;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;
using PublicData.DAL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PublicData.Application.Features.PersonEducation.DeletePersonEducationByEducationId
{
    using DAL.Entities;

    public class DeletePersonEducationByEducationIdCommandHandler : IRequestHandler<DeletePersonEducationByEducationIdCommand, bool>
    {
        private readonly IPersonEducationRepository _personEducationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonEducationByEducationIdCommandHandler(IPersonEducationRepository personEducationRepository, IUnitOfWork unitOfWork)
        {
            _personEducationRepository = personEducationRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeletePersonEducationByEducationIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _personEducationRepository.GetById(request.EducationId);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(PersonEducation), request.EducationId);
                }

                entity.IsActive = false;
                _personEducationRepository.Update(entity);

                return Task.FromResult(_unitOfWork.Commit());
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeletePersonEducationByEducationIdCommand : IRequest<bool>
    {
        public int EducationId { get; set; }
    }
}
