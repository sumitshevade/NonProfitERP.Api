using MediatR;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.PersonWorkExperience.DeletePersonWorkExperience
{
    using DAL.Entities;

    public class DeletePersonWorkExperienceByIdCommandHandler : IRequestHandler<DeletePersonWorkExperienceByIdCommand, bool>
    {
        private readonly IPersonWorkExperienceRepository _personWorkExperienceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonWorkExperienceByIdCommandHandler(IPersonWorkExperienceRepository personWorkExperienceRepository, IUnitOfWork unitOfWork)
        {
            _personWorkExperienceRepository = personWorkExperienceRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeletePersonWorkExperienceByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _personWorkExperienceRepository.GetById(request.WorkExpId);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(PersonEducation), request.WorkExpId);
                }

                entity.IsActive = false;
                _personWorkExperienceRepository.Update(entity);

                return Task.FromResult(_unitOfWork.Commit());
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeletePersonWorkExperienceByIdCommand : IRequest<bool>
    {
        public int WorkExpId { get; set; }
    }
}
