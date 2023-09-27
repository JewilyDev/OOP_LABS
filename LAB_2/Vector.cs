
namespace oop_labs.LAB_2;

public class VectorL
{
    
    private static readonly double Precision = 0.001;

    public static readonly VectorL I = new VectorL(1, 0, 0);
    
    public static readonly VectorL J = new VectorL(0, 1, 0);
    
    public static readonly VectorL K = new VectorL(0, 0, 1);
    
    public static readonly VectorL NullVector = new VectorL(0, 0, 0);
    
    public double X { get; }
    public double Y { get; }
    public double Z { get; }
    public double Length { get; }
    
    public static double VectorProjection(VectorL u, VectorL axis)
    {
        return (Math.Cos(AngleBetween(u, axis))) * u.Length;
    }
    
    public VectorL(Point a, Point b)
    {
        X = b.X - a.X;
        Y = b.Y - a.Y;
        Z = b.Z - a.Z;
        Length = Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));
    }
    
    public VectorL(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
        Length = Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));
    }

    public static double Distance(VectorL u, VectorL v)
    {
        return (Math.Sqrt(Math.Pow(u.X - v.X, 2) + Math.Pow(u.Y - v.Y, 2) + Math.Pow(u.Z - v.Z, 2)));
    }

    public static bool IsCollinear(VectorL u, VectorL v)
    {
        return (u == NullVector || v == NullVector) || (AngleBetween(u, v) == 0 || Math.Abs((AngleBetween(u,v) - Math.PI)) < Precision);
    }

    public static bool IsCoplanar(VectorL u, VectorL v, VectorL w)
    {
        return (w * (u & v)) == 0;
    }
    public static double AngleBetween(VectorL u, VectorL v)
    {
        if (v == NullVector || u == NullVector)
        {
            throw new Exception("Vectors should not be null");
        }
        return Math.Acos(Math.Round((u * v) / (Math.Round(u.Length,3) * Math.Round(v.Length,3)),3)) * (180 / Math.PI);
    }

    public static void PrintVector(VectorL u)
    {
        Console.WriteLine($"X : {u.X}, Y : {u.Y}, Z: {u.Z}");
    }
    
    public static VectorL operator -(VectorL u, VectorL v)
    {
        return new VectorL(u.X - v.X, u.Y - v.Y, u.Z - v.Z);
    }
    
    public static VectorL operator -(VectorL u)
    {
        return new VectorL(-u.X, -u.Y, -u.Z);
    }

    public static VectorL operator +(VectorL u, VectorL v)
    {
        return new VectorL(u.X + v.X, u.Y + v.Y, u.Z + v.Z);
    }
    
    public static VectorL operator *(VectorL v, double num)
    {
        return new VectorL(v.X * num, v.Y * num, v.Z * num);
    }

    public static double operator *(VectorL u, VectorL v)
    {
        return(u.X * v.X + u.Y * v.Y + u.Z * v.Z);
    }

    public static bool operator ==(VectorL u, VectorL v)
    {
        return (Math.Abs(u.X - v.X) < Precision && Math.Abs(u.Y - v.Y) < Precision && Math.Abs(u.Z - v.Z) < Precision);
    }
    public static bool operator !=(VectorL u, VectorL v)
    {
        return (Math.Abs(u.X - v.X) > Precision || Math.Abs(u.Y - v.Y) > Precision || Math.Abs(u.Z - v.Z) > Precision);
    }

    public static VectorL operator &(VectorL u, VectorL v)
    {
        double prodX = (u.Y * v.Z) - (u.Z * v.Y);
        double prodY = (u.Z * v.X) - (u.X * v.Z);
        double prodZ = (u.X * v.Y) - (u.Y * v.X);

        return new VectorL(prodX, prodY, prodZ);
    }
    
    public static VectorL ReadVectorByComponents()
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
        catch(Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
        return new VectorL(x,y,z);
    }
    
    public static VectorL ReadVectorByPoints()
    {
       
        Point p1,p2;
        try
        {
            Console.WriteLine("Enter Point 1:");
            p1 = Point.ReadPoint();
            Console.WriteLine("Enter Point 2:");
            p2 = Point.ReadPoint();
        }
        catch(Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
        return new VectorL(p1,p2);
    }
    
}