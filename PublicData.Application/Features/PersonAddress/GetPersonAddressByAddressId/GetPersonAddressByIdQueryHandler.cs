using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.Data.Interfaces;
using PublicData.Application.Shared;

namespace PublicData.Application.Features.PersonAddress.GetPersonAddressById
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
}
