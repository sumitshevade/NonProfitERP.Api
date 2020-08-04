using MediatR;
using PublicData.Application.Shared;
using System.Collections.Generic;

namespace PublicData.Application.Features.PersonAddress.GetPersonAllAddresses
{
    public class GetPersonAllAddressesQuery : IRequest<IList<PersonAddressModel>>
    {
        public int PersonId { get; set; }
    }
}
