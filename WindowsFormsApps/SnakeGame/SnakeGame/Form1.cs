using System;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeGame
{
  public partial class Form1 : Form
  {
    private int SnakeX, SnakeY;
    private int SnakeDirectionX;
    private int SnakeDirectionY;
    private const int CellSize = 40;
    private Point[] Tail;
    private bool isStepLocked;
    private Point FoodPosition;
    private Random random;
    private Bitmap SnakeTailImg;
    private Bitmap SnakeHeadImg;

    public Form1()
    {
      InitializeComponent();
      SetStyle(ControlStyles.UserPaint
               | ControlStyles.AllPaintingInWmPaint
               | ControlStyles.DoubleBuffer, true);
      SnakeHeadImg = Images.SnakeHead;
      SnakeTailImg = Images.SnakeTail;
      SnakeDirectionX = 1;
      SnakeDirectionY = 0;
      Tail = new Point[3];
      FoodPosition = new Point(5, 5);
      random = new Random();
      CreateFood();
    }

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Up:
          SetDirection(0, -1);
          break;
        case Keys.Down:
          SetDirection(0, 1);
          break;
        case Keys.Left:
          SetDirection(-1, 0);
          break;
        case Keys.Right:
          SetDirection(1, 0);
          break;
      }
    }

    private void SetDirection(int x, int y)
    {
      if ((SnakeDirectionX * -1 == x && SnakeDirectionY * -1 == y) ||
          isStepLocked)
      {
        return;
      }

      SnakeDirectionX = x;
      SnakeDirectionY = y;

      isStepLocked = true;
    }

    private void GameUpdate_Tick(object sender, System.EventArgs e)
    {
      PushToTail(new Point(SnakeX, SnakeY));


      SnakeX += SnakeDirectionX;
      SnakeY += SnakeDirectionY;
      if (SnakeX > 15)
      {
        SnakeX = 0;
      }
      if (SnakeX < 0)
      {
        SnakeX = 15;
      }

      if (SnakeY > 15)
      {
        SnakeY = 0;
      }
      if (SnakeY < 0)
      {
        SnakeY = 15;
      }

      isStepLocked = false;

      if (SnakeX == FoodPosition.X && SnakeY == FoodPosition.Y)
      {
        Array.Resize(ref Tail, Tail.Length + 1);
        CreateFood();
      }
      Refresh();
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
      var graphics = e.Graphics;
      var brush = Brushes.Green;
      var tailBrush = Brushes.Blue;
      var foodBrush = Brushes.Red;
      // graphics.FillRectangle(brush, new Rectangle(
      //   SnakeX * CellSize,
      //   SnakeY * CellSize,
      //   CellSize,
      //   CellSize));
      graphics.DrawImage(SnakeHeadImg, new Rectangle(
        SnakeX * CellSize,
        SnakeY * CellSize,
        CellSize,
        CellSize));

      for (int i = 0; i < Tail.Length; i++)
      {
        // graphics.FillRectangle(tailBrush, new Rectangle(
        //   Tail[i].X * CellSize,
        //   Tail[i].Y * CellSize,
        //   CellSize,
        //   CellSize));
        graphics.DrawImage(SnakeTailImg, new Rectangle(
          Tail[i].X * CellSize,
          Tail[i].Y * CellSize,
          CellSize,
          CellSize));
      }

      graphics.FillRectangle(foodBrush, new Rectangle(
        FoodPosition.X * CellSize,
        FoodPosition.Y * CellSize,
        CellSize,
        CellSize));
    }

    private void PushToTail(Point point)
    {
      for (int i = Tail.Length - 1; i > 0; i--)
      {
        Tail[i] = Tail[i - 1];
      }

      Tail[0] = point;
    }

    private void CreateFood()
    {
      FoodPosition.X = random.Next(0, 16);
      FoodPosition.Y = random.Next(0, 16);
    }
  }
}
