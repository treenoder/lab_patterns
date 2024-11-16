namespace Graphics;

// Цільовий інтерфейс, який очікують розробники
public interface ICommonGraphics
{
    void DrawLine(int x1, int y1, int x2, int y2);
    void DrawCircle(int centerX, int centerY, int radius);
}

// Оригінальний інтерфейс LibraryA
public class LibraryA
{
    public void RenderLine(int startX, int startY, int endX, int endY)
    {
        Console.WriteLine($"LibraryA: Rendering line from ({startX}, {startY}) to ({endX}, {endY})");
    }

    public void RenderCircle(int x, int y, int r)
    {
        Console.WriteLine($"LibraryA: Rendering circle at ({x}, {y}) with radius {r}");
    }
}

// Оригінальний інтерфейс LibraryB
public class LibraryB
{
    public void Draw(int x1, int y1, int x2, int y2)
    {
        Console.WriteLine($"LibraryB: Drawing line from ({x1}, {y1}) to ({x2}, {y2})");
    }

    public void Circle(int centerX, int centerY, int radius)
    {
        Console.WriteLine($"LibraryB: Drawing circle at ({centerX}, {centerY}) with radius {radius}");
    }
}

// Адаптер для LibraryA
public class LibraryAAdapter : ICommonGraphics
{
    private LibraryA _libraryA;

    public LibraryAAdapter(LibraryA libraryA)
    {
        _libraryA = libraryA;
    }

    public void DrawLine(int x1, int y1, int x2, int y2)
    {
        _libraryA.RenderLine(x1, y1, x2, y2);
    }

    public void DrawCircle(int centerX, int centerY, int radius)
    {
        _libraryA.RenderCircle(centerX, centerY, radius);
    }
}

// Адаптер для LibraryB
public class LibraryBAdapter : ICommonGraphics
{
    private LibraryB _libraryB;

    public LibraryBAdapter(LibraryB libraryB)
    {
        _libraryB = libraryB;
    }

    public void DrawLine(int x1, int y1, int x2, int y2)
    {
        _libraryB.Draw(x1, y1, x2, y2);
    }

    public void DrawCircle(int centerX, int centerY, int radius)
    {
        _libraryB.Circle(centerX, centerY, radius);
    }
}

// Клієнтський код
public class GraphicsClient
{
    private ICommonGraphics _graphics;

    public GraphicsClient(ICommonGraphics graphics)
    {
        _graphics = graphics;
    }

    public void DrawShapes()
    {
        _graphics.DrawLine(10, 10, 100, 100);
        _graphics.DrawCircle(50, 50, 25);
    }
}

public class Program
{
    public static void Main()
    {
        LibraryA libraryA = new LibraryA();
        ICommonGraphics adapterA = new LibraryAAdapter(libraryA);
        GraphicsClient clientA = new GraphicsClient(adapterA);
        clientA.DrawShapes();

        Console.WriteLine();

        LibraryB libraryB = new LibraryB();
        ICommonGraphics adapterB = new LibraryBAdapter(libraryB);
        GraphicsClient clientB = new GraphicsClient(adapterB);
        clientB.DrawShapes();
    }
}

// Output:
// LibraryA: Rendering line from (10, 10) to (100, 100)
// LibraryA: Rendering circle at (50, 50) with radius 25
// 
// LibraryB: Drawing line from (10, 10) to (100, 100)
// LibraryB: Drawing circle at (50, 50) with radius 25