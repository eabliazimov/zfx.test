using FluentValidation;

namespace Zfx.Test.Application.Features.Rectangle
{
    internal class RectangleForConsoleQueryValidator : AbstractValidator<RectangleForConsoleQuery>
    {
        public RectangleForConsoleQueryValidator()
        {
            RuleFor(q => q.SideA).GreaterThan(0);
            RuleFor(q => q.SideB).GreaterThan(0);
        }
    }
}
