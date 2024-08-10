using MediatR;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.PersonAchievement.DeletePersonAchievementByAchievementId
{
    using DAL.Entities;

    public class DeletePersonAchievementByAchievementIdCommandHandler : IRequestHandler<DeletePersonAchievementByAchievementIdCommand, bool>
    {
        private readonly IPersonAchievementRepository _personAchievementRepository;
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
            catch (Exception)
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
