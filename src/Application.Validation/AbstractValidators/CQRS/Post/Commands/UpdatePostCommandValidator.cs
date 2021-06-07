using Application.CQRS.Posts.Commands;
using Application.Persistence.Interfaces;
using Application.Validation.Options;
using Application.Validation.Tools.Extensions;
using FluentValidation;

namespace Application.Validation.AbstractValidators.CQRS.Post.Commands
{
    public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
    {
        public UpdatePostCommandValidator(IXNewsDbContext context)
        {
            RuleFor(c => c.PostId)
                .NotEmpty();
            
            RuleFor(c => c.Content)
                .NotEmpty()
                .Length(PostValidationOptions.ContentMinLength, PostValidationOptions.ContentMaxLength);

            RuleFor(c => c.Title)
                .NotEmpty()
                .Length(PostValidationOptions.TitleMinLength, PostValidationOptions.TitleMaxLength)
                .UniqueInsideOfDbSetColumn(context.Post, p => p.Title);

            RuleFor(c => c.UserId)
                .NotEmpty();
        }
    }
}