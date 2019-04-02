#include <iostream>

extern "C"
{
	void __declspec(dllexport) __cdecl sayHelloTo(const char* name);

	double __declspec(dllexport) __cdecl calculateHypotenuse(double firstCatet, double secondCatet);

	void __declspec(dllexport) __cdecl solveSquareEquation(double a, double b, double c);
}