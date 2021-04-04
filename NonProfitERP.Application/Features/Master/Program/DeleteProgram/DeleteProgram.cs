using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;

namespace PublicData.Application.Features.Master.Program.DeleteProgram
{
    using PublicData.DAL.Entities;

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
