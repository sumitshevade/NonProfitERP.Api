using AutoMapper;
using MediatR;
using NonProfitERP.Application.Mappings;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.University.UpdateUniversity
{
    using DAL.Entities;

    public class UpdateUniversityCommandHandler : IRequestHandler<UpdateUniversityCommand, bool>
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUniversityCommandHandler(IUniversityRepository universityRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _universityRepository = universityRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdateUniversityCommand request, CancellationToken cancellationToken)
        {
            var result = _universityRepository.Exists(x => x.Id == request.Id);

            if (!result)
            {
                throw new NotFoundException(nameof(University), request.Id);
            }

            var entity = _mapper.Map<University>(request);
            entity.IsActive = true;
            _universityRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdateUniversityCommand : IRequest<bool>, IMapFrom<University>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUniversityCommand, University>();
        }
    }
}
