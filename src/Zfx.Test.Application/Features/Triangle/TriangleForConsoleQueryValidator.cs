using FluentValidation;

namespace Zfx.Test.Application.Features.Triangle
{
    internal class TriangleForConsoleQueryValidator : AbstractValidator<TriangleForConsoleQuery>
    {
        public TriangleForConsoleQueryValidator()
        {
            RuleFor(q => q.VerticeA).GreaterThan(0);
            RuleFor(q => q.VerticeB).GreaterThan(0);
            RuleFor(q => q.VerticeC).GreaterThan(0);
            When(q => q.VerticeC > 0 && q.VerticeB > 0 && q.VerticeC > 0,
                () =>
                {
                    RuleFor(q => q).Must(q =>
                    {
                        if (q.VerticeA < q.VerticeB + q.VerticeC
                            && q.VerticeB < q.VerticeA + q.VerticeC
                            && q.VerticeC < q.VerticeB + q.VerticeA)
                        {
                            return true;
                        }

                        return false;
                    }).WithMessage("Triangle must follow it's geometrical properties: For a triangle with vertices a, b and c: 1. a + b > c; 2. a + c > b; 3. b + c > a");
                });
        }
    }
}
