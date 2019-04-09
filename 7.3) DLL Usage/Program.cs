using System;

namespace DLLUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CppDllUsageExample");
            Console.WriteLine("----------------------------");
            CppLibraryMethods cpp = new CppLibraryMethods();
            cpp.SayHello("Bohdan");
            cpp.CalculateHypotenuse(3, 4);
            cpp.SolveSquareEquation(2, 7, 3);

            Console.WriteLine("\n\n----------------------------\n\n");

            Console.WriteLine("CSharpDllUsageExample");
            Console.WriteLine("----------------------------");
            CsLibraryMethods cs = new CsLibraryMethods();
            cs.SayHello("Bohdan");
            cs.CalculateHypotenuse(3, 4);
            cs.SolveSquareEquation(2, 7, 3);

            Console.ReadKey();
        }
    }
}
