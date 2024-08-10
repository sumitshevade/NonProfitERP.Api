using AutoMapper;
using MediatR;
using NonProfitERP.Application.Mappings;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.Taluka.CreateTaluka
{
    using DAL.Entities;

    public class CreateTalukaCommandHandler : IRequestHandler<CreateTalukaCommand, int>
    {
        private readonly ITalukaRepository _talukaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTalukaCommandHandler(ITalukaRepository talukaRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _talukaRepository = talukaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<int> Handle(CreateTalukaCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Taluka>(request);

            _talukaRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreateTalukaCommand : IRequest<int>, IMapFrom<Taluka>
    {
        public int? DistrictId { get; set; }
        public string Name { get; set; }
        public string LongText { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTalukaCommand, Taluka>();
        }
    }
}
