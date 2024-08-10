using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.Batch.GetBatchesByCourseId
{
    public class GetBatchesByCourseIdQuery : IRequestHandler<GetBatchesByCourseId, IList<BatchModel>>
    {
        private readonly IMapper _mapper;
        private readonly IBatchRepository _batchRepository;

        public GetBatchesByCourseIdQuery(IBatchRepository batchRepository, IMapper mapper)
        {
            _batchRepository = batchRepository;
            _mapper = mapper;
        }

        public async Task<IList<BatchModel>> Handle(GetBatchesByCourseId request, CancellationToken cancellationToken)
        {
            return await _batchRepository.GetList(x => x.CourseId == request.CourseId && x.IsActive == true)
                .ProjectTo<BatchModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetBatchesByCourseId : IRequest<IList<BatchModel>>
    {
        public int CourseId { get; set; }
    }
}
