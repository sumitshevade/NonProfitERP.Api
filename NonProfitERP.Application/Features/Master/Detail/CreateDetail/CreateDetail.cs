using AutoMapper;
using MediatR;
using NonProfitERP.Application.Mappings;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.Detail.CreateDetail
{
    using DAL.Entities;

    public class CreateDetailCommandHandler : IRequestHandler<CreateDetailCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IDetailRepository _detailRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDetailCommandHandler(IMapper mapper, IDetailRepository detailRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _detailRepository = detailRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<int> Handle(CreateDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Detail>(request);

            _detailRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreateDetailCommand : IRequest<int>, IMapFrom<Detail>
    {
        public int HeaderId { get; set; }
        public string Name { get; set; }
        public string ExtraField { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDetailCommand, Detail>();
        }
    }
}
