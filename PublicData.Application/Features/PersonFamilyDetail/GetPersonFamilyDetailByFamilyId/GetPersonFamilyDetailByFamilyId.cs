using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Application.Shared;

namespace PublicData.Application.Features.PersonFamilyDetail.GetPersonFamilyDetailByFamilyId
{
    public class GetPersonFamilyDetailByFamilyIdQueryHandler : IRequestHandler<GetPersonFamilyDetailByFamilyIdQuery, PersonFamilyDetailModel>
    {
        private readonly IMapper _mapper;
        private readonly IPersonFamilyDetailsRepository _personFamilyDetailsRepository;

        public GetPersonFamilyDetailByFamilyIdQueryHandler(IMapper mapper, IPersonFamilyDetailsRepository personFamilyDetailsRepository)
        {
            _personFamilyDetailsRepository = personFamilyDetailsRepository;
            _mapper = mapper;
        }

        public async Task<PersonFamilyDetailModel> Handle(GetPersonFamilyDetailByFamilyIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<PersonFamilyDetailModel>(_personFamilyDetailsRepository.GetById(request.FamilyId)));
        }
    }

    public class GetPersonFamilyDetailByFamilyIdQuery : IRequest<PersonFamilyDetailModel>
    {
        public int FamilyId { get; set; }
    }
}
