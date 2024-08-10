using AutoMapper;
using MediatR;
using NonProfitERP.Application.Mappings;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.District.CreateDistrict
{
    using DAL.Entities;

    public class CreateDistrictCommandHandler : IRequestHandler<CreateDistrictCommand, int>
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public CreateDistrictCommandHandler(IDistrictRepository districtRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _districtRepository = districtRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task<int> Handle(CreateDistrictCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<District>(request);

            _districtRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreateDistrictCommand : IRequest<int>, IMapFrom<District>
    {
        public int? StateId { get; set; }
        public string Name { get; set; }
        public string LongText { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDistrictCommand, District>();
        }
    }
}
