using FluentValidation;
using VirtualPetCareWebAPI.Entity.Concretes.Requests;

namespace VirtualPetCareWebAPI.Business.ValidationRules.FluentValidation
{
    public class UpdatePetRequestValidator : AbstractValidator<UpdatePetRequest>
    {
        public UpdatePetRequestValidator()
        {
            RuleFor(request => request.Id)
                .GreaterThan(0).WithMessage("Enter a valid pet id");

            RuleFor(request => request.Name)
                .NotEmpty().WithMessage("Pet name cannot be empty")
                .MaximumLength(50).WithMessage("Pet name must be a maximum of 50 characters");

            RuleFor(request => request.Species)
                .NotEmpty().WithMessage("Pet type cannot be empty")
                .MaximumLength(50).WithMessage("Pet type must be a maximum of 50 characters");

            RuleFor(request => request.Age)
                .GreaterThanOrEqualTo(0).WithMessage("Pet age cannot be less than zero");

            RuleFor(request => request.Gender)
                .NotEmpty().WithMessage("Pet gender cannot be empty")
                .Must(gender => gender == "Male" || gender == "Female")
                .WithMessage("Enter a valid pet gender");

            RuleFor(request => request.Color)
                .NotEmpty().WithMessage("Pet color cannot be empty")
                .MaximumLength(50).WithMessage("Pet color must be a maximum of 50 characters");

            RuleFor(request => request.UserId)
                .GreaterThan(0).WithMessage("Enter a valid user id");
        }
    }
}
