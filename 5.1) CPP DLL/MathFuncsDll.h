#pragma once
namespace MathFuncs
{
	class MyMathFuncs
	{
	public:
		static __declspec(dllexport) double Add(double a, double b);

		static __declspec(dllexport) double Subtract(double a, double b);

		static __declspec(dllexport) double Multiply(double a, double b);

		static __declspec(dllexport) double Divide(double a, double b);
	};
}