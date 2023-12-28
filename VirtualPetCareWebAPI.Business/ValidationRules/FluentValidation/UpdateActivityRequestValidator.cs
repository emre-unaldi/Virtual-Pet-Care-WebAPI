using FluentValidation;
using VirtualPetCareWebAPI.Entity.Concretes.Requests;

namespace VirtualPetCareWebAPI.Business.ValidationRules.FluentValidation
{
    public class UpdateActivityRequestValidator : AbstractValidator<UpdateActivityRequest>
    {
        public UpdateActivityRequestValidator()
        {
            RuleFor(request => request.Id)
                .GreaterThan(0).WithMessage("Enter a valid activity id");

            RuleFor(request => request.ActivityType)
                .NotEmpty().WithMessage("Activity type cannot be empty")
                .MaximumLength(50).WithMessage("Activity type must be a maximum of 50 characters");

            RuleFor(request => request.Notes)
                .MaximumLength(255).WithMessage("Notes must be a maximum of 255 characters");

            RuleFor(request => request.PetId)
                .GreaterThan(0).WithMessage("Enter a valid pet id");
        }
    }
}
