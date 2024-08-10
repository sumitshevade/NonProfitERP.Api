using MediatR;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.CourseHead.DeleteCourseHead
{
    using DAL.Entities;

    public class DeleteCourseHeadCommandHandler : IRequestHandler<DeleteCourseHeadCommand, bool>
    {
        private readonly ICourseHeadRepository _courseHeadRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCourseHeadCommandHandler(ICourseHeadRepository courseHeadRepository, IUnitOfWork unitOfWork)
        {
            _courseHeadRepository = courseHeadRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteCourseHeadCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _courseHeadRepository.GetById(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(CourseHead), request.Id);
                }

                entity.IsActive = false;
                _courseHeadRepository.Update(entity);
                _unitOfWork.Commit();

                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeleteCourseHeadCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
