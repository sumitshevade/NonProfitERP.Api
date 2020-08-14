using MediatR;
using AutoMapper;
using PublicData.Application.Mappings;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;
using PublicData.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PublicData.Application.Features.Master.City.UpdateCityById
{
    using DAL.Entities;

    public class UpdateCityByIdCommandHandler : IRequestHandler<UpdateCityByIdCommand, bool>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCityByIdCommandHandler(ICityRepository cityRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _cityRepository = cityRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdateCityByIdCommand request, CancellationToken cancellationToken)
        {
            var result = _cityRepository.Exists(x => x.Id == request.Id);
            if (!result)
            {
                throw new NotFoundException(nameof(People), request.Id);
            }

            var entity = _mapper.Map<City>(request);
            _cityRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdateCityByIdCommand : IRequest<bool>, IMapFrom<City>
    {
        public int Id { get; set; }
        public int? StateId { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCityByIdCommand, City>();
        }
    }
}
