using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    struct Point
    {
        public Point(int x, int y, PointType Type)
        {
            this.x = x;
            this.y = y;
            this.Type = Type;
        }
        public int x;
        public int y;
        PointType Type;
    }
    enum PointType { Go, Hit, HitAndGo}
    enum Figure_ID { Pawn_ID, Rook_ID, Horse_ID, Elephant_ID, Queen_ID, King_ID}
    class Commons
    {
    }
}
