using AutoMapper;
using MediatR;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;
using PublicData.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PublicData.Application.Features.PersonAddress.UpdatePersonAddressByAddressId
{
    using DAL.Entities;
    using PublicData.Application.Mappings;

    public class UpdatePersonAddressByAddressIdCommandHandler : IRequestHandler<UpdatePersonAddressByAddressIdCommand, bool>
    {
        private readonly IPersonAddressRepository _peopleAddressRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePersonAddressByAddressIdCommandHandler(IPersonAddressRepository peopleAddressRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _peopleAddressRepository = peopleAddressRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdatePersonAddressByAddressIdCommand request, CancellationToken cancellationToken)
        {
            var result = _peopleAddressRepository.Exists(x => x.Id == request.Id);
            if (!result)
            {
                throw new NotFoundException(nameof(PersonAddress), request.Id);
            }

            var entity = _mapper.Map<PersonAddress>(request);
            _peopleAddressRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdatePersonAddressByAddressIdCommand : IRequest<bool>, IMapFrom<PersonAddress>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string OtherCity { get; set; }
        public int? TalukaId { get; set; }
        public string OtherTaluka { get; set; }
        public int? DistrictId { get; set; }
        public string OtherDistrict { get; set; }
        public string Village { get; set; }
        public bool IsPermanent { get; set; }
        public string RoadName { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string ZipCode { get; set; }
        public int? FromYear { get; set; }
        public int? ToYear { get; set; }
        public int? RoomsInHome { get; set; }
        public bool IsGovtBuildUp { get; set; }
        public int? HomeStatusId { get; set; }
        public int? LocalityClassId { get; set; }
        public int? ResidentialStatusId { get; set; }
        public int? ResidentialAreaId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePersonAddressByAddressIdCommand, PersonAddress>();
        }
    }
}
