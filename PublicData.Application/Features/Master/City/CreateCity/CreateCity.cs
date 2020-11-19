using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Interfaces;

namespace PublicData.Application.Features.Master.City.CreateCity
{
    using DAL.Entities;
    using PublicData.Application.Mappings;

    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCityCommandHandler(ICityRepository cityRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<int> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<City>(request);

            _cityRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreateCityCommand : IRequest<int>, IMapFrom<City>
    {
        public int? StateId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<City, CreateCityCommand>();
        }
    }
}
