using System.Numerics;

namespace oop_labs.LAB_2;

public class ConsoleVectorInterface
{
    private static bool _byPoints = false;

    private bool _firstVisit = true;

    private int ReadAnswer()
    {
        int answer;
        Console.WriteLine("\n Please, enter one of the foregoing numbers.");
        while (true)
        {
            try
            {
                answer = Convert.ToInt16(Console.ReadLine());
                break;
            }
            catch 
            {
                Console.WriteLine("The answer has to be a number");
            }
        }
        return answer;
    }
    private void WelcomePage()
    {
        Console.WriteLine("Welcome to the VectorL console application.");
        Console.WriteLine("Please, enter the operation you want to make:");
        Console.WriteLine("1. Calculate the distance between two vectors ");
        Console.WriteLine("2. Calculate the angle between two vectors");
        Console.WriteLine("3. Check if vectors are coplanar");
        Console.WriteLine("4. Check if vectors are collinear");
        Console.WriteLine("5. Calculate vector projection on the axis");
        Console.WriteLine("6. Arithmetical operations(select to show options)");
        
        int answer = ReadAnswer();
        WelcomePageHandler(answer);
    }
    private void ArithmeticalPage()
    {
        Console.WriteLine("Select the operation you prefer to make:");
        Console.WriteLine("1. Summarize two vectors  ");
        Console.WriteLine("2. Subtract two vectors");
        Console.WriteLine("3. Calculate scalar product");
        Console.WriteLine("4. Calculate vector product");
        Console.WriteLine("5. Compare two vectors");
        Console.WriteLine("6. Get opposite vector");
        Console.WriteLine("7. Product vector on number");
        Console.WriteLine("8. Back to the menu");
        int answer = ReadAnswer();
        ArithmeticPageHandler(answer);
        
    }
    private void FirstVisitCheck()
    {
        if (_firstVisit)
        {
            Console.WriteLine("Would you like to enter vectors by points? Y/N");
            string fvAns = Console.ReadLine().ToString();
            if (fvAns.Equals("Y"))
            {
                _byPoints = true;
            } 
            else if (!fvAns.Equals("N"))
            {
                throw new Exception("Invalid answer. Please, pay attention on my words.");
            }

            _firstVisit = false;
        }
    }
    
    public void Call()
    {
        WelcomePage();
    }
    private (VectorL u, VectorL v,VectorL w) ReadVectorTuple(int size)
    {
        List<VectorL> vectorLs = new List<VectorL>(size);
        int amountOfParsedVectors = 0;
        while (amountOfParsedVectors < size)
        {
            Console.WriteLine("Please, enter vector:");
            VectorL vec;
            if (_byPoints)
            {
                vec = VectorL.ReadVectorByPoints();
            }
            else
            {
                vec = VectorL.ReadVectorByComponents();
            }
            vectorLs.Add(vec);
            amountOfParsedVectors++;
        }
        int index = 0;
        while (index < 3)
        {
            if (index >= vectorLs.Count)
            {
                vectorLs.Add(VectorL.NullVector);
            }
            index++;
        }
        
        return (vectorLs[0], vectorLs[1],vectorLs[2]);
    }
    
    private void WelcomePageHandler(int answer)
    {
        while (answer < 0 || answer > 7)
        {
            Console.WriteLine("Invalid option. Please, review the menu and enter again:");
            answer = Convert.ToInt16(Console.ReadLine());
        }
        if (answer != 6)
        {
            FirstVisitCheck();
            switch (answer)
            {
                case 1:
                {
                    var vectors = ReadVectorTuple(2);
                    double result = VectorL.Distance(vectors.u, vectors.v);
                    Console.WriteLine($"The distance is {result}");
                    break;
                }
                case 2:
                {
                    var vectors = ReadVectorTuple(2);
                    double result = VectorL.AngleBetween(vectors.u, vectors.v);
                    Console.WriteLine($"The angle is {result}");
                    break;
                }
                case 3:
                {
                    var vectors = ReadVectorTuple(3);
                    bool result = VectorL.IsCoplanar(vectors.u, vectors.v, vectors.w);
                    string negative = result == false ? "not" : "";
                    Console.WriteLine($"The vectors are {negative} coplanar");
                    break;
                }
                case 4:
                {
                    var vectors = ReadVectorTuple(2);
                    bool result = VectorL.IsCollinear(vectors.u, vectors.v);
                    string negative = result == false ? "not" : "";
                    Console.WriteLine($"The vectors are {negative} collinear");
                    break;
                }
                case 5:
                {
                    var vectors = ReadVectorTuple(2);
                    double result = VectorL.VectorProjection(vectors.u, vectors.v);
                    Console.WriteLine($"The vector projection is {result}");
                    break;
                }
            }
            WelcomePage();
        }
        else
        {
            ArithmeticalPage();
        }
        
    }

    private void ArithmeticPageHandler(int answer)
    {
       
        while (answer < 0 || answer > 8)
        {
            Console.WriteLine("Invalid option. Please, review the menu and enter again:");
            answer = Convert.ToInt16(Console.ReadLine());
        }
        
        if (answer != 8)
        {
            FirstVisitCheck();
            switch (answer)
            {
                case 1:
                {
                    var vectors = ReadVectorTuple(2);
                    Console.WriteLine("The sum is");
                    VectorL.PrintVector(vectors.u + vectors.v);
                    break;
                }
                case 2:
                {
                    var vectors = ReadVectorTuple(2);
                    Console.WriteLine("The subtraction is");
                    VectorL.PrintVector(vectors.u + vectors.v);
                    break;
                }
                case 3:
                {
                    var vectors = ReadVectorTuple(2);
                    Console.WriteLine($"The scalar product is{vectors.u * vectors.v}");
                    break;
                }
                case 4:
                {
                    var vectors = ReadVectorTuple(2);
                    Console.WriteLine($"The scalar product is");
                    VectorL.PrintVector(vectors.u & vectors.v);
                    break;
                }
                case 5:
                {
                    var vectors = ReadVectorTuple(2);
                    bool result = vectors.u == vectors.v;
                    string negative = result == false ? "not" : "";
                    Console.WriteLine($"The vector are {negative} equal");
                    break;
                }
                case 6:
                {
                    var vectors = ReadVectorTuple(1);
                    Console.WriteLine("The opposite vector is ");
                    VectorL.PrintVector(-vectors.u);
                    break;
                }
                case 7:
                {
                    var vectors = ReadVectorTuple(1);
                    Console.WriteLine("Please, enter the number");
                    double num = Convert.ToInt16(Console.Read());
                    Console.WriteLine("The modified vector is");
                    VectorL.PrintVector(vectors.u * num);
                    break;
                }
            }

            ArithmeticalPage();
        }
        else
        {
            WelcomePage();
        }
    }
}