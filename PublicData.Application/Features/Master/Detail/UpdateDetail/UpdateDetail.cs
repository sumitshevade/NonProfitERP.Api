using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;
using PublicData.Application.Mappings;

namespace PublicData.Application.Features.Master.Detail.UpdateDetail
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
            _detailRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdateDetailCommand : IRequest<bool>, IMapFrom<Detail>
    {
        public int Id { get; set; }
        public int HeaderId { get; set; }
        public string Value { get; set; }
        public string ExtraField { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateDetailCommand, Detail>();
        }
    }
}
