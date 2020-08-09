using System;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;
using PublicData.Application.Mappings;

namespace PublicData.Application.Features.Master.Division.UpdateDivision
{
    using DAL.Entities;

    public class UpdateDivisionCommandHandler : IRequestHandler<UpdateDivisionCommand, bool>
    {
        private readonly IDivisionRepository _divisionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDivisionCommandHandler(IDivisionRepository divisionRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _divisionRepository = divisionRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdateDivisionCommand request, CancellationToken cancellationToken)
        {
            var result = _divisionRepository.Exists(x => x.Id == request.Id);
            if (!result)
            {
                throw new NotFoundException(nameof(People), request.Id);
            }

            var entity = _mapper.Map<Division>(request);
            _divisionRepository.Update(entity);

            return Task.FromResult(_unitOfWork.Commit());
        }
    }

    public class UpdateDivisionCommand : IRequest<bool>, IMapFrom<Division>
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public string LongText { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Division, UpdateDivisionCommand>();
        }
    }
}
