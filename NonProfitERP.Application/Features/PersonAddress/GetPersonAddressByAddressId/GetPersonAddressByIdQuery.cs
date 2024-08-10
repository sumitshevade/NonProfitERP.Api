using AutoMapper;
using MediatR;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.PersonAddress.GetPersonAddressById
{
    public class GetPersonAddressByIdQueryHandler : IRequestHandler<GetPersonAddressByIdQuery, PersonAddressModel>
    {
        private readonly IMapper _mapper;
        private readonly IPersonAddressRepository _personAddressRepository;

        public GetPersonAddressByIdQueryHandler(IPersonAddressRepository personAddressRepository, IMapper mapper)
        {
            _personAddressRepository = personAddressRepository;
            _mapper = mapper;
        }

        public async Task<PersonAddressModel> Handle(GetPersonAddressByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<PersonAddressModel>(_personAddressRepository.GetById(request.AddressId)));
        }
    }

    public class GetPersonAddressByIdQuery : IRequest<PersonAddressModel>
    {
        public int AddressId { get; set; }
    }
}
