using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using PublicData.DAL.Interfaces;
using PublicData.Application.Shared;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace PublicData.Application.Features.PersonAddress.GetPersonAllAddresses
{
    public class GetPersonAllAddressesQueryHandler : IRequestHandler<GetPersonAllAddressesQuery, IList<PersonAddressModel>>
    {
        private readonly IMapper _mapper;
        private readonly IPersonAddressRepository _personAddressRepository;

        public GetPersonAllAddressesQueryHandler(IPersonAddressRepository personAddressRepository, IMapper mapper)
        {
            _personAddressRepository = personAddressRepository;
            _mapper = mapper;
        }

        public async Task<IList<PersonAddressModel>> Handle(GetPersonAllAddressesQuery request, CancellationToken cancellationToken)
        {
            return await _personAddressRepository.GetList(x => x.PersonId == request.PersonId && x.IsActive == true)
                .ProjectTo<PersonAddressModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetPersonAllAddressesQuery : IRequest<IList<PersonAddressModel>>
    {
        public int PersonId { get; set; }
    }
}
