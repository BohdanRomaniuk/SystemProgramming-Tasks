#include <Windows.h>
#include <iostream>
using namespace std;

typedef void(__cdecl *SayHelloTo)(const char* name);
typedef double(__cdecl *CalculateHypotenuse)(double firstCatet, double secondCatet);
typedef void(__cdecl *SolveSquareEquation)(double a, double b, double c);

int main(int argc, char* argv)
{
	HINSTANCE hModule;
	hModule = LoadLibrary(TEXT("6.1) DLL.dll"));
	cout << "DLL load " << ((hModule == NULL) ? "failed" : "success") << endl;

	SayHelloTo sayHi = (SayHelloTo)GetProcAddress(hModule, TEXT("sayHelloTo"));
	cout << "Function sayHelloTo is " << ((sayHi == NULL) ? "invalid" : "valid") << endl;

	CalculateHypotenuse calculate = (CalculateHypotenuse)GetProcAddress(hModule, TEXT("calculateHypotenuse"));
	cout << "Function calculateHypotenuse is " << ((calculate == NULL) ? "invalid" : "valid") << endl;

	SolveSquareEquation equation = (SolveSquareEquation)GetProcAddress(hModule, TEXT("solveSquareEquation"));
	cout << "Function solveSquareEquation is " << ((equation == NULL) ? "invalid" : "valid") << endl;

	cout << "\nFunctions result::::::::::::: " << endl; 
	sayHi("Buchik");
	cout << "\n";
	cout << "Hypotenuses: " << calculate(4, 3) << endl;
	cout << "\n";
	cout << "Solved equation:" << endl;
	equation(2, 7, 3);

	FreeLibrary(hModule);
	system("pause");
	return 0;
}