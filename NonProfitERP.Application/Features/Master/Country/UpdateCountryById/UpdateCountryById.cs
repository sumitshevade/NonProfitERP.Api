using MediatR;
using AutoMapper;
using NonProfitERP.Application.Mappings;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.Country.UpdateCountryById
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
            entity.IsActive = true;
            _countryRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdateCountryByIdCommand : IRequest<bool>, IMapFrom<Country>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCountryByIdCommand, Country>();
        }
    }
}
