using MediatR;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.Program.DeleteProgram
{
    using NonProfitERP.DAL.Entities;

    public class DeleteProgramCommandHandler : IRequestHandler<DeleteProgramCommand, bool>
    {
        private readonly IProgramRepository _programRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProgramCommandHandler(IProgramRepository programRepository, IUnitOfWork unitOfWork)
        {
            _programRepository = programRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteProgramCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _programRepository.GetById(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Program), request.Id);
                }

                entity.IsActive = false;
                _programRepository.Update(entity);
                _unitOfWork.Commit();

                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeleteProgramCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
