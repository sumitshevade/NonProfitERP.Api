using AutoMapper;
using MediatR;
using NonProfitERP.Application.Mappings;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.Program.UpdateProgram
{
    using DAL.Entities;

    public class UpdateProgramCommandHandler : IRequestHandler<UpdateProgramCommand, bool>
    {
        private readonly IProgramRepository _programRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProgramCommandHandler(IProgramRepository programRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _programRepository = programRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdateProgramCommand request, CancellationToken cancellationToken)
        {
            var result = _programRepository.Exists(x => x.Id == request.Id);
            if (!result)
            {
                throw new NotFoundException(nameof(People), request.Id);
            }

            var entity = _mapper.Map<Program>(request);
            entity.IsActive = true;
            _programRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdateProgramCommand : IRequest<bool>, IMapFrom<Program>
    {
        public int Id { get; set; }
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
            profile.CreateMap<UpdateProgramCommand, Program>();
        }
    }
}
