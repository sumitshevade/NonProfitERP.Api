using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using PublicData.DAL.Interfaces;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PublicData.Application.Shared;

namespace PublicData.Application.Features.PersonHealthDetail.GetPersonAllHealthDetails
{

    public class GetPersonAllHealthDetailsQueryHandler : IRequestHandler<GetPersonAllHealthDetailsQuery, IList<PersonHealthDetailModel>>
    {
        private readonly IMapper _mapper;
        private readonly IPersonHealthDetailsRepository _personHealthDetailsRepository;

        public GetPersonAllHealthDetailsQueryHandler(IPersonHealthDetailsRepository personHealthDetailsRepository, IMapper mapper)
        {
            _personHealthDetailsRepository = personHealthDetailsRepository;
            _mapper = mapper;
        }

        public async Task<IList<PersonHealthDetailModel>> Handle(GetPersonAllHealthDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _personHealthDetailsRepository.GetList(x => x.PersonId == request.PersonId && x.IsActive == true)
                .ProjectTo<PersonHealthDetailModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetPersonAllHealthDetailsQuery : IRequest<IList<PersonHealthDetailModel>>
    {
        public int PersonId { get; set; }
    }
}
