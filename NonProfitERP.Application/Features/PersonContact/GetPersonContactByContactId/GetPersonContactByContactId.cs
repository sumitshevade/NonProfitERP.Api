using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using NonProfitERP.DAL.Interfaces;
using NonProfitERP.Application.Shared;

namespace NonProfitERP.Application.Features.PersonContact.GetPersonContactByContactId
{
    public class GetPersonContactByContactIdQueryHandler : IRequestHandler<GetPersonContactByContactIdQuery, PersonContactModel>
    {
        private readonly IMapper _mapper;
        private readonly IPersonContactRepository _personContactRepository;

        public GetPersonContactByContactIdQueryHandler(IMapper mapper, IPersonContactRepository personContactRepository)
        {
            _personContactRepository = personContactRepository;
            _mapper = mapper;
        }

        public async Task<PersonContactModel> Handle(GetPersonContactByContactIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<PersonContactModel>(_personContactRepository.GetById(request.ContactId)));
        }
    }

    public class GetPersonContactByContactIdQuery : IRequest<PersonContactModel>
    {
        public int ContactId { get; set; }
    }
}
