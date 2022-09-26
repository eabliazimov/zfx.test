using MediatR;
using System.Text;

namespace Zfx.Test.Application.Features.Rectangle
{
    internal class RectangleForConsoleQueryHandler : IRequestHandler<RectangleForConsoleQuery, ConsoleStringLines>
    {
        public async Task<ConsoleStringLines> Handle(RectangleForConsoleQuery request, CancellationToken cancellationToken)
        {
            var consoleStringLines = new ConsoleStringLines();

            for (double y = 0; y <= request.SideB; y++)
            {
                var stringBuilder = new StringBuilder();

                for (double x = 0; x <= request.SideA; x+=0.5)
                {
                    stringBuilder.Append(
                        y == 0
                        || y == request.SideB
                        || x == 0
                        || x == request.SideA
                        ? "*" : " ");
                }
                consoleStringLines.AppendLine(stringBuilder.ToString());
            }

            return consoleStringLines;
        }
    }
}
