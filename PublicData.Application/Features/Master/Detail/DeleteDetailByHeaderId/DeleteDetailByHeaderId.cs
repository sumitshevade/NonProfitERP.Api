using MediatR;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;
using PublicData.DAL.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PublicData.Application.Features.Master.Detail.DeleteDetailByHeaderId
{
    public class DeleteDetailByHeaderIdHandler : IRequestHandler<DeleteDetailByHeaderIdCommand, bool>
    {
        private readonly IDetailRepository _detailRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDetailByHeaderIdHandler(IDetailRepository detailRepository, IUnitOfWork unitOfWork)
        {
            _detailRepository = detailRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteDetailByHeaderIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _detailRepository.GetList(x => x.HeaderId == request.HeaderId).ToList();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(PersonContact), request.HeaderId);
                }

                foreach (var item in entity)
                {
                    item.IsActive = false;
                    _detailRepository.Update(item);

                    _unitOfWork.Commit();
                }

                return Task.FromResult(true);
            }
            catch(Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeleteDetailByHeaderIdCommand : IRequest<bool>
    {
        public int HeaderId { get; set; }
    }
}
