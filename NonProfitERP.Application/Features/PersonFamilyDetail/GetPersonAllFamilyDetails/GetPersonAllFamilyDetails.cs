using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.PersonFamilyDetail.GetPersonAllFamilyDetails
{
    public class GetPersonAllFamilyDetailsQueryHandler : IRequestHandler<GetPersonAllFamilyDetailsQuery, IList<PersonFamilyDetailModel>>
    {
        private readonly IMapper _mapper;
        private readonly IPersonFamilyDetailsRepository _personFamilyDetailsRepository;

        public GetPersonAllFamilyDetailsQueryHandler(IPersonFamilyDetailsRepository personFamilyDetailsRepository, IMapper mapper)
        {
            _personFamilyDetailsRepository = personFamilyDetailsRepository;
            _mapper = mapper;
        }

        public async Task<IList<PersonFamilyDetailModel>> Handle(GetPersonAllFamilyDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _personFamilyDetailsRepository.GetList(x => x.PersonId == request.PersonId && x.IsActive == true)
                .ProjectTo<PersonFamilyDetailModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetPersonAllFamilyDetailsQuery : IRequest<IList<PersonFamilyDetailModel>>
    {
        public int PersonId { get; set; }
    }
}
