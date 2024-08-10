using MediatR;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.SubProgram.DeleteSubProgram
{
    using DAL.Entities;

    public class DeleteSubProgramCommandHandler : IRequestHandler<DeleteSubProgramCommand, bool>
    {
        private readonly ISubProgramRepository _subProgramRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSubProgramCommandHandler(ISubProgramRepository subProgramRepository, IUnitOfWork unitOfWork)
        {
            _subProgramRepository = subProgramRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteSubProgramCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _subProgramRepository.GetById(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(SubProgram), request.Id);
                }

                entity.IsActive = false;
                _subProgramRepository.Update(entity);
                _unitOfWork.Commit();

                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeleteSubProgramCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
