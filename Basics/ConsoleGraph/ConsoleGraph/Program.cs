using System;

namespace ConsoleGraph
{
  class Program
  {
    static int W = 60;
    static int H = 30;
    static float x1 = -3.0f;
    static float x2 = 3.0f;
    static float y1 = -0.1f;
    static float y2 = 1.2f;

    static int II(float x)
    {
      return (int) (0 + (x - x1) * W / (x2 - x1));
    }

    static int JJ(float y)
    {
      return (int) (0 + (y - y2) * H / (y1 - y2));
    }

    static void Main(string[] args)
    {
      Console.SetWindowSize(W, H);
      Console.BackgroundColor = ConsoleColor.White;
      Console.ForegroundColor = ConsoleColor.Red;
      Console.Clear();

      float h = (x2 - x1) / W;
      float x = x1 - h;

      for (int i = 0; i < H; i++)
      {
        Console.SetCursorPosition(II(0), i);
        Console.Write("|");
      }

      for (int i = 0; i < W; i++)
      {
        x = x + h;
        Console.SetCursorPosition(II(x), JJ(0));
        Console.Write("-");

        float y = (float) Math.Exp(-x * x);
        int b = JJ(y);
        if (b >= 0 && b < H)
        {
          Console.SetCursorPosition(II(x), b);
          Console.Write("*");
        }
      }

      Console.ReadKey();
    }
  }
}
