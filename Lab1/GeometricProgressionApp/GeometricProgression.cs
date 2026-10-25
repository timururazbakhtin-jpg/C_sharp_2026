using System;

namespace GeometricProgressionApp
{
    public class GeometricProgression : IGeometricProgression
    {
        public double FirstElement { get; }
        public double Ratio { get; }

        public GeometricProgression(double firstElement, double ratio)
        {
            FirstElement = firstElement;
            Ratio = ratio;
        }

        public GeometricProgression Add(GeometricProgression other)
        {
            if (this.Ratio != other.Ratio)
            {
                throw new ArgumentException("Коефіцієнти прогресій повинні збігатися для додавання.");
            }
            return new GeometricProgression(this.FirstElement + other.FirstElement, this.Ratio);
        }

        public GeometricProgression Subtract(GeometricProgression other)
        {
            if (this.Ratio != other.Ratio)
            {
                throw new ArgumentException("Коефіцієнти прогресій повинні збігатися для віднімання.");
            }
            return new GeometricProgression(this.FirstElement - other.FirstElement, this.Ratio);
        }

        public GeometricProgression Multiply(double number)
        {
            return new GeometricProgression(this.FirstElement * number, this.Ratio);
        }

        public double GetSum(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n), "Кількість елементів має бути більшою за нуль.");
            }

            if (Math.Abs(Ratio - 1.0) < 0.0001)
            {
                return FirstElement * n;
            }

            return FirstElement * (Math.Pow(Ratio, n) - 1) / (Ratio - 1);
        }

        public double GetElement(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n), "Номер елемента має бути додатним.");
            }

            return FirstElement * Math.Pow(Ratio, n - 1);
        }

        public override bool Equals(object? obj)
        {
            if (obj is GeometricProgression other)
            {
                return Math.Abs(this.FirstElement - other.FirstElement) < 0.0001 &&
                       Math.Abs(this.Ratio - other.Ratio) < 0.0001;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstElement, Ratio);
        }

        public override string ToString()
        {
            return $"Геометрична прогресія: b1 = {FirstElement}, q = {Ratio}";
        }
    }
}