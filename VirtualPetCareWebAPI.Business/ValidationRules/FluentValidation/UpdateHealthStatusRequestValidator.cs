using FluentValidation;
using VirtualPetCareWebAPI.Entity.Concretes.Requests;

namespace VirtualPetCareWebAPI.Business.ValidationRules.FluentValidation
{
    public class UpdateHealthStatusRequestValidator : AbstractValidator<UpdateHealthStatusRequest>
    {
        public UpdateHealthStatusRequestValidator()
        {
            RuleFor(request => request.Id)
                .GreaterThan(0).WithMessage("Enter a valid health ID.");

            RuleFor(request => request.VaccinationStatus)
                .NotNull().WithMessage("Vaccination status must be specified.");

            RuleFor(request => request.VetVisits)
                .MaximumLength(255).WithMessage("Veterinary visit notes must be a maximum of 255 characters");

            RuleFor(request => request.DiseasesAllergies)
                .MaximumLength(255).WithMessage("Diseases and allergies notes must be a maximum of 255 characters");

            RuleFor(request => request.PetId)
                .GreaterThan(0).WithMessage("Enter a valid pet id");
        }
    }
}
