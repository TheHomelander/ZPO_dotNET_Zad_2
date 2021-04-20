using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            IntegerTableClass newObject = new IntegerTableClass(2, 1);
            newObject.ZmieanaRozmiaru += registerEvent;
            newObject[0, 0] = 1;
            newObject[0, 1] = 1;
            newObject[1, 0] = 2;
            newObject[1, 1] = 2;
            newObject[1, 2] = 3;

            for( int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++) {
                    Console.WriteLine(newObject[i, j]);
                }
            }
            Console.WriteLine(newObject[1, 2]);
            int[] temp = newObject.TwoDimensionIntegerArray;
            Console.WriteLine("ROZMIAR\n");
            Console.WriteLine(temp[0]);
            Console.WriteLine(temp[1]);
        }
        public static void registerEvent(int[] args)
        {
            Console.WriteLine("EVENT START");
            Console.WriteLine(args[0]);
            Console.WriteLine(args[1]);
            Console.WriteLine("EVENT END");
        }
    }
}
