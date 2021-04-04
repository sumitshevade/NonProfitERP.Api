using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using NonProfitERP.DAL.Interfaces;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;

namespace NonProfitERP.Application.Features.Master.Course.DeleteCourse
{
    using DAL.Entities;

    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, bool>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCourseCommandHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _courseRepository.GetById(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Course), request.Id);
                }

                entity.IsActive = false;
                _courseRepository.Update(entity);
                _unitOfWork.Commit();

                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeleteCourseCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
