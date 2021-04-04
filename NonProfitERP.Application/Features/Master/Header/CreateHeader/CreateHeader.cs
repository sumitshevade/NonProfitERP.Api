using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using NonProfitERP.DAL.Interfaces;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.Application.Mappings;

namespace NonProfitERP.Application.Features.Master.Header.CreateHeader
{
    using DAL.Entities;

    public class CreateHeaderCommandHandler : IRequestHandler<CreateHeaderCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IHeaderRepository _headerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateHeaderCommandHandler(IMapper mapper, IHeaderRepository headerRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _headerRepository = headerRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<int> Handle(CreateHeaderCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Header>(request);

            _headerRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreateHeaderCommand : IRequest<int>, IMapFrom<Header>
    {
        public string Title { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateHeaderCommand, Header>();
        }
    }
}
