using System;
using System.Collections.Generic;
using System.Linq;


namespace MathArea.Shapes
{
    /// <summary>
    /// Треугольник
    /// </summary>
    public class Triangle : IAreable
    {
        #region Поля данных
        private IList<double> _sides;
        private IList<Point> _points;
        #endregion

        #region Конструкторы
        public Triangle()
        {
            _sides = new List<double>();
            _points = new List<Point>();
        }
        public Triangle(IList<double> sides)
        {
            _sides = sides;
            _points = new List<Point>();
        }
        
        public Triangle(IList<Point> points)
        {
            _points = points;
            _sides = new List<double>();
        }
        #endregion

        #region Свойства
        /// <summary>
        /// Стороны
        /// </summary>
        public virtual IList<double> Sides
        {
            get { return _sides; }
            set
            {
                if(value.Count > 3)
                    new Exception("Количество сторон треугольника не может быть больше трёх.");
                if(!IsTriangle(value))
                    new Exception("Такого треугольника не существует.");

                foreach (var side in value)
                {
                    if (side <= 0d)
                        new Exception("Сторона треугольника должна быть больше нуля.");
                    else { _sides.Add(side); }
                }
                    
            }    
        }

        /// <summary>
        /// Координаты вершин
        /// </summary>
        public virtual IList<Point> Points
        {
            get { return _points; }
            set
            {
                if (value.Count > 3)
                    new Exception("Количество сторон треугольника не может быть больше трёх.");
                if (!IsTriangle(GetSides(value)))
                    new Exception("Такого треугольника не существует.");
                _points.ToList().AddRange(value);
            }
        }
        #endregion

        #region Методы
        /// <summary>
        /// Вычисление площади, возвращает -1 при отсутсвии достачных для расчетов исходных данных
        /// </summary>
        /// <returns></returns>
        public double GetArea()
        {
            //если известны три стороны
            if (_sides.Count == 3)
                return ThreeSidesArea(_sides);

            //если известны координаты вершин
            if (GetSides(Points).Count == 3)
                return ThreeSidesArea(GetSides(Points));

            return -1d;
        }
        #endregion

        #region Закрытые методы
        //вычисление площади по трём сторонам
        private double ThreeSidesArea(IList<double> sides)
        {
                if (IsEquilateral(sides))
                    return Math.Sqrt(3d) * sides.FirstOrDefault() / 4;
                if (IsRectangular(sides))
                {
                    var perpendiculars = sides.OrderBy(x => x).Take(2).ToList();
                    // S = a*b/2, где a,b - катеты
                    return perpendiculars[0] * perpendiculars[0] / 2;
                }
                //полупериметр треугольника
                var p = sides.Sum() / 2;
                //формула Герона
                return Math.Sqrt(p * (p - sides[0]) * (p - sides[1]) * (p - sides[2]));
          
        }
        //является ли фигура треугольником
        private bool IsTriangle(IList<double> sides)
        {           
            return sides[0] + sides[1] > sides[2] && Math.Abs(sides[0] - sides[1]) < sides[2];
        }
        //является ли треугольник равносторонним
        private bool IsEquilateral(IList<double> sides)
        {
            return sides[0] == sides[1] && sides[1] == sides[2];
        }
        //является ли треугольник прямоугольным
        private bool IsRectangular(IList<double> sides)
        {
            //определение потенциальных катетов треугольника
            var perpendiculars = sides.OrderBy(x => x).Take(2).ToList();
            //возведение в квадрат потенциальных катетов треугольника
            perpendiculars.ForEach(x => Math.Pow(x, 2));
            //теорема Пифагора
            return Math.Pow(sides.Max(), 2) == perpendiculars.Sum();
        }
        //вычисление длин сторон по координатам вершин
        private IList<double> GetSides(IList<Point> points)
        {
            if (points.Count != 3)
                new Exception("Неверное количество координат вершин треугольника.");

            var result = new List<double>(); 
            //вершина А(points[0].X, points[0].Y), B(points[1].X, points[1].Y), C(points[2].X, points[2].Y)
            var AB = Math.Sqrt(Math.Pow(points[1].X - points[0].X, 2) + Math.Pow(points[1].Y - points[0].Y, 2));
            var AC = Math.Sqrt(Math.Pow(points[2].X - points[0].X, 2) + Math.Pow(points[2].Y - points[0].Y, 2));
            var BC = Math.Sqrt(Math.Pow(points[2].X - points[1].X, 2) + Math.Pow(points[2].Y - points[1].Y, 2));

            result.Add(AB);
            result.Add(AC);
            result.Add(BC);

            return result;
        }
        #endregion

    }

    /// <summary>
    /// Координаты вершины треугольника
    /// </summary>
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point() {}
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

}
