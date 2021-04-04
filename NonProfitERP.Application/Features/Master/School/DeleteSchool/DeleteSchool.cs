using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;

namespace PublicData.Application.Features.Master.School.DeleteSchool
{
    using DAL.Entities;

    public class DeleteSchoolCommandHandler : IRequestHandler<DeleteSchoolCommand, bool>
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSchoolCommandHandler(ISchoolRepository schoolRepository, IUnitOfWork unitOfWork)
        {
            _schoolRepository = schoolRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteSchoolCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _schoolRepository.GetById(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(School), request.Id);
                }

                entity.IsActive = false;
                _schoolRepository.Update(entity);
                _unitOfWork.Commit();

                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeleteSchoolCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
