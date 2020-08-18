using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Interfaces;
using PublicData.Common.Exceptions;

namespace PublicData.Application.Features.PersonLanguage.DeletePersonLanguage
{
    using DAL.Entities;

    public class DeletePersonLanguageByIdCommandHandler : IRequestHandler<DeletePersonLanguageByIdCommand, bool>
    {
        private readonly IPersonLanguageRepository _personLanguageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonLanguageByIdCommandHandler(IPersonLanguageRepository personLanguageRepository, IUnitOfWork unitOfWork)
        {
            _personLanguageRepository = personLanguageRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeletePersonLanguageByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _personLanguageRepository.GetById(request.PersonLanguageId);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(PersonEducation), request.PersonLanguageId);
                }

                entity.IsActive = false;
                _personLanguageRepository.Update(entity);

                return Task.FromResult(_unitOfWork.Commit());
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeletePersonLanguageByIdCommand : IRequest<bool>
    {
        public int PersonLanguageId { get; set; }
    }
}
