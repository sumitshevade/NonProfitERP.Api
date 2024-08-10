using AutoMapper;
using MediatR;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.PersonAchievement.GetPersonAchievementByAchievementId
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
