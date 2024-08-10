using AutoMapper;
using MediatR;
using NonProfitERP.Application.Mappings;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.CourseHead.CreateCourseHead
{
    using DAL.Entities;

    public class CreateCourseHeadCommandHandler : IRequestHandler<CreateCourseHeadCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ICourseHeadRepository _courseHeadRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCourseHeadCommandHandler(IMapper mapper, ICourseHeadRepository courseHeadRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _courseHeadRepository = courseHeadRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<int> Handle(CreateCourseHeadCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CourseHead>(request);

            entity.IsActive = true;
            _courseHeadRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreateCourseHeadCommand : IRequest<int>, IMapFrom<CourseHead>
    {
        public int PersonId { get; set; }
        public int CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Person Person { get; set; }
        public virtual Course Course { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCourseHeadCommand, CourseHead>();
        }
    }
}
