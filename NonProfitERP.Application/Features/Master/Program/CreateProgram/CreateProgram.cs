using System;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Interfaces;
using PublicData.Application.Mappings;

namespace PublicData.Application.Features.Master.Program.CreateProgram
{
    using DAL.Entities;

    public class CreateProgramCommandHandler : IRequestHandler<CreateProgramCommand, int>
    {
        private readonly IProgramRepository _programRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProgramCommandHandler(IProgramRepository programRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _programRepository = programRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<int> Handle(CreateProgramCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Program>(request);

            _programRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreateProgramCommand : IRequest<int>, IMapFrom<Program>
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ContactNo { get; set; }
        public string EmailId { get; set; }
        public string WebLink { get; set; }
        public string LongText { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProgramCommand, Program>();
        }
    }
}
