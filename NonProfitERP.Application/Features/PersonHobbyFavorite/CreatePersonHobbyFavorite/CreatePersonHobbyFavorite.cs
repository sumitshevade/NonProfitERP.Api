using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using NonProfitERP.DAL.Interfaces;
using NonProfitERP.Common.Interfaces;

namespace NonProfitERP.Application.Features.PersonHobbyFavorite.CreatePersonHobbyFavorite
{
    using DAL.Entities;
    using NonProfitERP.Application.Mappings;

    public class CreatePersonHobbyFavoriteCommandHandler : IRequestHandler<CreatePersonHobbyFavoriteCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IPersonHobbyFavoriteRepository _personHobbyFavoriteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePersonHobbyFavoriteCommandHandler(IMapper mapper, IPersonHobbyFavoriteRepository personHobbyFavoriteRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _personHobbyFavoriteRepository = personHobbyFavoriteRepository;
        }

        public Task<int> Handle(CreatePersonHobbyFavoriteCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PersonHobbyFavorite>(request);

            _personHobbyFavoriteRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreatePersonHobbyFavoriteCommand : IRequest<int>, IMapFrom<PersonHobbyFavorite>
    {
        public int PersonId { get; set; }
        public int? HobbyFavoriteId { get; set; }
        public string LongText { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePersonHobbyFavoriteCommand, PersonHobbyFavorite>();
        }
    }
}
