using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    class Figures
    {
        public static Figure[,] Field = new Figure[8, 8];
        public List<Figure> F = new List<Figure>();
        const int X1 = 100, Y1 = 100; // начальные размеры поля
        void Creating(int x,int y)
        {
            Field[x, y].CreateFigure(x, y, true);
            F.Add(Field[x, y]);
        }
        public Figures()
        {
            //пешки 
            for (int i = 0; i <= 7; i++)
            {
                Field[i, 1] = new Pawn();
                Creating(i, 1);
            }
            for (int i = 0; i <= 7; i++)
            {
                Field[i, 6] = new Pawn();
                Creating(i, 6);
            }
            // ладьи
            Field[0, 0] = new Rook();
            Creating(0, 0);
            Field[0, 7] = new Rook();
            Creating(0, 7);

            Field[7, 0] = new Rook();
            Creating(7, 0);
            Field[7, 7] = new Rook();
            Creating(7, 7);
            //кони
            Field[1, 0] = new Horse();
            Creating(1, 0);
            Field[1, 7] = new Horse();
            Creating(1, 7);

            Field[6, 0] = new Horse();
            Creating(6, 0);
            Field[6, 7] = new Horse();
            Creating(6, 0);
            //слоны
            Field[2, 0] = new Elephant();
            Creating(2, 0);
            Field[2, 7] = new Elephant();
            Creating(2, 7);

            Field[5, 0] = new Elephant();
            Creating(5, 0);
            Field[5, 7] = new Elephant();
            Creating(5, 7);
            //ферзи
            Field[3, 0] = new Queen();
            Creating(3, 0);
            Field[3, 7] = new Queen();
            Creating(3, 7);
            //короли
            Field[4, 0] = new Queen();
            Creating(4, 0);
            Field[4, 7] = new Queen();
            Creating(4, 7);
        }
        public abstract class Figure
        {
            int x;
            int y;
            public int X
            {
                get { return x; }
                set { x = value; }
            }
            public int Y
            {
                get { return y; }
                set { y = value; }
            }
            private bool isTop;
            public Figure()
            {

            }
            public bool IsTop
            {
                get { return isTop; }
            }

            public void CreateFigure(int x, int y, bool isTop)
            {
                this.x = x;
                this.y = y;
                this.isTop = isTop;
            }
            public void CheckList(List<Point> list)
            {
                foreach (Point p in list)
                    if (CheckPoints(p.x, p.y)) list.Remove(p);
            }
            public bool CheckPoints(int x, int y)
            {
                return (y >= 0 && y <= 7 && x >= 0 && x <= 7);
            }
            abstract public List<Point> GetMoves();
            abstract public void Draw(Graphics g);
        }
        class Pawn : Figure //пешка
        {
            public override List<Point> GetMoves()
            {
                List<Point> list = new List<Point>();
                if (IsTop)
                {
                    list.Add(new Point(this.X, this.Y + 1, PointType.Go));
                    list.Add(new Point(this.X + 1, this.Y + 1, PointType.Hit));
                    list.Add(new Point(this.X - 1, this.Y + 1, PointType.Hit));
                }
                else
                {
                    list.Add(new Point(this.X, this.Y - 1, PointType.Go));
                    list.Add(new Point(this.X + 1, this.Y - 1, PointType.Hit));
                    list.Add(new Point(this.X - 1, this.Y - 1, PointType.Hit));
                }
                CheckList(list);
                return list;
            }
            public override void Draw(Graphics g)
            {
                g.DrawEllipse(Pens.Black, 100 + X * 50 - 20, 100 + Y * 50 - 20, 40, 40);
            }
        }

        class Rook : Figure //ладья 
        {
            public override List<Point> GetMoves()
            {
                List<Point> list = new List<Point>();
                int x = X, y = Y;
                while (x >= 0 && x <= 7 && Field[x - 1, y] == null)
                {
                    if (x == X) continue;
                    list.Add(new Point(x, y, PointType.HitAndGo));
                    x++;
                }
                while (x >= 0 && x <= 7 && Field[x + 1, y] == null)
                {
                    if (x == X) continue;
                    list.Add(new Point(x, y, PointType.HitAndGo));
                    x--;
                }
                while (y >= 0 && y <= 7 && Field[x, y - 1] == null)
                {
                    if (y == Y) continue;
                    list.Add(new Point(x, y, PointType.HitAndGo));
                    y++;
                }
                while (y >= 0 && y <= 7 && Field[x, y + 1] == null)
                {
                    if (y == Y) continue;
                    list.Add(new Point(x, y, PointType.HitAndGo));
                    y--;
                }
                return list;
            }
            public override void Draw(Graphics g)
            {
                g.DrawEllipse(Pens.Black, X1 + X * 50 - 20, Y1 + Y * 50 - 20, 40, 40);
            }
        }

        class Horse : Figure //конь
        {
            public override List<Point> GetMoves()
            {
                List<Point> list = new List<Point>();
                list.Add(new Point(X - 1, Y - 2, PointType.HitAndGo));
                list.Add(new Point(X + 1, Y - 2, PointType.HitAndGo));
                list.Add(new Point(X - 1, Y + 2, PointType.HitAndGo));
                list.Add(new Point(X + 1, Y + 2, PointType.HitAndGo));

                list.Add(new Point(X - 2, Y - 1, PointType.HitAndGo));
                list.Add(new Point(X - 2, Y + 1, PointType.HitAndGo));
                list.Add(new Point(X + 2, Y - 1, PointType.HitAndGo));
                list.Add(new Point(X + 2, Y + 1, PointType.HitAndGo));
                CheckList(list);
                return list;
            }
            public override void Draw(Graphics g)
            {
                g.DrawEllipse(Pens.Black, X1 + X * 50 - 20, Y1 + Y * 50 - 20, 40, 40);
            }
        }

        class Elephant : Figure //слон
        {
            public override List<Point> GetMoves()
            {
                List<Point> list = new List<Point>();
                int x = X, y = Y;
                while (CheckPoints(x, y) && Field[x - 1, y - 1] == null)
                {
                    if (x == X) continue;
                    list.Add(new Point(x, y, PointType.HitAndGo));
                    x++; y++;
                }
                while (CheckPoints(x, y) && Field[x - 1, y + 1] == null)
                {
                    if (x == X) continue;
                    list.Add(new Point(x, y, PointType.HitAndGo));
                    x++; y--;
                }
                while (CheckPoints(x, y) && Field[x + 1, y + 1] == null)
                {
                    if (x == X) continue;
                    list.Add(new Point(x, y, PointType.HitAndGo));
                    x--; y--;
                }
                while (CheckPoints(x, y) && Field[x + 1, y - 1] == null)
                {
                    if (x == X) continue;
                    list.Add(new Point(x, y, PointType.HitAndGo));
                    x--; y++;
                }
                return list;
            }
            public override void Draw(Graphics g)
            {
                g.DrawEllipse(Pens.Black, X1 + X * 50 - 20, Y1 + Y * 50 - 20, 40, 40);
            }
        }

        class Queen : Figure //ферзь
        {
            public override List<Point> GetMoves()
            {
                Figure f1 = new Elephant();
                f1.CreateFigure(X, Y, IsTop);
                Figure f2 = new Rook();
                f2.CreateFigure(X, Y, IsTop);
                List<Point> list = (List<Point>)(f1.GetMoves().Union(f2.GetMoves()));
                return list;
            }
            public override void Draw(Graphics g)
            {
                g.DrawEllipse(Pens.Black, X1 + X * 50 - 20, Y1 + Y * 50 - 20, 40, 40);
            }
        }

        class King : Figure //король
        {
            public override List<Point> GetMoves()
            {
                List<Point> list = new List<Point>();
                list.Add(new Point(X - 1, Y - 1, PointType.HitAndGo));
                list.Add(new Point(X - 1, Y, PointType.HitAndGo));
                list.Add(new Point(X - 1, Y + 1, PointType.HitAndGo));

                list.Add(new Point(X, Y - 1, PointType.HitAndGo));
                list.Add(new Point(X, Y + 1, PointType.HitAndGo));

                list.Add(new Point(X + 1, Y - 1, PointType.HitAndGo));
                list.Add(new Point(X + 1, Y, PointType.HitAndGo));
                list.Add(new Point(X + 1, Y + 1, PointType.HitAndGo));

                return list;
            }
            public override void Draw(Graphics g)
            {
                g.DrawEllipse(Pens.Black, X1 + X * 50 - 20, Y1 + Y * 50 - 20, 40, 40);
            }
        }
    }
}
