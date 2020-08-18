using PublicData.WebClient.Models;
using FluentValidation;
using System.Text.RegularExpressions;

namespace PublicData.WebClient.Validators
{
    public class PasswordValidator : AbstractValidator<ChangePasswordModel>
    {
        public PasswordValidator()
        {
            RuleFor(x => x.CurrentPassword)
                .NotEmpty().WithMessage("CurrentPassword is Required");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("NewPassword is Required")
                .Must(ValidatePassword).WithMessage("Password should be alphanumeric with 6 -15 characters.")
                .When(x => x.NewPassword != null)
                .NotEqual(x => x.CurrentPassword).WithMessage("New Password should not match Current Password.");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("ConfirmPassword is Required")
                .Equal(x => x.NewPassword).WithMessage("New password and confirm password do not match.");
        }

        private static bool ValidatePassword(string newPassword)
        {
            var passRegex = @"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,15})";
            return Regex.IsMatch(newPassword, passRegex);
        }
    }
}
