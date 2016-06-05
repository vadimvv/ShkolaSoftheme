using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Third
{
    class ShapeDescriptor
    {
        public readonly string shapeType;
        public ShapeDescriptor(Point x, Point y)
        {
            shapeType = (x.IsEqual(y)) ? "Dote" : "Line";
        }

        public ShapeDescriptor(Point x, Point y, Point z)
        {
            if (x.IsEqual(y) && y.IsEqual(z))
                shapeType = "Dote";
            else if (x.IsEqual(y) || y.IsEqual(z) || x.IsEqual(z))
                shapeType = "Line";
            else shapeType = "Triangle";
        }
        

        //public ShapeDescriptor(Point[] points)
        //{
        //    int counter = 0;
        //    int unique = points.Length;
        //    for (int i = 0; i < points.Length; i++)
        //    {
        //        for (int j = i; j < points.Length; j++)
        //        {
        //            if (points[i].IsEqual(points[j]))
        //                unique--;
        //            if (points[i].IsLineWithPoint(points[j]))
        //                counter++;
        //        }
        //        if (counter > 1)
        //            counter = unique - counter + 2;
        //    }
        //    ShapeType = counter + "- gon";
        //}

    }
}
