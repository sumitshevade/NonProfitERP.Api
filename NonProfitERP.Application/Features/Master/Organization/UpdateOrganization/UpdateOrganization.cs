using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;
using PublicData.Application.Mappings;

namespace PublicData.Application.Features.Master.Organization.UpdateOrganization
{
    using DAL.Entities;

    public class UpdateOrganizationCommandHandler : IRequestHandler<UpdateOrganizationCommand, bool>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOrganizationCommandHandler(IOrganizationRepository organizationRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var result = _organizationRepository.Exists(x => x.Id == request.Id);
            if (!result)
            {
                throw new NotFoundException(nameof(Organization), request.Id);
            }

            var entity = _mapper.Map<Organization>(request);
            entity.IsActive = true;
            _organizationRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdateOrganizationCommand : IRequest<bool>, IMapFrom<Organization>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string WebLink { get; set; }
        public string ContactNo { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateOrganizationCommand, Organization>();
        }
    }
}
