using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Interfaces;
using PublicData.Common.Exceptions;

namespace PublicData.Application.Features.PersonAchievement.DeletePersonAchievementByAchievementId
{
    using Data.Entities;

    public class DeletePersonAchievementByAchievementIdCommandHandler : IRequestHandler<DeletePersonAchievementByAchievementIdCommand, bool>
    {
        private IPersonAchievementRepository _personAchievementRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonAchievementByAchievementIdCommandHandler(IPersonAchievementRepository personAchievementRepository, IUnitOfWork unitOfWork)
        {
            _personAchievementRepository = personAchievementRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeletePersonAchievementByAchievementIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _personAchievementRepository.GetById(request.AchievementId);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(PersonAchievement), request.AchievementId);
                }

                entity.IsActive = false;
                _personAchievementRepository.Update(entity);
                
                return Task.FromResult(_unitOfWork.Commit());
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeletePersonAchievementByAchievementIdCommand : IRequest<bool>
    {
        public int AchievementId { get; set; }
    }
}
