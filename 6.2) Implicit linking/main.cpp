#include <iostream>
#include "../6.1) DLL/Functionality.h"
using namespace std;

int main(int argc, char* argv)
{
	sayHelloTo("Bohdan");
	cout << "\n";
	cout << "Hypotenuses: " << calculateHypotenuse(4, 3) << endl;
	cout << "\n";
	cout << "Solved equation:" << endl;
	solveSquareEquation(2, 7, 3);
	system("pause");
	return 0;
}