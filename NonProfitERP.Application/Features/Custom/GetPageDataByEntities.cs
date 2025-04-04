using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NonProfitERP.DAL.Entities;
using NonProfitERP.DAL.Interfaces;

namespace NonProfitERP.Application.Features.Custom
{
    public class GetPageDataByEntitiesHandler : IRequestHandler<GetPageDataByEntitiesQuery, Root>
    {
        private readonly IMapper _mapper;
        private readonly ICustomRepository _repository;

        public GetPageDataByEntitiesHandler(ICustomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Root> Handle(GetPageDataByEntitiesQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetPageData(request.Entities);

            return result;
        }
    }

    public class GetPageDataByEntitiesQuery : IRequest<Root>
    {
        public string Entities { get; set; }
    }
}
