using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using PublicData.DAL.Interfaces;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PublicData.Application.Shared;

namespace PublicData.Application.Features.PersonHobbyFavorite.GetPersonAllHobbyFavorite
{
    public class GetPersonAllHobbyFavoriteQueryHandler : IRequestHandler<GetPersonAllHobbyFavoriteQuery, IList<PersonHobbyFavoriteModel>>
    {
        private readonly IMapper _mapper;
        private readonly IPersonHobbyFavoriteRepository _personHobbyFavoriteRepository;

        public GetPersonAllHobbyFavoriteQueryHandler(IPersonHobbyFavoriteRepository personHobbyFavoriteRepository, IMapper mapper)
        {
            _personHobbyFavoriteRepository = personHobbyFavoriteRepository;
            _mapper = mapper;
        }

        public async Task<IList<PersonHobbyFavoriteModel>> Handle(GetPersonAllHobbyFavoriteQuery request, CancellationToken cancellationToken)
        {
            return await _personHobbyFavoriteRepository.GetList(x => x.PersonId == request.PersonId)
                .ProjectTo<PersonHobbyFavoriteModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetPersonAllHobbyFavoriteQuery : IRequest<IList<PersonHobbyFavoriteModel>>
    {
        public int PersonId { get; set; }
    }
}
