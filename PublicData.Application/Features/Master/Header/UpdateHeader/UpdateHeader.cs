using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Interfaces;

namespace PublicData.Application.Features.Master.Header.UpdateHeader
{
    using DAL.Entities;
    using PublicData.Application.Mappings;
    using PublicData.Common.Exceptions;

    public class UpdateHeaderCommandHandler : IRequestHandler<UpdateHeaderCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IHeaderRepository _headerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateHeaderCommandHandler(IHeaderRepository headerRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _headerRepository = headerRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(UpdateHeaderCommand request, CancellationToken cancellationToken)
        {
            var result = _headerRepository.Exists(x => x.Id == request.Id);
            if (!result)
            {
                throw new NotFoundException(nameof(People), request.Id);
            }

            var entity = _mapper.Map<Header>(request);
            _headerRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdateHeaderCommand : IRequest<bool>, IMapFrom<Header>
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateHeaderCommand, Header>();
        }
    }
}
