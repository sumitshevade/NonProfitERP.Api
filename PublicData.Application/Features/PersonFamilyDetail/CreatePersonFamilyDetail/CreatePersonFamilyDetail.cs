using System;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.Data.Interfaces;
using PublicData.Common.Interfaces;

namespace PublicData.Application.Features.PersonFamilyDetail.CreatePersonFamilyDetail
{
    using Data.Entities;
    using PublicData.Application.Mappings;

    public class CreatePersonFamilyDetailQueryHandler : IRequestHandler<CreatePersonFamilyDetailCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IPersonFamilyDetailsRepository _personFamilyDetailsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePersonFamilyDetailQueryHandler(IMapper mapper, IPersonFamilyDetailsRepository personFamilyDetailsRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _personFamilyDetailsRepository = personFamilyDetailsRepository;
        }

        public Task<int> Handle(CreatePersonFamilyDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PersonFamilyDetail>(request);

            _personFamilyDetailsRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreatePersonFamilyDetailCommand : IRequest<int>, IMapFrom<PersonFamilyDetail>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string SchoolName { get; set; }
        public double? MonthlyIncome { get; set; }
        public int PersonId { get; set; }
        public int? RelationId { get; set; }
        public string OtherRelation { get; set; }
        public int? CourseId { get; set; }
        public string OtherCourse { get; set; }
        public string AnyDisability { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePersonFamilyDetailCommand, PersonFamilyDetail>();
        }
    }
}
