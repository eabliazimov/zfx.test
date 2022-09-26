using EnsureThat;
using FluentValidation;
using MediatR;
using System;
using System.Threading.Tasks;
using Zfx.Test.Application.Features;
using Zfx.Test.Application.Features.Circle;
using Zfx.Test.Application.Features.Rectangle;
using Zfx.Test.Application.Features.Triangle;
using Zfx.Test.Runner.Exceptions;

namespace Zfx.Test.Runner
{
    internal class ZfxIORunner
    {
        private readonly IMediator _mediator;
        private readonly IZfxConsole _zfxConsole;

        public ZfxIORunner(IMediator mediator, IZfxConsole zfxConsole)
        {
            _mediator = Ensure.Any.IsNotNull(mediator, nameof(mediator));
            _zfxConsole = Ensure.Any.IsNotNull(zfxConsole, nameof(zfxConsole));
        }

        public async Task RunAsync()
        {
            while (true)
            {
                try
                {
                    var chosenOption = _zfxConsole.SelectShape();
                    ConsoleStringLines result;

                    switch (chosenOption)
                    {
                        case (int)ZfxInputs.Circle:
                            var radius = _zfxConsole.SelectCircleRaduis();
                            result = await _mediator.Send(new CircleForConsoleQuery(radius));
                            break;
                        case (int)ZfxInputs.Rectangle:
                            var rectangle = _zfxConsole.SelectRectangleSidesLength();
                            result = await _mediator.Send(new RectangleForConsoleQuery(rectangle.SideA, rectangle.SideB));
                            break;
                        case (int)ZfxInputs.Square:
                            var squareLength = _zfxConsole.SelectSquareLength();
                            result = await _mediator.Send(new RectangleForConsoleQuery(squareLength, squareLength));
                            break;
                        case (int)ZfxInputs.Triangle:
                            var triangle = _zfxConsole.SelectTriangleVerticesLength();
                            result = await _mediator.Send(new TriangleForConsoleQuery(triangle.VertexA, triangle.VertexB, triangle.VertexC));
                            break;
                        default:
                            throw new WrongInputValidationException();

                    }

                    foreach (var el in result)
                    {
                        _zfxConsole.WriteLine(el);
                    }

                    _zfxConsole.WriteLine();
                }
                catch (ValidationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ExitRequestedException)
                {
                    return;
                }
            }
        }
    }
}
