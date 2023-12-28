using FluentValidation;
using VirtualPetCareWebAPI.Entity.Concretes.Requests;

namespace VirtualPetCareWebAPI.Business.ValidationRules.FluentValidation
{
    public class AddFoodRequestValidator : AbstractValidator<AddFoodRequest>
    {
        public AddFoodRequestValidator()
        {
            RuleFor(request => request.FoodName)
                .NotEmpty().WithMessage("Food name cannot be empty")
                .MaximumLength(50).WithMessage("Food name must be a maximum of 50 characters");

            RuleFor(request => request.FoodType)
                .NotEmpty().WithMessage("Food type cannot be empty")
                .MaximumLength(50).WithMessage("Food type must be a maximum of 50 characters");

            RuleFor(request => request.Content)
                .NotEmpty().WithMessage("Content cannot be empty")
                .MaximumLength(255).WithMessage("Content must be a maximum of 255 characters");

            RuleFor(request => request.PetId)
                .GreaterThan(0).WithMessage("Enter a valid pet id");
        }
    }
}
