using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Application.Shared;

namespace PublicData.Application.Features.Master.Division.GetDivisionById
{
    public class GetDivisionByIdQueryHandler : IRequestHandler<GetDivisionByIdQuery, DivisionModel>
    {
        private readonly IDivisionRepository _divisionRepository;
        private readonly IMapper _mapper;

        public GetDivisionByIdQueryHandler(IDivisionRepository divisionRepository, IMapper mapper)
        {
            _divisionRepository = divisionRepository;
            _mapper = mapper;
        }

        public async Task<DivisionModel> Handle(GetDivisionByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<DivisionModel>(_divisionRepository.GetById(request.Id)));
        }
    }

    public class GetDivisionByIdQuery : IRequest<DivisionModel>
    {
        public int Id { get; set; }
    }
}
