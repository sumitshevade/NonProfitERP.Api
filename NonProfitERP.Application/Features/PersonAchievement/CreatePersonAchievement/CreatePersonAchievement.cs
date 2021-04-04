using System;
using MediatR;
using AutoMapper;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.PersonAchievement.CreatePersonAchievement
{
    using DAL.Entities;
    using NonProfitERP.Application.Mappings;

    public class CreatePersonAchievementCommandHandler : IRequestHandler<CreatePersonAchievementCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IPersonAchievementRepository _personAchievementRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePersonAchievementCommandHandler(IMapper mapper, IPersonAchievementRepository personAchievementRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _personAchievementRepository = personAchievementRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<int> Handle(CreatePersonAchievementCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PersonAchievement>(request);

            _personAchievementRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreatePersonAchievementCommand : IRequest<int>, IMapFrom<PersonAchievement>
    {
        public int PersonId { get; set; }
        public string Title { get; set; }
        public string GivenBy { get; set; }
        public string Format { get; set; }
        public string Reason { get; set; }
        public int? AwardLevelId { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePersonAchievementCommand, PersonAchievement>();
        }
    }
}
