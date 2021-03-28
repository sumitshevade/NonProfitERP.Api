using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Interfaces;
using PublicData.Common.Exceptions;

namespace PublicData.Application.Features.PersonHobbyFavorite.DeletePersonHobbyFavoriteById
{
    using DAL.Entities;

    public class DeletePersonHobbyFavoriteByIdCommandHandler : IRequestHandler<DeletePersonHobbyFavoriteByIdCommand, bool>
    {
        private readonly IPersonHobbyFavoriteRepository _personHobbyFavoriteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonHobbyFavoriteByIdCommandHandler(IPersonHobbyFavoriteRepository personHobbyFavoriteRepository, IUnitOfWork unitOfWork)
        {
            _personHobbyFavoriteRepository = personHobbyFavoriteRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeletePersonHobbyFavoriteByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _personHobbyFavoriteRepository.GetById(request.HFId);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(PersonEducation), request.HFId);
                }

                entity.IsActive = false;
                _personHobbyFavoriteRepository.Update(entity);

                return Task.FromResult(_unitOfWork.Commit());
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeletePersonHobbyFavoriteByIdCommand : IRequest<bool>
    {
        public int HFId { get; set; }
    }
}
