using MediatR;

namespace Zfx.Test.Application.Features.Triangle
{
    public class TriangleForConsoleQuery : IRequest<ConsoleStringLines>
    {
        public int VerticeA { get; }
        public int VerticeB { get; }
        public int VerticeC { get; }

        public TriangleForConsoleQuery(int verticeA, int verticeB, int verticeC)
        {
            VerticeA = verticeA;
            VerticeB = verticeB;
            VerticeC = verticeC;
        }
    }
}