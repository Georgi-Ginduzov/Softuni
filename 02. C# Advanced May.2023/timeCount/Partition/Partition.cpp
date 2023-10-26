#include <iostream>
#include <stdlib.h>
#include <time.h>

int quickSort(int array[]) {
	int pivot = (sizeof(array) / sizeof(array[0])) / 2;
	int i = 0, k = (sizeof(array) / sizeof(array[0]));
	int lower, higher;
	while (array[pivot] < array[i])
	{
		higher = array[i];
	}
	//partition the array into two
	//go to the left partition
	//make the first element pivot
	//check if next element is lower than it 
	//	if it is not check whether the last element is lower

	return *array;
}

int main()
{
	int array[10];
	srand(time(NULL));

	for (int i = 0; i < 10; i++)
	{
		array[i] = rand();
	}



}
