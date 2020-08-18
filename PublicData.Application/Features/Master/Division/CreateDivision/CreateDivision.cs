using System;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Interfaces;
using PublicData.Application.Mappings;

namespace PublicData.Application.Features.Master.Division.CreateDivision
{
    using DAL.Entities;

    public class CreateDivisionCommandHandler : IRequestHandler<CreateDivisionCommand, int>
    {
        private readonly IDivisionRepository _divisionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDivisionCommandHandler(IDivisionRepository divisionRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _divisionRepository = divisionRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<int> Handle(CreateDivisionCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Division>(request);

            _divisionRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreateDivisionCommand : IRequest<int>, IMapFrom<Division>
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public string LongText { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Division, CreateDivisionCommand>();
        }
    }
}
