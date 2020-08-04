using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.Data.Interfaces;
using PublicData.Application.Shared;

namespace PublicData.Application.Features.PersonAchievement.GetPersonAchievementByAchievementId
{
    public class GetPersonAchievementByAchievementIdQueryHandler : IRequestHandler<GetPersonAchievementByAchievementIdQuery, PersonAchievementModel>
    {
        private readonly IMapper _mapper;
        private readonly IPersonAchievementRepository _personAchievementRepository;

        public GetPersonAchievementByAchievementIdQueryHandler(IPersonAchievementRepository personAchievementRepository, IMapper mapper)
        {
            _personAchievementRepository = personAchievementRepository;
            _mapper = mapper;
        }

        public async Task<PersonAchievementModel> Handle(GetPersonAchievementByAchievementIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<PersonAchievementModel>(_personAchievementRepository.GetById(request.AchievementIdId)));
        }
    }

    public class GetPersonAchievementByAchievementIdQuery : IRequest<PersonAchievementModel>
    {
        public int AchievementIdId { get; set; }
    }
}
