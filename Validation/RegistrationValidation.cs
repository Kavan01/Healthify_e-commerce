using FluentValidation;
using Healthify1.Models;

namespace Healthify1.RegistrationValidation
{
    public class RegistrationValidation : AbstractValidator<RegistrationModel>
    {
        public RegistrationValidation()
        {
            RuleFor(registrationmodel => registrationmodel.FirstName).NotEmpty().WithMessage("FirstName Name is Required");
            RuleFor(registrationmodel => registrationmodel.LastName).NotEmpty().WithMessage("LastName Name is Required");
            RuleFor(registrationmodel => registrationmodel.UserName).NotEmpty().WithMessage("Username Name is Required");
            RuleFor(registrationmodel => registrationmodel.Password).NotEmpty().MinimumLength(3).MaximumLength(6).WithMessage("Minimum length of password is 3");
            /*RuleFor(registrationmodel => registrationmodel.ConfirmedPassword).Matches(registrationmodel => registrationmodel.Password).NotEmpty().WithMessage("Confirm the password");*/
            RuleFor(registrationmodel => registrationmodel.Email).NotEmpty().EmailAddress().WithMessage("Proper Email Format is Required");
        }
    }
}
