using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Interfaces;
using PublicData.Application.Mappings;

namespace PublicData.Application.Features.Master.Organization.CreateOrganization
{
    using DAL.Entities;

    public class CreateOrganizationCommandHandler : IRequestHandler<CreateOrganizationCommand, int>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOrganizationCommandHandler(IOrganizationRepository organizationRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<int> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Organization>(request);

            _organizationRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreateOrganizationCommand : IRequest<int>, IMapFrom<Organization>
    {
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string WebLink { get; set; }
        public string ContactNo { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrganizationCommand, Organization>();
        }
    }
}
