using FluentValidation;
using Cars.Api.BindingModels;

namespace Cars.Api.Validation
{
    public class EditUserValidator : AbstractValidator<EditUser> {
        public EditUserValidator() {
            RuleFor(x => x.UserName).NotNull();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Login).NotNull();
            RuleFor(x => x.Password).NotNull();
        }
    }
}