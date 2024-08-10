using MediatR;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.PersonAchievement.DeletePersonAchievementByPersonId
{
    using DAL.Entities;

    public class DeletePersonAchievementByPersonIdCommandHandler : IRequestHandler<DeletePersonAchievementByPersonIdCommand, bool>
    {
        private readonly IPersonAddressRepository _personAchievementRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonAchievementByPersonIdCommandHandler(IPersonAddressRepository personAchievementRepository, IUnitOfWork unitOfWork)
        {
            _personAchievementRepository = personAchievementRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeletePersonAchievementByPersonIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _personAchievementRepository.GetList(x => x.PersonId == request.PersonId).ToList();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(PersonAchievement), request.PersonId);
                }

                foreach (var item in entity)
                {
                    item.IsActive = false;
                    _personAchievementRepository.Update(item);

                    _unitOfWork.Commit();
                }

                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeletePersonAchievementByPersonIdCommand : IRequest<bool>
    {
        public int PersonId { get; set; }
    }
}
