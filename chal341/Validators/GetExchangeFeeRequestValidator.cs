using chal341.Contracts;
using FluentValidation;

namespace chal341.Validators
{
    public class GetExchangeFeeRequestValidator : AbstractValidator<GetExchangeFeeRequest>
    {
        public GetExchangeFeeRequestValidator()
        {
            RuleFor(x => x.Segment)
                .NotEmpty();
        }
    }
}
