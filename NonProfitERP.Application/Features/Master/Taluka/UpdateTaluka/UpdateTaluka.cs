using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;
using PublicData.Application.Mappings;

namespace PublicData.Application.Features.Master.Taluka.UpdateTaluka
{
    using DAL.Entities;

    public class UpdateTalukaCommandHandler : IRequestHandler<UpdateTalukaCommand, bool>
    {
        private readonly ITalukaRepository _talukaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTalukaCommandHandler(ITalukaRepository talukaRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _talukaRepository = talukaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdateTalukaCommand request, CancellationToken cancellationToken)
        {
            var result = _talukaRepository.Exists(x => x.Id == request.Id);
            if (!result)
            {
                throw new NotFoundException(nameof(People), request.Id);
            }

            var entity = _mapper.Map<Taluka>(request);
            entity.IsActive = true;
            _talukaRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdateTalukaCommand : IRequest<bool>, IMapFrom<Taluka>
    {
        public int Id { get; set; }
        public int? DistrictId { get; set; }
        public string Name { get; set; }
        public string LongText { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTalukaCommand, Taluka>();
        }
    }
}
