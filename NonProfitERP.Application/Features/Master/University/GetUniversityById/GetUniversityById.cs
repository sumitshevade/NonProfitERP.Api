using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using NonProfitERP.DAL.Interfaces;
using NonProfitERP.Application.Shared;

namespace NonProfitERP.Application.Features.Master.University.GetUniversityById
{
    public class GetUniversityByIdQueryHandler : IRequestHandler<GetUniversityByIdQuery, UniversityModel>
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly IMapper _mapper;

        public GetUniversityByIdQueryHandler(IUniversityRepository universityRepository, IMapper mapper)
        {
            _universityRepository = universityRepository;
            _mapper = mapper;
        }

        public async Task<UniversityModel> Handle(GetUniversityByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<UniversityModel>(_universityRepository.GetById(request.Id)));
        }
    }

    public class GetUniversityByIdQuery : IRequest<UniversityModel>
    {
        public int Id { get; set; }
    }
}
