using MediatR;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;
using PublicData.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PublicData.Application.Features.PersonEducation.DeletePersonEducationByPersonId
{
    public class DeletePersonEducationByPersonIdCommandHandler : IRequestHandler<DeletePersonEducationByPersonIdCommand, bool>
    {
        private readonly IPersonEducationRepository _personEducationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonEducationByPersonIdCommandHandler(IPersonEducationRepository personEducationRepository, IUnitOfWork unitOfWork)
        {
            _personEducationRepository = personEducationRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeletePersonEducationByPersonIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _personEducationRepository.GetList(x => x.PersonId == request.PersonId).ToList();
                if (entity == null)
                {
                    throw new NotFoundException(nameof(PersonEducation), request.PersonId);
                }

                foreach (var item in entity)
                {
                    item.IsActive = false;
                    _personEducationRepository.Update(item);
                    _unitOfWork.Commit();
                }
                
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeletePersonEducationByPersonIdCommand : IRequest<bool>
    {
        public int PersonId { get; set; }
    }
}
