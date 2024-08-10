using AutoMapper;
using MediatR;
using NonProfitERP.Application.Mappings;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.Course.CreateCourse
{
    using DAL.Entities;

    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCourseCommandHandler(IMapper mapper, ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<int> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Course>(request);

            entity.IsActive = true;
            _courseRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreateCourseCommand : IRequest<int>, IMapFrom<Course>
    {
        public int? DepartmentId { get; set; }
        public int? ProgramId { get; set; }
        public int? SubProgramId { get; set; }
        public int? HeadId { get; set; }
        public string CourseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string LongText { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCourseCommand, Course>();
        }
    }
}
