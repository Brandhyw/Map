using System;

namespace Map2D
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = new Map2D<float>(3, 3);
            _ = new Map2D<float>(3, 3, 123f);
            _ = new Map2D<float>(new Map2D<float>(32, 32, 123f));
            _ = new Map2D<float>(new float[,]{ { 1,2,3}, { 4, 5, 6}, { 7, 8, 8} });
            _ = new Map2D<float>(new float[3][] { new float[3] { 1, 2, 3 }, new float[3] { 4, 5, 6 }, new float[3] { 7, 8, 9 } });

            Console.Read();
        }
    }
}
