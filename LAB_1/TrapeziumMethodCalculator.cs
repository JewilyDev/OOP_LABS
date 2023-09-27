namespace oop_labs.LAB_1;

public class TrapeziumMethodCalculator : NumericalCalculus
{
    public TrapeziumMethodCalculator(double accuracy, int pointsAmount) : base(accuracy, pointsAmount){}

    public override double Calc(Func<double, double> fn, double lowerBracket, double upperBracket)
    {
        double h = (upperBracket - lowerBracket) / (PointsAmount);
        double result = 0;
        double x = lowerBracket;
        while (x <= upperBracket)
        {
            result += (fn(x) * h) + ((fn(x + h) - fn(x)) * (h / 2));
            x += h;
        }

        return Math.Round(result,int.Abs((int)Math.Log10(Accuracy)));
        
    }
}