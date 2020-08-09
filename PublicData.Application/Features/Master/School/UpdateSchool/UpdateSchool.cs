using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;
using PublicData.Application.Mappings;

namespace PublicData.Application.Features.Master.School.UpdateSchool
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
            _schoolRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdateSchoolCommand : IRequest<bool>, IMapFrom<School>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonContactNo { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public int? SchoolTypeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<School, UpdateSchoolCommand>();
        }
    }
}
