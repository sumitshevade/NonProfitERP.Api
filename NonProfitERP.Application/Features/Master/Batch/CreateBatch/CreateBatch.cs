using AutoMapper;
using MediatR;
using NonProfitERP.Application.Mappings;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.Batch.CreateBatch
{
    using DAL.Entities;

    public class CreateBatchCommandHandler : IRequestHandler<CreateBatchCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IBatchRepository _batchRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBatchCommandHandler(IBatchRepository batchRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _batchRepository = batchRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<int> Handle(CreateBatchCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Batch>(request);

            _batchRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreateBatchCommand : IRequest<int>, IMapFrom<Batch>
    {
        public int CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Year { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string LongText { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBatchCommand, Batch>();
        }
    }
}
