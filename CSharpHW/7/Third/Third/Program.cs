using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Third
{
    class Program
    {
        static void Main(string[] args)
        {
            Point A = new Point(1,1);
            Point B = new Point(3,3);
            Point C = new Point(1,1);
            Point D = new Point(1,5);

            ShapeDescriptor ABC = new ShapeDescriptor(A,B,D);
            Console.WriteLine(ABC.shapeType);
            Console.ReadLine();
        }
    }
}
