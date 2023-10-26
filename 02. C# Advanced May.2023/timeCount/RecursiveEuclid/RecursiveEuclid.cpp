#include <iostream>

int gcd (int a, int b, int* count) {
	if (b == 0)
	{
		return a;
	}
	if (a > b)
	{
		std::cout << a << " % " << b << " = " << a % b << std::endl;
		*count = *count + 1;
		return gcd(b, a % b, count);
	}
	else
	{
		return gcd(b, a, count);
	}
}

int main()
{
	int a, b;
	std::cin >> a;
	std::cin >> b;

	int* counter = 0;
	std::cout << gcd(a, b, counter);
}