using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Interfaces;
using PublicData.Common.Exceptions;

namespace PublicData.Application.Features.Master.DepartmentHead.DeleteDepartmentHead
{
    public class DeleteDepartmentHeadCommandHandler : IRequestHandler<DeleteDepartmentHeadCommand, bool>
    {
        private readonly IDepartmentHeadRepository _departmentHeadRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDepartmentHeadCommandHandler(IDepartmentHeadRepository departmentHeadRepository, IUnitOfWork unitOfWork)
        {
            _departmentHeadRepository = departmentHeadRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteDepartmentHeadCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _departmentHeadRepository.GetById(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Country), request.Id);
                }

                entity.IsActive = false;
                _departmentHeadRepository.Update(entity);
                _unitOfWork.Commit();

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeleteDepartmentHeadCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
