using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Interfaces;
using PublicData.Application.Mappings;

namespace PublicData.Application.Features.Master.DivisionHead.CreateDivisionHead
{
    using DAL.Entities;

    public class CreateDivisionHeadCommandHandler : IRequestHandler<CreateDivisionHeadCommand, int>
    {
        private readonly IDivisionHeadRepository _divisionHeadRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDivisionHeadCommandHandler(IDivisionHeadRepository divisionHeadRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _divisionHeadRepository = divisionHeadRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<int> Handle(CreateDivisionHeadCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<DivisionHead>(request);

            _divisionHeadRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreateDivisionHeadCommand : IRequest<int>, IMapFrom<DivisionHead>
    {
        public int PersonId { get; set; }
        public int DivisionId { get; set; }
        public int FromYear { get; set; }
        public int? ToYear { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DivisionHead, CreateDivisionHeadCommand>();
        }
    }
}
