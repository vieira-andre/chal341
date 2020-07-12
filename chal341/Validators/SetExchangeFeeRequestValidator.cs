﻿using chal341.Contracts;
using chal341.Extensions;
using FluentValidation;
using System;

namespace chal341.Validators
{
    public class SetExchangeFeeRequestValidator : AbstractValidator<SetExchangeFeeRequest>
    {
        public SetExchangeFeeRequestValidator()
        {
            RuleFor(x => x.Segment)
                .NotEmpty();

            RuleFor(x => x.Fee)
                .NotEmpty();

            RuleFor(x => x.Fee)
                .Custom((fee, context) =>
                {
                    try
                    {
                        _ = fee.ToDecimal();
                    }
                    catch (Exception ex)
                    {
                        context.AddFailure(ex.Message);
                    }
                });
        }
    }
}
