using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;

namespace PublicData.Application.Features.Master.University.DeleteUniversity
{
    using DAL.Entities;

    public class DeleteUniversityCommandHandler : IRequestHandler<DeleteUniversityCommand, bool>
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUniversityCommandHandler(IUniversityRepository universityRepository, IUnitOfWork unitOfWork)
        {
            _universityRepository = universityRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteUniversityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _universityRepository.GetById(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(University), request.Id);
                }

                entity.IsActive = false;
                _universityRepository.Update(entity);
                _unitOfWork.Commit();

                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeleteUniversityCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
