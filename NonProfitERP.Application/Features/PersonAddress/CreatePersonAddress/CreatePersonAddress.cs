using AutoMapper;
using MediatR;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.PersonAddress.CreatePersonAddress
{
    using DAL.Entities;
    using NonProfitERP.Application.Mappings;

    public class CreatePersonAddressCommandHandler : IRequestHandler<CreatePersonAddressCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IPersonAddressRepository _peopleAddressRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePersonAddressCommandHandler(IMapper mapper, IPersonAddressRepository peopleAddressRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _peopleAddressRepository = peopleAddressRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<int> Handle(CreatePersonAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PersonAddress>(request);

            _peopleAddressRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreatePersonAddressCommand : IRequest<int>, IMapFrom<PersonAddress>
    {
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
        public bool? IsGovtBuildUp { get; set; }
        public int? HomeStatusId { get; set; }
        public int? LocalityClassId { get; set; }
        public int? ResidentialStatusId { get; set; }
        public int? ResidentialAreaId { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePersonAddressCommand, PersonAddress>();
        }
    }
}
