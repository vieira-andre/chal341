using chal341.Contracts;
using FluentValidation;

namespace chal341.Validators
{
    public class SetExchangeFeeRequestValidator : AbstractValidator<SetExchangeFeeRequest>
    {
        public SetExchangeFeeRequestValidator()
        {
            RuleFor(x => x.Segment)
                .NotEmpty();

            RuleFor(x => x.Fee)
                .NotNull();
        }
    }
}
