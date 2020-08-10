using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Application.Shared;

namespace PublicData.Application.Features.Master.DepartmentHead.GetDepartmentHeadById
{
    public class GetDepartmentHeadByIdQueryHandler
    {
        private readonly IDepartmentHeadRepository _departmentHeadRepository;
        private readonly IMapper _mapper;

        public GetDepartmentHeadByIdQueryHandler(IDepartmentHeadRepository departmentHeadRepository, IMapper mapper)
        {
            _departmentHeadRepository = departmentHeadRepository;
            _mapper = mapper;
        }

        public async Task<DepartmentHeadModel> Handle(GetDepartmentHeadByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<DepartmentHeadModel>(_departmentHeadRepository.GetById(request.Id)));
        }
    }

    public class GetDepartmentHeadByIdQuery : IRequest<DepartmentHeadModel>
    {
        public int Id { get; set; }
    }
}
