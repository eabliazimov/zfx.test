using MediatR;

namespace Zfx.Test.Application.Features.Circle
{
    public class CircleForConsoleQuery : IRequest<ConsoleStringLines>
    {
        public int Radius { get; }

        public CircleForConsoleQuery(int radius)
        {
            Radius = radius;
        }
    }
}
