using chal341.Contracts;
using chal341.Extensions;
using FluentValidation;
using System;
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

            RuleFor(x => x.Amount)
                .NotEmpty()
                .Custom((x, context) =>
                {
                    try
                    {
                        _ = x.ToInvariantDecimal();
                    }
                    catch (Exception ex)
                    {
                        context.AddFailure(ex.Message);
                    }
                });

            RuleFor(x => x.Segment)
                .NotEmpty();
        }
    }
}
