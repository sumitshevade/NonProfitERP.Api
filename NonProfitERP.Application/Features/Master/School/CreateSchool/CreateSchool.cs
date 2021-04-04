using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using NonProfitERP.DAL.Interfaces;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.Application.Mappings;

namespace NonProfitERP.Application.Features.Master.School.CreateSchool
{
    using DAL.Entities;

    public class CreateSchoolCommandHandler : IRequestHandler<CreateSchoolCommand, int>
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSchoolCommandHandler(ISchoolRepository schoolRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _schoolRepository = schoolRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<int> Handle(CreateSchoolCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<School>(request);

            _schoolRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreateSchoolCommand : IRequest<int>, IMapFrom<School>
    {
        public string Name { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonDesignation { get; set; }
        public string ContactPersonContactNo { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int? TalukaId { get; set; }
        public string OtherTaluka { get; set; }
        public int? DistrictId { get; set; }
        public string OtherDistrict { get; set; }
        public int? StateId { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string WebLink { get; set; }
        public int? SchoolTypeId { get; set; }
        public string LongText { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateSchoolCommand, School>();
        }
    }
}
