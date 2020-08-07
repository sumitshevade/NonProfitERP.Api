using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;

namespace PublicData.Application.Features.PersonPrivateInformation.UpdatePersonPrivateInformation
{
    using DAL.Entities;
    using PublicData.Application.Mappings;

    public class UpdatePersonPrivateInformationQueryHandler : IRequestHandler<UpdatePersonPrivateInformationQuery, bool>
    {
        private readonly IPersonPrivateInformationRepository _personPrivateInformationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePersonPrivateInformationQueryHandler(IPersonPrivateInformationRepository personPrivateInformationRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _personPrivateInformationRepository = personPrivateInformationRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdatePersonPrivateInformationQuery request, CancellationToken cancellationToken)
        {
            var result = _personPrivateInformationRepository.Exists(x => x.Id == request.Id);
            if (result)
            {
                throw new NotFoundException(nameof(PersonPrivateInformation), request.Id);
            }

            var entity = _mapper.Map<PersonPrivateInformation>(request);
            _personPrivateInformationRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdatePersonPrivateInformationQuery : IRequest<bool>, IMapFrom<PersonPrivateInformation>
    {
        public int Id { get; set; }
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
            profile.CreateMap<UpdatePersonPrivateInformationQuery, PersonPrivateInformation>();
        }
    }
}
