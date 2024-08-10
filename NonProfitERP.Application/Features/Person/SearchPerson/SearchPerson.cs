using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NonProfitERP.Application.Shared;
using NonProfitERP.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Person.SearchPerson
{
    public class SearchPersonQueryHandler : IRequestHandler<SearchPersonQuery, IList<PersonModel>>
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _peopleRepository;

        public SearchPersonQueryHandler(IMapper mapper, IPersonRepository peopleRepository)
        {
            _mapper = mapper;
            _peopleRepository = peopleRepository;
        }

        public async Task<IList<PersonModel>> Handle(SearchPersonQuery request, CancellationToken cancellationToken)
        {
            var result = _peopleRepository.GetList(x => x.IsActive == true
                //&& x.IsAlive == request.IsAlive
                && x.IsWorker == request.IsWorker);

            if (request.FirstName != null)
                result = result.Where(x => x.FirstName.Contains(request.FirstName));

            if (request.MiddleName != null)
                result = result.Where(x => x.MiddleName.Contains(request.MiddleName));

            if (request.LastName != null)
                result = result.Where(x => x.LastName.Contains(request.LastName));

            if (request.BirthLocation != null)
                result = result.Where(x => x.BirthLocation.Contains(request.BirthLocation));

            if (request.PersonTypeId != 0)
                result = result.Where(x => x.PersonTypeId == request.PersonTypeId);

            if (request.CountryId != 0)
                result = result.Where(x => x.CountryId == request.CountryId);

            if (request.WorkFrequencyId != 0)
                result = result.Where(x => x.WorkFrequencyId == request.WorkFrequencyId);

            if (request.JoinedAsId != 0)
                result = result.Where(x => x.JoinedAsId == request.JoinedAsId);

            return await result.ProjectTo<PersonModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class SearchPersonQuery : IRequest<IList<PersonModel>>
    {
        public int PersonTypeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string BirthLocation { get; set; }
        public int CountryId { get; set; }
        public int WorkFrequencyId { get; set; }
        public int JoinedAsId { get; set; }

        public bool IsWorker { get; set; }
        public bool IsAlive { get; set; }

        //public string LongText { get; set; }
        //public string Keywords { get; set; }
    }
}
