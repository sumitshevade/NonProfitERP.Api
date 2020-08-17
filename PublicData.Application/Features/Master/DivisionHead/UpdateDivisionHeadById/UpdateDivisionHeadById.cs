using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;
using PublicData.Application.Mappings;

namespace PublicData.Application.Features.Master.DivisionHead.UpdateDivisionHeadById
{
    using DAL.Entities;

    public class UpdateDivisionHeadByIdCommandHandler : IRequestHandler<UpdateDivisionHeadByIdCommand, bool>
    {
        private readonly IDivisionHeadRepository _divisionHeadRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDivisionHeadByIdCommandHandler(IDivisionHeadRepository divisionHeadRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _divisionHeadRepository = divisionHeadRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdateDivisionHeadByIdCommand request, CancellationToken cancellationToken)
        {
            var result = _divisionHeadRepository.Exists(x => x.Id == request.Id);
            if (!result)
            {
                throw new NotFoundException(nameof(People), request.Id);
            }

            var entity = _mapper.Map<DivisionHead>(request);
            entity.IsActive = true;
            _divisionHeadRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdateDivisionHeadByIdCommand : IRequest<bool>, IMapFrom<DivisionHead>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int DivisionId { get; set; }
        public int FromYear { get; set; }
        public int? ToYear { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateDivisionHeadByIdCommand, DivisionHead>();
        }
    }
}
