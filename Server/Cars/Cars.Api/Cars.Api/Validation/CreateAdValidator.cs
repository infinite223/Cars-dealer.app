using FluentValidation;
using Cars.Api.BindingModels;
using Cars.IServices.Requests;

namespace Cars.Api.Validation
{
    public class CreateAdValidator: AbstractValidator<CreateAd>
    {
        public CreateAdValidator() {
            RuleFor(x => x.CategoryId).NotNull();
            RuleFor(x => x.TitleAd).NotNull();
        }
    }

}