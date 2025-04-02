using AutoMapper;
using MediatR;
using NonProfitERP.Application.Mappings;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.Detail.UpdateDetail
{
    using DAL.Entities;

    public class UpdateDetailCommandHandler : IRequestHandler<UpdateDetailCommand, bool>
    {
        private readonly IDetailRepository _detailRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDetailCommandHandler(IDetailRepository detailRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _detailRepository = detailRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdateDetailCommand request, CancellationToken cancellationToken)
        {
            var result = _detailRepository.Exists(x => x.Id == request.Id);
            if (!result)
            {
                throw new NotFoundException(nameof(People), request.Id);
            }

            var entity = _mapper.Map<Detail>(request);
            entity.IsActive = true;
            _detailRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdateDetailCommand : IRequest<bool>, IMapFrom<Detail>
    {
        public int Id { get; set; }
        public int HeaderId { get; set; }
        public string Name { get; set; }
        public string ExtraField { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateDetailCommand, Detail>();
        }
    }
}
