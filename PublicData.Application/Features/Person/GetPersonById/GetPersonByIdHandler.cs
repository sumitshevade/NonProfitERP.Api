using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using PublicData.Data.Interfaces;

namespace PublicData.Application.Features.People.GetPersonById
{
    using PublicData.Application.Shared;

    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, PersonModel>
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _peopleRepository;

        public GetPersonByIdHandler(IMapper mapper, IPersonRepository peopleRepository)
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
