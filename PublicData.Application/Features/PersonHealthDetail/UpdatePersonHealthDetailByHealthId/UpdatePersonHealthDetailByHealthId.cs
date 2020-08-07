using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;

namespace PublicData.Application.Features.PersonHealthDetail.UpdatePersonHealthDetailByHealthId
{
    using Data.Entities;
    using PublicData.Application.Mappings;

    public class UpdatePersonHealthDetailByHealthIdCommandHandler : IRequestHandler<UpdatePersonHealthDetailByHealthIdCommand, bool>
    {
        private readonly IPersonHealthDetailsRepository _personHealthDetailsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePersonHealthDetailByHealthIdCommandHandler(IPersonHealthDetailsRepository personHealthDetailsRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _personHealthDetailsRepository = personHealthDetailsRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdatePersonHealthDetailByHealthIdCommand request, CancellationToken cancellationToken)
        {
            var result = _personHealthDetailsRepository.Exists(x => x.Id == request.Id);
            if (result)
            {
                throw new NotFoundException(nameof(PersonHealthDetail), request.Id);
            }

            var entity = _mapper.Map<PersonHealthDetail>(request);
            _personHealthDetailsRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdatePersonHealthDetailByHealthIdCommand : IRequest<bool>, IMapFrom<PersonHealthDetail>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public double? Iq { get; set; }
        public double? WakeUpTiming { get; set; }
        public double? SleepTiming { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePersonHealthDetailByHealthIdCommand, PersonHealthDetail>();
        }
    }
}
