using AutoMapper;
using MediatR;
using NonProfitERP.Application.Mappings;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.Course.UpdateCourseById
{
    using DAL.Entities;

    public class UpdateCourseByIdCommandHandler : IRequestHandler<UpdateCourseByIdCommand, bool>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCourseByIdCommandHandler(ICourseRepository courseRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdateCourseByIdCommand request, CancellationToken cancellationToken)
        {
            var result = _courseRepository.Exists(x => x.Id == request.Id);
            if (!result)
            {
                throw new NotFoundException(nameof(Course), request.Id);
            }

            var entity = _mapper.Map<Course>(request);
            entity.IsActive = true;
            _courseRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdateCourseByIdCommand : IRequest<bool>, IMapFrom<Course>
    {
        public int Id { get; set; }
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
            profile.CreateMap<UpdateCourseByIdCommand, Course>();
        }
    }
}
