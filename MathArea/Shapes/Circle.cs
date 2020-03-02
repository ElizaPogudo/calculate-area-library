using System;

namespace MathArea.Shapes
{
    public class Circle : IAreable
    {
        //закрытое поле данных радиус
        private double _radius;

        //конструкторы
        public Circle() { }
        public Circle(double radius)
        {
            _radius = radius;
        }

        //свойство радиус
        public double Radius
        { 
            get { return _radius; } 
            set
            {
                if (value <= 0d)
                     new Exception("Радиус круга должен быть больше нуля.");
                else { Radius = _radius; }
            }
        }

        //Метод вычисления площади
        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }








}
