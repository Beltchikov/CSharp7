using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7
{
    public class PatternMatching
    {
        public class Square
        {
            public double Side { get; }

            public Square(double side)
            {
                Side = side;
            }
        }
        public class Circle
        {
            public double Radius { get; }

            public Circle(double radius)
            {
                Radius = radius;
            }
        }

        // The is type pattern expression
        // NEW
        public static double ComputeAreaNew(object shape)
        {
            if (shape is Square s)
            {
                return s.Side * s.Side;
            }
            else if (shape is Circle c)
            {
                return c.Radius * c.Radius * Math.PI;
            }

            throw new ArgumentException();
        }

        // Pattern matching switch
        // NEW
        public static double ComputeAreaModernSwitch(object shape)
        {
            switch (shape)
            {
                case Square s:
                    return s.Side * s.Side;
                case Circle c:
                    return c.Radius * c.Radius * Math.PI;
                default:
                    throw new ArgumentException();
            }
        }

        // When clause in case expression
        // NEW
        public static double ComputeAreaSwitch(object shape)
        {
            switch (shape)
            {
                case Square s when s.Side == 0:
                case Circle c when c.Radius == 0:
                    return 0;

                case Square s:
                    return s.Side * s.Side;
                case Circle c:
                    return c.Radius * c.Radius * Math.PI;
                case null:
                    throw new ArgumentNullException(paramName: nameof(shape), message: "Shape must not be null");
                default:
                    throw new ArgumentException();
            }
        }

        // var declarations in case expressions
        static object CreateShape(string shapeDescription)
        {
            switch (shapeDescription)
            {
                case "circle":
                    return new Circle(2);
                case "square":
                    return new Square(4);
                case "large-circle":
                    return new Circle(12);
                case var o when (o?.Trim().Length ?? 0) == 0: // white space
                    return null;
                default:
                    return "invalid shape description";
            }
        }

    }
}
