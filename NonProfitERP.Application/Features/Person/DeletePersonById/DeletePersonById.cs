using AutoMapper;
using MediatR;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.DAL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NonProfitERP.Application.Features.Person.DeletePersonById
{
    using DAL.Entities;

    public class DeletePersonByIdHandler : IRequestHandler<DeletePersonByIdCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _peopleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public int Id { get; set; }

        public DeletePersonByIdHandler(IMapper mapper, IPersonRepository peopleRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _peopleRepository = peopleRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeletePersonByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _peopleRepository.GetById(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Person), request.Id);
                }

                entity.IsActive = false;
                _peopleRepository.Update(entity);
                _unitOfWork.Commit();

                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeletePersonByIdCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
