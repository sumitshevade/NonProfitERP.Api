using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.PersonAchievement.GetPersonAllAchievements
{
    public class GetPersonAllAchievementsQueryHandler : IRequestHandler<GetPersonAllAchievementsQuery, IList<PersonAchievementModel>>
    {
        private readonly IMapper _mapper;
        private readonly IPersonAchievementRepository _personAchievementRepository;

        public GetPersonAllAchievementsQueryHandler(IPersonAchievementRepository personAchievementRepository, IMapper mapper)
        {
            _personAchievementRepository = personAchievementRepository;
            _mapper = mapper;
        }

        public async Task<IList<PersonAchievementModel>> Handle(GetPersonAllAchievementsQuery request, CancellationToken cancellationToken)
        {
            return await _personAchievementRepository.GetList(x => x.PersonId == request.PersonId && x.IsActive == true)
                .ProjectTo<PersonAchievementModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetPersonAllAchievementsQuery : IRequest<IList<PersonAchievementModel>>
    {
        public int PersonId { get; set; }
    }
}
