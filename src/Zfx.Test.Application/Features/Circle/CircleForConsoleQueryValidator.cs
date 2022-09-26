using FluentValidation;

namespace Zfx.Test.Application.Features.Circle
{
    internal class CircleForConsoleQueryValidator : AbstractValidator<CircleForConsoleQuery>
    {
        public CircleForConsoleQueryValidator()
        {
            RuleFor(q => q.Radius)
                .GreaterThan(0);
        }
    }
}
