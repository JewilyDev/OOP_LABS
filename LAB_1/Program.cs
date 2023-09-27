using oop_labs.LAB_1;

namespace oop_labs;

class Program
{
    static void Main(string[] args)
    {
        var trapeziumCalc = new TrapeziumMethodCalculator(0.001, 1000);
        var simpsonCalc = new SimpsonMethodCalculator(0.001, 1000);
        var trapeziumCalculusResult = trapeziumCalc.Calc(Math.Sin, 0, 1);
        var simpsonCalculusResult = simpsonCalc.Calc(Math.Sin, 0, 1);
        Console.WriteLine(trapeziumCalculusResult);
        Console.WriteLine(simpsonCalculusResult);


    }
}
