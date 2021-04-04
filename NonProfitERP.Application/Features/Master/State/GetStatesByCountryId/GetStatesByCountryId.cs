using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.State.GetStatesByCountryId
{
    public class GetStatesByCountryIdQueryHandler : IRequestHandler<GetStatesByCountryIdQuery, IList<StateModel>>
    {
        private readonly IMapper _mapper;
        private readonly IStateRepository _stateRepository;

        public GetStatesByCountryIdQueryHandler(IStateRepository stateRepository, IMapper mapper)
        {
            _stateRepository = stateRepository;
            _mapper = mapper;
        }

        public async Task<IList<StateModel>> Handle(GetStatesByCountryIdQuery request, CancellationToken cancellationToken)
        {
            return await _stateRepository.GetList(x => x.CountryId == request.CountryId && x.IsActive == true)
                .ProjectTo<StateModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetStatesByCountryIdQuery : IRequest<IList<StateModel>>
    {
        public int CountryId { get; set; }
    }
}
