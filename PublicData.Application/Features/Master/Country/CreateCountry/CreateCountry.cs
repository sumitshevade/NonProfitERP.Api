using AutoMapper;
using MediatR;
using PublicData.Common.Interfaces;
using PublicData.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PublicData.Application.Features.Master.Country.CreateCountry
{
    using DAL.Entities;

    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCountryCommandHandler(IMapper mapper, ICountryRepository countryRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<int> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Country>(request);

            _countryRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreateCountryCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
