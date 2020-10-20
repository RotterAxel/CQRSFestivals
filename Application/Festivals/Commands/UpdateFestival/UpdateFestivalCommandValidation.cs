using FluentValidation;

namespace Application.Festivals.Commands.UpdateFestival
{
    public class UpdateFestivalCommandValidation : AbstractValidator<UpdateFestivalCommand>
    {
        public UpdateFestivalCommandValidation()
        {
            RuleFor(x => x.Title)
                .MaximumLength(50).WithMessage("Title must not exceed 50 characters in length")
                .MinimumLength(5).WithMessage("Title must be at least 5 characters in length")
                .NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters in length")
                .NotEqual(x => x.Title).WithMessage("Title must be different from description.");
            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("StartDate is required")
                .LessThan(x => x.EndDate).WithMessage("StartDate must come before EndDate");
            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("EndDate is required");
        }
    }
}