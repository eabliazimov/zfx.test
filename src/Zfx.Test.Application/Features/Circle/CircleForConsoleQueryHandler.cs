using MediatR;
using System.Text;

namespace Zfx.Test.Application.Features.Circle
{
    internal class CircleForConsoleQueryHandler : IRequestHandler<CircleForConsoleQuery, ConsoleStringLines>
    {
        public async Task<ConsoleStringLines> Handle(CircleForConsoleQuery request, CancellationToken cancellationToken = default)
        {
            var consoleStringLines = new ConsoleStringLines();

            for (double y = request.Radius; y >= -request.Radius; y -= 1)
            {
                var stringBuilder = new StringBuilder();

                for (double x = -request.Radius; x <= request.Radius; x += 0.5)
                {
                    double r = x * x + y * y;
                    stringBuilder.Append(Math.Abs(Math.Sqrt(r) - request.Radius) < 0.2 ? "*" : " ");
                }
                consoleStringLines.AppendLine(stringBuilder.ToString());
            }

            return consoleStringLines;
        }
    }
}
