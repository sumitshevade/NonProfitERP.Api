using MediatR;
using PublicData.Application.Shared;

namespace PublicData.Application.Features.PersonAddress.GetPersonAddressById
{
    public class GetPersonAddressByIdQuery : IRequest<PersonAddressModel>
    {
        public int AddressId { get; set; }
    }
}
