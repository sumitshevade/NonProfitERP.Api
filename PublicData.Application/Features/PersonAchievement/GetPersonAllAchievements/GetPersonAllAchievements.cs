using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using PublicData.Data.Interfaces;
using PublicData.Application.Shared;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace PublicData.Application.Features.PersonAchievement.GetPersonAllAchievements
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
            return await _personAchievementRepository.GetList(x => x.PersonId == request.PersonId)
                .ProjectTo<PersonAchievementModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetPersonAllAchievementsQuery : IRequest<IList<PersonAchievementModel>>
    {
        public int PersonId { get; set; }
    }
}
