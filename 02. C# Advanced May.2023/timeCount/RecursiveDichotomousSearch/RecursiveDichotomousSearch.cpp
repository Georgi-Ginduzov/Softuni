#include <iostream>

int dichotomousSearch(int* numbers, int searchedElement) {
	int left = 0;
	int middle = sizeof(numbers) / sizeof(numbers[0]) / 2;
	int right = sizeof(numbers) / sizeof(numbers[0]);

	if (numbers[middle] == searchedElement)
	{
		std::cout << "Found!";
		return numbers[middle];
	}
	else if (numbers[middle] > searchedElement)
	{
		
	}

}

int main()
{
    std::cout << "Hello World!\n";
}