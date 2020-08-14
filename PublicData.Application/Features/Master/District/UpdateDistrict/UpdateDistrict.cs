using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;
using PublicData.Application.Mappings;

namespace PublicData.Application.Features.Master.District.UpdateDistrict
{
    using DAL.Entities;

    public class UpdateDistrictCommandHandler : IRequestHandler<UpdateDistrictCommand, bool>
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDistrictCommandHandler(IDistrictRepository districtRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _districtRepository = districtRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdateDistrictCommand request, CancellationToken cancellationToken)
        {
            var result = _districtRepository.Exists(x => x.Id == request.Id);
            if (!result)
            {
                throw new NotFoundException(nameof(People), request.Id);
            }

            var entity = _mapper.Map<District>(request);
            _districtRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdateDistrictCommand : IRequest<bool>, IMapFrom<District>
    {
        public int Id { get; set; }
        public int? StateId { get; set; }
        public string Name { get; set; }
        public string LongText { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateDistrictCommand, District>();
        }
    }
}
