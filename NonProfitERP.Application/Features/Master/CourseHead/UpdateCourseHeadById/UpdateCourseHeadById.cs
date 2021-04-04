using MediatR;
using AutoMapper;
using PublicData.Application.Mappings;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;
using PublicData.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace PublicData.Application.Features.Master.CourseHead.UpdateCourseHeadById
{
    using DAL.Entities;

    public class UpdateCourseHeadByIdCommandHandler : IRequestHandler<UpdateCourseHeadByIdCommand, bool>
    {
        private readonly ICourseHeadRepository _courseHeadRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCourseHeadByIdCommandHandler(ICourseHeadRepository courseHeadRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _courseHeadRepository = courseHeadRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdateCourseHeadByIdCommand request, CancellationToken cancellationToken)
        {
            var result = _courseHeadRepository.Exists(x => x.Id == request.Id);
            if (!result)
            {
                throw new NotFoundException(nameof(CourseHead), request.Id);
            }

            var entity = _mapper.Map<CourseHead>(request);
            entity.IsActive = true;
            _courseHeadRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdateCourseHeadByIdCommand : IRequest<bool>, IMapFrom<CourseHead>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Person Person { get; set; }
        public virtual Course Course { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCourseHeadByIdCommand, CourseHead>();
        }
    }
}
