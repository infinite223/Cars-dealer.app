using FluentValidation;
using Cars.Api.BindingModels;

namespace Cars.Api.Validation
{
    public class CreateUserValidator: AbstractValidator<CreateUser>
    {
        public CreateUserValidator() {
            RuleFor(x => x.UserName).NotNull();
            RuleFor(x => x.Email).NotNull().EmailAddress();
        }
    }

}