namespace oop_labs.LAB_1;

public class SimpsonMethodCalculator : NumericalCalculus
{
    public SimpsonMethodCalculator(double accuracy, int pointsAmount) : base(accuracy, pointsAmount){}
    
    public override double Calc(Func<double, double> fn, double lowerBracket, double upperBracket)
    {
        double h = (upperBracket - lowerBracket) / (2 * PointsAmount);
        double result = 0;
        double oddSum = 0;
        double evenSum = 0;
        int index = 1;
        for (double x = lowerBracket; x < upperBracket; x+=h)
        {
            if (index % 2 == 0)
            {
                oddSum += fn(x);
            }
            else
            {
                evenSum += fn(x);
            }
            index++;
        }
        result = (fn(lowerBracket) + fn(upperBracket) + 2 * oddSum + 4 * evenSum) * (h / 3);
        return Math.Round(result,int.Abs((int)Math.Log10(Accuracy)));
    }
}