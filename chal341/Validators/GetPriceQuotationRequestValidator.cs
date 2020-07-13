using chal341.Contracts;
using FluentValidation;
using System.Linq;

namespace chal341.Validators
{
    public class GetPriceQuotationRequestValidator : AbstractValidator<GetPriceQuotationRequest>
    {
        public GetPriceQuotationRequestValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty()
                .Length(3)
                .Custom((input, context) =>
                {
                    bool areThereOnlyLetters = input.All(char.IsLetter);

                    if (!areThereOnlyLetters)
                        context.AddFailure("Only letters are allowed.");
                });

            RuleFor(x => x.Units)
                .GreaterThan(0);

            RuleFor(x => x.Segment)
                .NotEmpty();
        }
    }
}
