using MediatR;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.Department.DeleteDepartment
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, bool>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDepartmentCommandHandler(IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork)
        {
            _departmentRepository = departmentRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _departmentRepository.GetById(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Country), request.Id);
                }

                entity.IsActive = false;
                _departmentRepository.Update(entity);
                _unitOfWork.Commit();

                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeleteDepartmentCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
