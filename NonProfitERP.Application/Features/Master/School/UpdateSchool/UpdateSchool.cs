using AutoMapper;
using MediatR;
using NonProfitERP.Application.Mappings;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.School.UpdateSchool
{
    using DAL.Entities;

    public class UpdateSchoolCommandHandler : IRequestHandler<UpdateSchoolCommand, bool>
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSchoolCommandHandler(ISchoolRepository schoolRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _schoolRepository = schoolRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdateSchoolCommand request, CancellationToken cancellationToken)
        {
            var result = _schoolRepository.Exists(x => x.Id == request.Id);
            if (!result)
            {
                throw new NotFoundException(nameof(People), request.Id);
            }

            var entity = _mapper.Map<School>(request);
            entity.IsActive = true;
            _schoolRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdateSchoolCommand : IRequest<bool>, IMapFrom<School>
    {
        public int Id { get; set; }
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
        public int? SyllabusId { get; set; }
        public string LongText { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateSchoolCommand, School>();
        }
    }
}
