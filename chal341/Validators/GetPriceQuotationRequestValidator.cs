using chal341.Contracts;
using FluentValidation;

namespace chal341.Validators
{
    public class GetPriceQuotationRequestValidator : AbstractValidator<GetPriceQuotationRequest>
    {
        public GetPriceQuotationRequestValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty();

            RuleFor(x => x.Units)
                .GreaterThan(0);

            RuleFor(x => x.Segment)
                .NotEmpty();
        }
    }
}
