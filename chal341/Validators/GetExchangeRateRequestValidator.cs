using chal341.Contracts;
using FluentValidation;
using System.Linq;

namespace chal341.Validators
{
    public class GetExchangeRateRequestValidator : AbstractValidator<GetExchangeRateRequest>
    {
        public GetExchangeRateRequestValidator()
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
        }
    }
}
