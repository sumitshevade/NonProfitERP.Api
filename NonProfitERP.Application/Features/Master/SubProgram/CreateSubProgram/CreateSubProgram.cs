using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using NonProfitERP.DAL.Interfaces;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.Application.Mappings;
using System;

namespace NonProfitERP.Application.Features.Master.SubProgram.CreateSubProgram
{
    using DAL.Entities;

    public class CreateSubProgramCommandHandler : IRequestHandler<CreateSubProgramCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ISubProgramRepository _subProgramRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSubProgramCommandHandler(IMapper mapper, ISubProgramRepository subProgramRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _subProgramRepository = subProgramRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<int> Handle(CreateSubProgramCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SubProgram>(request);

            entity.IsActive = true;
            _subProgramRepository.Add(entity);
            _unitOfWork.Commit();

            return Task.FromResult(entity.Id);
        }
    }

    public class CreateSubProgramCommand : IRequest<int>, IMapFrom<SubProgram>
    {
        public int? ProgramId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ContactNo { get; set; }
        public string EmailId { get; set; }
        public string WebLink { get; set; }
        public string LongText { get; set; }
        public bool IsActive { get; set; }

        public virtual Program Program { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateSubProgramCommand, SubProgram>();
        }
    }
}
