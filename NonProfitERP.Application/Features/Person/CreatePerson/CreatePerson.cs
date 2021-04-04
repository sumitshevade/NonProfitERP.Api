using System;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using NonProfitERP.DAL.Interfaces;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.Application.Mappings;

namespace NonProfitERP.Application.Features.People.CreatePerson
{
    using DAL.Entities;

    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _peopleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePersonCommandHandler(IMapper mapper, IPersonRepository peopleRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _peopleRepository = peopleRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Person>(request);

            _peopleRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreatePersonCommand : IRequest<int>, IMapFrom<Person>
    {
        public string LoginId { get; set; }
        public int PersonTypeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthLocation { get; set; }
        public char Gender { get; set; }
        public string LongText { get; set; }
        public string HighLightText { get; set; }
        public string Keywords { get; set; }
        public bool IsWorker { get; set; }
        public int WorkFrequencyId { get; set; }
        public DateTime JoiningDate { get; set; }
        public int? JoinedAsId { get; set; }
        public int? CountryId { get; set; }
        public string ProfilePicturePath { get; set; }
        public string HeroPicturePath { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePersonCommand, Person>();
        }
    }
}
