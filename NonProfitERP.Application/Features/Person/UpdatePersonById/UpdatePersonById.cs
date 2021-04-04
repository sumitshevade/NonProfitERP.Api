using System;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Application.Mappings;

namespace PublicData.Application.Features.Person.UpdatePersonById
{
    using DAL.Entities;

    public class UpdatePersonByIdCommandHandler : IRequestHandler<UpdatePersonByIdCommand, bool>
    {
        private readonly IPersonRepository _peopleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePersonByIdCommandHandler(IPersonRepository peopleRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _peopleRepository = peopleRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<bool> Handle(UpdatePersonByIdCommand request, CancellationToken cancellationToken)
        {
            var result = _peopleRepository.Exists(x => x.Id == request.Id);
            if (!result)
            {
                throw new NotFoundException(nameof(People), request.Id);
            }

            var entity = _mapper.Map<Person>(request);
            entity.IsActive = true;
            _peopleRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdatePersonByIdCommand : IRequest<bool>, IMapFrom<Person>
    {
        public int Id { get; set; }
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
            profile.CreateMap<UpdatePersonByIdCommand, Person>();
        }
    }
}
