using System;
using Zfx.Test.Runner.Exceptions;

namespace Zfx.Test.Runner
{
    internal class ZFxConsole : IZfxConsole
    {
        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public int SelectShape()
        {
            Console.WriteLine("Please enter integer from 1 to 4 to choose the shape that you want to draw or q to exit:");
            Console.WriteLine("1 - Circle");
            Console.WriteLine("2 - Rectangle");
            Console.WriteLine("3 - Square");
            Console.WriteLine("4 - Triangle");

            var chosenOption = Console.ReadLine();
            if (chosenOption == "q")
                throw new ExitRequestedException();

            if (!int.TryParse(chosenOption, out int resut))
                throw new WrongInputValidationException();

            return resut;
        }

        public int SelectCircleRaduis()
        {
            Console.WriteLine("Please enter Circle Radius (integer):");
            if (!int.TryParse(Console.ReadLine(), out int radius))
                throw new WrongInputValidationException();

            return radius;
        }

        public (int SideA, int SideB) SelectRectangleSidesLength()
        {
            Console.WriteLine("Please enter Rectangle side A length (integer):");
            if (!int.TryParse(Console.ReadLine(), out int sideA))
                throw new WrongInputValidationException();

            Console.WriteLine("Please enter Rectangle side B length (integer):");
            if (!int.TryParse(Console.ReadLine(), out int sideB))
                throw new WrongInputValidationException();

            return (sideA, sideB);
        }

        public int SelectSquareLength()
        {
            Console.WriteLine("Please enter Square length (integer):");
            if (!int.TryParse(Console.ReadLine(), out int squareLength))
                throw new WrongInputValidationException();

            return squareLength;
        }

        public (int VertexA, int VertexB, int VertexC) SelectTriangleVerticesLength()
        {
            Console.WriteLine("Please enter Triangle vertex A length (integer):");
            if (!int.TryParse(Console.ReadLine(), out int vertexA))
                throw new WrongInputValidationException();

            Console.WriteLine("Please enter Triangle vertex B length (integer):");
            if (!int.TryParse(Console.ReadLine(), out int vertexB))
                throw new WrongInputValidationException();

            Console.WriteLine("Please enter Triangle vertex C length (integer):");
            if (!int.TryParse(Console.ReadLine(), out int vertexC))
                throw new WrongInputValidationException();

            return (vertexA, vertexB, vertexC);
        }
    }
}
