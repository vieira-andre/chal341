﻿using chal341.Contracts;
using chal341.Helpers;
using FluentValidation;
using System;

namespace chal341.Validators
{
    public class AddExchangeFeeRequestValidator : AbstractValidator<AddExchangeFeeRequest>
    {
        public AddExchangeFeeRequestValidator()
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
                        _ = fee.ToInvariantDecimal();
                    }
                    catch (Exception ex)
                    {
                        context.AddFailure(ex.Message);
                    }
                });
        }
    }
}
