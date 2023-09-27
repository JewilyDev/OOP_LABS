namespace oop_labs.LAB_2;

public class Point
{
    public Point(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }
    public static Point ReadPoint()
    {
        double x, y, z;
        try
        {
            Console.WriteLine("X: ");
            x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Y: ");
            y = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Z: ");
            z = Convert.ToDouble(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return new Point(x,y,z);
    }
    public double X { get; private set; }
    public double Y { get; private set; }
    public double Z { get; private set; }
}