using AutoMapper;
using MediatR;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.Organization.GetOrganizationById
{
    public class GetOrganizationByIdQueryHandler : IRequestHandler<GetOrganizationByIdQuery, OrganizationModel>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;

        public GetOrganizationByIdQueryHandler(IOrganizationRepository organizationRepository, IMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;
        }

        public async Task<OrganizationModel> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<OrganizationModel>(_organizationRepository.GetById(request.Id)));
        }
    }

    public class GetOrganizationByIdQuery : IRequest<OrganizationModel>
    {
        public int Id { get; set; }
    }
}
