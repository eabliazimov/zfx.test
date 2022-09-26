using MediatR;

namespace Zfx.Test.Application.Features.Rectangle
{
    public class RectangleForConsoleQuery : IRequest<ConsoleStringLines>
    {
        public int SideA { get;  }
        public int SideB { get; }

        public RectangleForConsoleQuery(int sideA, int sideB)
        {
            SideA = sideA;
            SideB = sideB;
        }
    }
}
