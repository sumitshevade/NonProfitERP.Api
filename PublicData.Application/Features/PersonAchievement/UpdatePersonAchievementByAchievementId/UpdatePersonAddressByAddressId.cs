using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;
using System;

namespace PublicData.Application.Features.PersonAchievement.UpdatePersonAchievementByAchievementId
{
    using DAL.Entities;
    using PublicData.Application.Mappings;

    public class UpdatePersonAchievementByAchievementIdCommandHandler : IRequestHandler<UpdatePersonAchievementByAchievementIdCommand, bool>
    {
        private readonly IPersonAchievementRepository _personAchievementRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePersonAchievementByAchievementIdCommandHandler(IPersonAchievementRepository personAchievementRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _personAchievementRepository = personAchievementRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdatePersonAchievementByAchievementIdCommand request, CancellationToken cancellationToken)
        {
            var result = _personAchievementRepository.Exists(x => x.Id == request.Id);
            if (!result)
            {
                throw new NotFoundException(nameof(People), request.Id);
            }

            var entity = _mapper.Map<PersonAchievement>(request);
            _personAchievementRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdatePersonAchievementByAchievementIdCommand : IRequest<bool>, IMapFrom<UpdatePersonAchievementByAchievementIdCommand>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Title { get; set; }
        public string GivenBy { get; set; }
        public string Format { get; set; }
        public string Reason { get; set; }
        public int? AwardLevelId { get; set; }
        public DateTime? ReceivedDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePersonAchievementByAchievementIdCommand, PersonAchievement>();
        }
    }
}
