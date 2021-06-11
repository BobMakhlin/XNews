using Application.CQRS.Users.Queries.UserPostRate;
using Application.Validation.AbstractValidators.Common;
using FluentValidation;

namespace Application.Validation.AbstractValidators.CQRS.Users.Queries.UserPostRate
{
    public class GetPostRatesOfUserQueryValidator : AbstractValidator<GetPostRatesOfUserQuery>
    {
        public GetPostRatesOfUserQueryValidator()
        {
            Include(new PaginationRequestValidator());

            RuleFor(q => q.UserId)
                .NotEmpty();
        }
    }
}