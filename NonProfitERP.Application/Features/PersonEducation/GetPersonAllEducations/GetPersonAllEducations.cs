using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.PersonEducation.GetPersonAllEducations
{
    public class GetPersonAllEducationsQueryHandler : IRequestHandler<GetPersonAllEducationsQuery, IList<PersonEducationModel>>
    {
        private readonly IMapper _mapper;
        private readonly IPersonEducationRepository _personEducationRepository;

        public GetPersonAllEducationsQueryHandler(IPersonEducationRepository personEducationRepository, IMapper mapper)
        {
            _personEducationRepository = personEducationRepository;
            _mapper = mapper;
        }

        public async Task<IList<PersonEducationModel>> Handle(GetPersonAllEducationsQuery request, CancellationToken cancellationToken)
        {
            return await _personEducationRepository.GetList(x => x.PersonId == request.PersonId && x.IsActive == true)
                .ProjectTo<PersonEducationModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetPersonAllEducationsQuery : IRequest<IList<PersonEducationModel>>
    {
        public int PersonId { get; set; }
    }
}
