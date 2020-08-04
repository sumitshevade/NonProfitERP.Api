using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.Data.Interfaces;
using PublicData.Common.Interfaces;

namespace PublicData.Application.Features.PersonPrivateInformation.CreatePersonPrivateInformation
{
    using Data.Entities;
    using PublicData.Application.Mappings;

    public class CreatePersonPrivateInformationCommandHandler : IRequestHandler<CreatePersonPrivateInformationCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IPersonPrivateInformationRepository _personPrivateInformationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePersonPrivateInformationCommandHandler(IMapper mapper, IPersonPrivateInformationRepository personPrivateInformationRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _personPrivateInformationRepository = personPrivateInformationRepository;
        }

        public Task<int> Handle(CreatePersonPrivateInformationCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PersonPrivateInformation>(request);

            _personPrivateInformationRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreatePersonPrivateInformationCommand : IRequest<int>, IMapFrom<PersonPrivateInformation>
    {
        public int PersonId { get; set; }
        public bool MaritalStatus { get; set; }
        public string AadharCardNo { get; set; }
        public bool IsOwnBicycle { get; set; }
        public int? ReligionId { get; set; }
        public string OtherReligion { get; set; }
        public int? CasteId { get; set; }
        public string OtherCaste { get; set; }
        public int? CategoryId { get; set; }
        public string OtherCategory { get; set; }
        public int? ParentalStatusId { get; set; }
        public string OtherParentalStatus { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePersonPrivateInformationCommand, PersonPrivateInformation>();
        }
    }
}
