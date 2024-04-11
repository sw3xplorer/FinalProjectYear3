namespace FinalProjectYear3;

public class ClearArea
{
    // A method used to clear a determined area on the screen.
    public static void Clear(int startX, int startY, int endX, int endY)
    {
        for (int i = startX; i < endX; i++)
        {
                for (int j = startY; j < endY; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");

                }
        }
    }
}
