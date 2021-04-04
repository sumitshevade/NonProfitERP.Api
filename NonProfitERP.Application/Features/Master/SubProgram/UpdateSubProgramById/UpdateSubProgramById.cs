using MediatR;
using AutoMapper;
using NonProfitERP.Application.Mappings;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace NonProfitERP.Application.Features.Master.SubProgram.UpdateSubProgramById
{
    using DAL.Entities;

    public class UpdateSubProgramByIdCommandHandler : IRequestHandler<UpdateSubProgramByIdCommand, bool>
    {
        private readonly ISubProgramRepository _subProgramRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSubProgramByIdCommandHandler(ISubProgramRepository subProgramRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _subProgramRepository = subProgramRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdateSubProgramByIdCommand request, CancellationToken cancellationToken)
        {
            var result = _subProgramRepository.Exists(x => x.Id == request.Id);
            if (!result)
            {
                throw new NotFoundException(nameof(SubProgram), request.Id);
            }

            var entity = _mapper.Map<SubProgram>(request);
            entity.IsActive = true;
            _subProgramRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdateSubProgramByIdCommand : IRequest<bool>, IMapFrom<SubProgram>
    {
        public int Id { get; set; }
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
            profile.CreateMap<UpdateSubProgramByIdCommand, SubProgram>();
        }
    }
}
