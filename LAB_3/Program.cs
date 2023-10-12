using System.Globalization;
using _3DArray;

class Program
{
    public static void Main(string[] args)
    {
        Array3D<int> test = new Array3D<int>(5, 3, 2);
        int[][] mat = new int[][] { new int[] { 1 }, new int[] { 2, 3 }, new int[] { 4 } };
        int[] mas = new int[] { -1, 1, -2, 2 };
        test.SetValues(4, null, null, mat);
        test.SetValues(null, 2, 1, mas);
        //test.Fill(-1);

        var res1 = test.GetValues(4, null, null);
        for (int i = 0; i < test.N; i++)
        {
            for (int j = 0; j < test.K; j++)
            {
                Console.WriteLine(res1[i, j]);
            }
        }

        Console.WriteLine("\n");
        var res2 = test.GetValues(null, 2, 1);
        for (int i = 0; i < test.M; i++) 
            Console.WriteLine(res2[i]);
    }
}