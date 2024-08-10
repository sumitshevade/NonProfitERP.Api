using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.Organization.GetOrganizations
{
    public class GetOrganizationsQueryHandler : IRequestHandler<GetOrganizationsQuery, IList<OrganizationModel>>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;

        public GetOrganizationsQueryHandler(IOrganizationRepository organizationRepository, IMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;
        }

        public async Task<IList<OrganizationModel>> Handle(GetOrganizationsQuery request, CancellationToken cancellationToken)
        {
            return await _organizationRepository.GetList(x => x.IsActive == true)
                .ProjectTo<OrganizationModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetOrganizationsQuery : IRequest<IList<OrganizationModel>>
    {
    }
}
