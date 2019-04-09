using CsDll;

namespace DLLUsage
{
    public class CsLibraryMethods : ILibraryMethod
    {
        public void SayHello(string name)
        {
            Functionality.SayHello(name);
        }

        public double CalculateHypotenuse(double a, double b)
        {
            return Functionality.CalculateHypotenuse(a, b);
        }

        public void SolveSquareEquation(double a, double b, double c)
        {
            Functionality.SolveSquareEquation(a, b, c);
        }
    }
}
