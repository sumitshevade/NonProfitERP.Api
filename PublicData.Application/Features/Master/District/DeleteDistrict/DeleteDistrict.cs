using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PublicData.DAL.Interfaces;
using PublicData.Common.Exceptions;
using PublicData.Common.Interfaces;

namespace PublicData.Application.Features.Master.District.DeleteDistrict
{
    using DAL.Entities;

    public class DeleteDistrictCommandHandler : IRequestHandler<DeleteDistrictCommand, bool>
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDistrictCommandHandler(IDistrictRepository districtRepository, IUnitOfWork unitOfWork)
        {
            _districtRepository = districtRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteDistrictCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _districtRepository.GetById(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(District), request.Id);
                }

                entity.IsActive = false;
                _districtRepository.Update(entity);
                _unitOfWork.Commit();

                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeleteDistrictCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
