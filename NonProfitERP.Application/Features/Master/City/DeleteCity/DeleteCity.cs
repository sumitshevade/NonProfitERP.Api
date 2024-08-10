using MediatR;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Master.City.DeleteCity
{
    using DAL.Entities;

    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, bool>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCityCommandHandler(ICityRepository cityRepository, IUnitOfWork unitOfWork)
        {
            _cityRepository = cityRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _cityRepository.GetById(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Country), request.Id);
                }

                entity.IsActive = false;
                _cityRepository.Update(entity);
                _unitOfWork.Commit();

                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeleteCityCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
