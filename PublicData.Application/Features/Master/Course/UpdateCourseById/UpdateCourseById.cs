using MediatR;
using AutoMapper;
using PublicData.Application.Mappings;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;
using PublicData.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PublicData.Application.Features.Master.Course.UpdateCourseById
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
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCourseByIdCommand, Country>();
        }
    }
}
