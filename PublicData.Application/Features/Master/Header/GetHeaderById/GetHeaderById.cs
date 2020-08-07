using MediatR;
using PublicData.Application.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PublicData.Application.Features.Master.Header.GetHeaderById
{
    public class GetHeaderByIdQueryHandler : IRequestHandler<GetHeaderByIdQuery, HeaderModel>
    {
        public GetHeaderByIdQueryHandler()
        {

        }

        public Task<HeaderModel> Handle(GetHeaderByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class GetHeaderByIdQuery : IRequest<HeaderModel>
    {
    }
}
