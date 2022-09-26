namespace Zfx.Test.Runner
{
    internal interface IZfxConsole
    {
        int SelectShape();
        int SelectCircleRaduis();
        (int SideA, int SideB) SelectRectangleSidesLength();
        int SelectSquareLength();
        (int VertexA, int VertexB, int VertexC) SelectTriangleVerticesLength();
        void WriteLine(string line);
        void WriteLine();
        string ReadLine();
    }
}
