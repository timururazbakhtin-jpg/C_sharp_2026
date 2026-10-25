namespace GeometricProgressionApp
{
    public interface IGeometricProgression
    {
        double FirstElement { get; }
        double Ratio { get; }
        
        GeometricProgression Add(GeometricProgression other);
        GeometricProgression Subtract(GeometricProgression other);
        GeometricProgression Multiply(double number);
        double GetSum(int n);
        double GetElement(int n);
    }
}