using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;
using AutoMapper;
using System;

namespace PublicData.Application.Features.PersonFamilyDetail.UpdatePersonFamilyDetailByFamilyId
{
    using DAL.Entities;
    using PublicData.Application.Mappings;

    public class UpdatePersonFamilyDetailByFamilyIdCommandHandler : IRequestHandler<UpdatePersonFamilyDetailByFamilyIdCommand, bool>
    {
        private readonly IPersonFamilyDetailsRepository _personFamilyDetailsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePersonFamilyDetailByFamilyIdCommandHandler(IPersonFamilyDetailsRepository personFamilyDetailsRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _personFamilyDetailsRepository = personFamilyDetailsRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdatePersonFamilyDetailByFamilyIdCommand request, CancellationToken cancellationToken)
        {
            var result = _personFamilyDetailsRepository.Exists(x => x.Id == request.Id);
            if (result)
            {
                throw new NotFoundException(nameof(PersonFamilyDetail), request.Id);
            }

            var entity = _mapper.Map<PersonFamilyDetail>(request);
            entity.IsActive = true;
            _personFamilyDetailsRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdatePersonFamilyDetailByFamilyIdCommand : IRequest<bool>, IMapFrom<PersonFamilyDetail>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public int? OrganizationId { get; set; }
        public string OtherOrganization { get; set; }
        public string SchoolName { get; set; }
        public double? MonthlyIncome { get; set; }
        public int? RelationId { get; set; }
        public string OtherRelation { get; set; }
        public int? CourseId { get; set; }
        public string OtherCourse { get; set; }
        public string AnyDisability { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePersonFamilyDetailByFamilyIdCommand, PersonFamilyDetail>();
        }
    }
}
