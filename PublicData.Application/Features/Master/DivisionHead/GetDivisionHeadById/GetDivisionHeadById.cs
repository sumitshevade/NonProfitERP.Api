using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Application.Shared;

namespace PublicData.Application.Features.Master.DivisionHead.GetDivisionHeadById
{
    public class GetDivisionHeadByIdQueryHandler : IRequestHandler<GetDivisionHeadByIdQuery, DivisionHeadModel>
    {
        private readonly IDivisionHeadRepository _divisionHeadRepository;
        private readonly IMapper _mapper;

        public GetDivisionHeadByIdQueryHandler(IDivisionHeadRepository divisionHeadRepository, IMapper mapper)
        {
            _divisionHeadRepository = divisionHeadRepository;
            _mapper = mapper;
        }

        public async Task<DivisionHeadModel> Handle(GetDivisionHeadByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<DivisionHeadModel>(_divisionHeadRepository.GetById(request.Id)));
        }
    }

    public class GetDivisionHeadByIdQuery : IRequest<DivisionHeadModel>
    {
        public int Id { get; set; }
    }
}
