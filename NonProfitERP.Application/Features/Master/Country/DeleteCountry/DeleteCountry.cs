using MediatR;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.Country.DeleteCountry
{
    using DAL.Entities;

    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, bool>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCountryCommandHandler(ICountryRepository countryRepository, IUnitOfWork unitOfWork)
        {
            _countryRepository = countryRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _countryRepository.GetById(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Country), request.Id);
                }

                entity.IsActive = false;
                _countryRepository.Update(entity);
                _unitOfWork.Commit();

                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeleteCountryCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
