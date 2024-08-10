using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.PersonAddress.GetPersonAllAddresses
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
