using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using NonProfitERP.DAL.Interfaces;
using NonProfitERP.Common.Interfaces;

namespace NonProfitERP.Application.Features.PersonHealthDetail.CreatePersonHealthDetail
{
    using DAL.Entities;
    using NonProfitERP.Application.Mappings;

    public class CreatePersonHealthDetailCommandHandler : IRequestHandler<CreatePersonHealthDetailCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IPersonHealthDetailsRepository _personHealthDetailsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePersonHealthDetailCommandHandler(IMapper mapper, IPersonHealthDetailsRepository personHealthDetailsRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _personHealthDetailsRepository = personHealthDetailsRepository;
        }

        public Task<int> Handle(CreatePersonHealthDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PersonHealthDetail>(request);

            _personHealthDetailsRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreatePersonHealthDetailCommand : IRequest<int>, IMapFrom<PersonHealthDetail>
    {
        public int PersonId { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public double? Iq { get; set; }
        public double? WakeUpTiming { get; set; }
        public double? SleepTiming { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePersonHealthDetailCommand, PersonHealthDetail>();
        }
    }
}
