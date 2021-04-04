using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using PublicData.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using PublicData.Application.Shared;
using AutoMapper.QueryableExtensions;

namespace PublicData.Application.Features.People.GetAllPerson
{
    public class GetAllPersonHandler : IRequestHandler<GetAllPersonQuery, IList<PersonModel>>
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _peopleRepository;

        public GetAllPersonHandler(IMapper mapper, IPersonRepository peopleRepository)
        {
            _mapper = mapper;
            _peopleRepository = peopleRepository;
        }

        public async Task<IList<PersonModel>> Handle(GetAllPersonQuery request, CancellationToken cancellationToken)
        {
            return await _peopleRepository.GetList(x => x.IsActive == true)
                .ProjectTo<PersonModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetAllPersonQuery : IRequest<IList<PersonModel>>
    {
    }
}
