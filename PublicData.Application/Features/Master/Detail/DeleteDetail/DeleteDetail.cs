using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.Data.Interfaces;
using PublicData.Common.Interfaces;

namespace PublicData.Application.Features.Master.Detail.DeleteDetail
{
    public class DeleteDetailCommandHandler : IRequestHandler<DeleteDetailCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IDetailRepository _detailRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDetailCommandHandler(IMapper mapper, IDetailRepository detailRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _detailRepository = detailRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteDetailCommand request, CancellationToken cancellationToken)
        {
            if(request.Id != 0)
            {
                var detail = _detailRepository.GetById(request.Id);
                detail.IsActive = false;
                _detailRepository.Update(detail);

                _unitOfWork.Commit();
            }

            return Task.FromResult(true);
        }
    }

    /// <summary>
    /// Soft delete for detail
    /// </summary>
    public class DeleteDetailCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
