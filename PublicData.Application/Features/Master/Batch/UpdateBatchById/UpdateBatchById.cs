using MediatR;
using AutoMapper;
using PublicData.Application.Mappings;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;
using PublicData.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace PublicData.Application.Features.Master.Batch.UpdateBatchById
{
    using DAL.Entities;

    public class UpdateBatchByIdCommandHandler : IRequestHandler<UpdateBatchByIdCommand, bool>
    {
        private readonly IBatchRepository _batchRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBatchByIdCommandHandler(IBatchRepository batchRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _batchRepository = batchRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdateBatchByIdCommand request, CancellationToken cancellationToken)
        {
            var result = _batchRepository.Exists(x => x.Id == request.Id);
            if (!result)
            {
                throw new NotFoundException(nameof(Batch), request.Id);
            }

            var entity = _mapper.Map<Batch>(request);
            entity.IsActive = true;
            _batchRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdateBatchByIdCommand : IRequest<bool>, IMapFrom<Batch>
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Year { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string LongText { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateBatchByIdCommand, Batch>();
        }
    }
}
