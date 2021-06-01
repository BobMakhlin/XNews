using Application.CQRS.Comments.Commands;
using FluentValidation;

namespace Application.Validation.AbstractValidators.CQRS.Comments.Commands
{
    public class DeleteCommentCommandValidator : AbstractValidator<DeleteCommentCommand>
    {
        public DeleteCommentCommandValidator()
        {
            RuleFor(c => c.CommentId)
                .NotEmpty();
        }
    }
}