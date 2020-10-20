using FluentValidation;

namespace Application.Festivals.Commands.CreateFestival
{
    public class CreateFestivalCommandValidator : AbstractValidator<CreateFestivalCommand>
    {
        public CreateFestivalCommandValidator()
        {
            RuleFor(x => x.Title)
                .MaximumLength(50).WithMessage("Title must not exceed 50 characters in length")
                .MinimumLength(5).WithMessage("Title must be at least 5 characters in length")
                .NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters in length")
                .NotEqual(x => x.Title).WithMessage("Title must be different from description.");
            RuleFor(x => x.StartDate)
                .NotNull().WithMessage("StartDate is required")
                .LessThan(x => x.EndDate).WithMessage("StartDate must come before EndDate");
            RuleFor(x => x.EndDate)
                .NotNull().WithMessage("EndDate is required");
            RuleFor(x => x.Street)
                .MaximumLength(100).WithMessage("Street must not exceed 100 characters in length")
                .NotEmpty().WithMessage("Street is required");
            RuleFor(x => x.Number)
                .MaximumLength(15).WithMessage("Number must not exceed 100 characters in length")
                .NotEmpty().WithMessage("Number is required");
            RuleFor(x => x.PostalCode)
                .MaximumLength(50).WithMessage("PostalCode must not exceed 50 characters in length")
                .NotEmpty().WithMessage("PostalCode is required");
            RuleFor(x => x.State)
                .MaximumLength(50).WithMessage("State must not exceed 50 characters in length")
                .NotEmpty().WithMessage("State is required");
            RuleFor(x => x.Country)
                .MaximumLength(50).WithMessage("Country must not exceed 50 characters in length")
                .NotEmpty().WithMessage("Country is required");
        }
    }
}