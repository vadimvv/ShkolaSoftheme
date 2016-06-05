using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Third
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x,int y)
        {
            X = x;
            Y = y;
        }

        public bool IsEqual(Point A)
        {
            return X == A.X && Y == A.Y;
        }

        public bool IsLineWithPoint(Point A)
        {
            if (this.IsEqual(A)) return false;
            return X == A.X || Y == A.Y;
        }

        
    }
}
