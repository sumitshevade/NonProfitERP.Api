using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.Data.Interfaces;
using PublicData.Application.Shared;

namespace PublicData.Application.Features.PersonHobbyFavorite.GetPersonHobbyFavoriteByHFId
{
    public class GetPersonHobbyFavoriteByHFIdQueryHandler : IRequestHandler<GetPersonHobbyFavoriteByHFIdQuery, PersonHobbyFavoriteModel>
    {
        private readonly IMapper _mapper;
        private readonly IPersonHobbyFavoriteRepository _personHobbyFavoriteRepository;

        public GetPersonHobbyFavoriteByHFIdQueryHandler(IMapper mapper, IPersonHobbyFavoriteRepository personHobbyFavoriteRepository)
        {
            _personHobbyFavoriteRepository = personHobbyFavoriteRepository;
            _mapper = mapper;
        }

        public async Task<PersonHobbyFavoriteModel> Handle(GetPersonHobbyFavoriteByHFIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<PersonHobbyFavoriteModel>(_personHobbyFavoriteRepository.GetById(request.HFId)));
        }
    }

    public class GetPersonHobbyFavoriteByHFIdQuery : IRequest<PersonHobbyFavoriteModel>
    {
        public int HFId { get; set; }
    }
}
