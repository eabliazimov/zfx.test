using MediatR;
using System.Text;

namespace Zfx.Test.Application.Features.Triangle
{
    internal class TriangleForConsoleQueryHandler : IRequestHandler<TriangleForConsoleQuery, ConsoleStringLines>
    {
        public async Task<ConsoleStringLines> Handle(TriangleForConsoleQuery request, CancellationToken cancellationToken)
        {
            var consoleStringLines = new ConsoleStringLines();
            var vertices = new[] { request.VerticeA, request.VerticeB, request.VerticeC }.OrderByDescending(x => x).ToArray();
            var verticesIntersectionPoint = IntersectionOfTwoCircles(vertices[0], vertices[1], vertices[2]);
            
            var k1 = verticesIntersectionPoint.Y / verticesIntersectionPoint.X;
            var b1 = 0;

            var k2 = -verticesIntersectionPoint.Y / (vertices[0] - verticesIntersectionPoint.X);
            var b2 = verticesIntersectionPoint.Y - k2 * verticesIntersectionPoint.X;

            for (double y = verticesIntersectionPoint.Y; y > 0; y -= 0.5)
            {
                var stringBuilder = new StringBuilder();

                for (double x = 0; x < vertices[0]; x += 0.25)
                {
                    if(Math.Abs(x * k1 + b1 - y) < 0.15 || Math.Abs(x * k2 + b2 - y) < 0.15)
                    {
                        stringBuilder.Append('*');
                    }
                    else
                    {
                        stringBuilder.Append(' ');
                    }
                }

                if (y == 0)
                {
                    stringBuilder.Append('*');
                }

                consoleStringLines.AppendLine(stringBuilder.ToString());
            }

            consoleStringLines.AppendLine(new string('*', (int)(vertices[0]/0.25) + 1));

            return consoleStringLines;

            // Use Paul Burke's algorithm to calculate Positive Intersaction Of Two Circles
            // http://paulbourke.net/geometry/circlesphere/
            (double X, double Y) IntersectionOfTwoCircles(int a, int b, int c)
            {
                //distance from the beginning of coodinates to the triangle's height on x axis
                var distanceToHOnX = ((b * b) - (c * c) + (a * a)) / (2.0d * a);
                var height = Math.Sqrt(b * b - distanceToHOnX * distanceToHOnX);

                return (X: distanceToHOnX, Y: height);
            }
        }
    }
}
