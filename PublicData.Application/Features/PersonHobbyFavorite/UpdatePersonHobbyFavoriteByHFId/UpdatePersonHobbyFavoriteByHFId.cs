using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;

namespace PublicData.Application.Features.PersonHobbyFavorite.UpdatePersonHobbyFavoriteByHFId
{
    using DAL.Entities;
    using PublicData.Application.Mappings;

    public class UpdatePersonHobbyFavoriteByHFIdCommandHandler : IRequestHandler<UpdatePersonHobbyFavoriteByHFIdCommand, bool>
    {
        private readonly IPersonHobbyFavoriteRepository _personHobbyFavoriteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePersonHobbyFavoriteByHFIdCommandHandler(IPersonHobbyFavoriteRepository personHobbyFavoriteRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _personHobbyFavoriteRepository = personHobbyFavoriteRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdatePersonHobbyFavoriteByHFIdCommand request, CancellationToken cancellationToken)
        {
            var result = _personHobbyFavoriteRepository.Exists(x => x.Id == request.Id);
            if (!result)
            {
                throw new NotFoundException(nameof(PersonHobbyFavorite), request.Id);
            }

            var entity = _mapper.Map<PersonHobbyFavorite>(request);
            entity.IsActive = true;
            _personHobbyFavoriteRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdatePersonHobbyFavoriteByHFIdCommand : IRequest<bool>, IMapFrom<PersonHobbyFavorite>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int? HobbyFavoriteId { get; set; }
        public string LongText { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePersonHobbyFavoriteByHFIdCommand, PersonHobbyFavorite>();
        }
    }
}
