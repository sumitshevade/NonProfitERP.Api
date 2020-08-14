using MediatR;
using AutoMapper;
using PublicData.Application.Mappings;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;
using PublicData.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PublicData.Application.Features.Master.Country.UpdateCountryById
{
    using DAL.Entities;

    public class UpdateCountryByIdCommandHandler : IRequestHandler<UpdateCountryByIdCommand, bool>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCountryByIdCommandHandler(ICountryRepository countryRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _countryRepository = countryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdateCountryByIdCommand request, CancellationToken cancellationToken)
        {
            var result = _countryRepository.Exists(x => x.Id == request.Id);
            if (!result)
            {
                throw new NotFoundException(nameof(People), request.Id);
            }

            var entity = _mapper.Map<Country>(request);
            _countryRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdateCountryByIdCommand : IRequest<bool>, IMapFrom<Country>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCountryByIdCommand, Country>();
        }
    }
}
