using AutoMapper;
using MediatR;
using NonProfitERP.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.People.GetPersonById
{
    using NonProfitERP.Application.Shared;

    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, PersonModel>
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _peopleRepository;

        public GetPersonByIdQueryHandler(IMapper mapper, IPersonRepository peopleRepository)
        {
            _mapper = mapper;
            _peopleRepository = peopleRepository;
        }

        public async Task<PersonModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<PersonModel>(_peopleRepository.GetById(request.Id)));
        }
    }

    public class GetPersonByIdQuery : IRequest<PersonModel>
    {
        public int Id { get; set; }
    }
}
