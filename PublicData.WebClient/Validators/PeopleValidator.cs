using PublicData.WebClient.Models;
using FluentValidation;
using System.Text.RegularExpressions;

namespace PublicData.WebClient.Validators
{
    public class PeopleValidator : AbstractValidator<People>
    {
        public PeopleValidator()
        {
            RuleFor(c => c.FirstName)
              .NotEmpty().WithMessage("First name is required.")
              .MaximumLength(100).WithMessage("First name must not exceed 100 characters.");

            RuleFor(c => c.LastName)
               .NotEmpty().WithMessage("Last name is required.")
               .MaximumLength(100).WithMessage("Last name must not exceed 100 characters.");

            //RuleFor(c => c.Email)
            //    .NotEmpty().WithMessage("Email is required.")
            //    .EmailAddress().WithMessage("Enter valid email.")
            //    .MaximumLength(100).WithMessage("Email must not exceed 100 characters.");

            //RuleFor(c => c.Address)
            //    .MaximumLength(250).WithMessage("Address must not exceed 250 characters.");

            //RuleFor(c => c.Mobile)
            //    .Must(MobileLength).WithMessage("Enter valid 10 digit mobile number.");

        }
        protected static bool MobileLength(string mobile)
        {
            return Regex.IsMatch(mobile, @"^[0-9]{10}$");
        }
    }
}
