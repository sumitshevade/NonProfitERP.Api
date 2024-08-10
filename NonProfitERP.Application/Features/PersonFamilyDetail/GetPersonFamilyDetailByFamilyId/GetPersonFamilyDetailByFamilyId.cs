using AutoMapper;
using MediatR;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.PersonFamilyDetail.GetPersonFamilyDetailByFamilyId
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
