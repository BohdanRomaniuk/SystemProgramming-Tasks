// 7.1) CPP DLL.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "Functionality.h"


extern void sayHelloTo(const char* name)
{
	return funcs->sayHelloTo(name);
}

extern double calculateHypotenuse(double firstCatet, double secondCatet)
{
	return funcs->calculateHypotenuse(firstCatet, secondCatet);
}

extern void solveSquareEquation(double a, double b, double c) 
{
	return funcs->solveSquareEquation(a, b, c);
}