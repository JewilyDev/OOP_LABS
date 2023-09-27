namespace oop_labs.LAB_1;

public abstract class NumericalCalculus
{
    protected NumericalCalculus(double accuracy, int pointsAmount)
    {
        if (accuracy <= 0)
        {
            throw new Exception("Calculus accuracy has to be positive");
        }

        if (pointsAmount <= 0)
        {
            throw new Exception("Amount of points has to be positive");
        }
        
        Accuracy = accuracy;
        PointsAmount = pointsAmount;
    }
    
    protected double Accuracy { get;  init; }
    
    protected int PointsAmount { get;  init; }

    public abstract double Calc(Func<double, double> fn, double lowerBracket, double upperBracket);
} 

