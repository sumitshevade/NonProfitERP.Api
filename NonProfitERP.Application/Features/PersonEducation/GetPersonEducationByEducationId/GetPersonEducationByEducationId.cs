using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using NonProfitERP.DAL.Interfaces;
using NonProfitERP.Application.Shared;

namespace NonProfitERP.Application.Features.PersonEducation.GetPersonEducationByEducationId
{
    public class GetPersonEducationByEducationIdQueryHandler : IRequestHandler<GetPersonEducationByEducationIdQuery, PersonEducationModel>
    {
        private readonly IMapper _mapper;
        private readonly IPersonEducationRepository _personEducationRepository;

        public GetPersonEducationByEducationIdQueryHandler(IMapper mapper, IPersonEducationRepository personEducationRepository)
        {
            _personEducationRepository = personEducationRepository;
            _mapper = mapper;
        }

        public async Task<PersonEducationModel> Handle(GetPersonEducationByEducationIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<PersonEducationModel>(_personEducationRepository.GetById(request.EducationId)));
        }
    }

    public class GetPersonEducationByEducationIdQuery : IRequest<PersonEducationModel>
    {
        public int EducationId { get; set; }
    }
}
