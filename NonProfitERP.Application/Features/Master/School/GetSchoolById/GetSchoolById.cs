using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using NonProfitERP.DAL.Interfaces;
using NonProfitERP.Application.Shared;

namespace NonProfitERP.Application.Features.Master.School.GetSchoolById
{
    public class GetSchoolByIdQueryHandler : IRequestHandler<GetSchoolByIdQuery, SchoolModel>
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper _mapper;

        public GetSchoolByIdQueryHandler(ISchoolRepository schoolRepository, IMapper mapper)
        {
            _schoolRepository = schoolRepository;
            _mapper = mapper;
        }

        public async Task<SchoolModel> Handle(GetSchoolByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<SchoolModel>(_schoolRepository.GetById(request.Id)));
        }
    }

    public class GetSchoolByIdQuery : IRequest<SchoolModel>
    {
        public int Id { get; set; }
    }
}
