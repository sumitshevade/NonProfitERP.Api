using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using NonProfitERP.DAL.Interfaces;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.Common.Exceptions;

namespace NonProfitERP.Application.Features.PersonSocialMediaAccount.DeletePersonSocialMediaAccount
{
    using DAL.Entities;

    public class DeletePersonSocialMediaAccountByIdCommandHandler : IRequestHandler<DeletePersonSocialMediaAccountByIdCommand, bool>
    {
        private readonly IPersonSocialMediaAccountRepository _personSocialMediaAccountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonSocialMediaAccountByIdCommandHandler(IPersonSocialMediaAccountRepository personSocialMediaAccountRepository, IUnitOfWork unitOfWork)
        {
            _personSocialMediaAccountRepository = personSocialMediaAccountRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeletePersonSocialMediaAccountByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _personSocialMediaAccountRepository.GetById(request.SocialMediaAccountId);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(PersonEducation), request.SocialMediaAccountId);
                }

                entity.IsActive = false;
                _personSocialMediaAccountRepository.Update(entity);

                return Task.FromResult(_unitOfWork.Commit());
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }

    public class DeletePersonSocialMediaAccountByIdCommand : IRequest<bool>
    {
        public int SocialMediaAccountId { get; set; }
    }
}
