#include <iostream>
#include <stdlib.h> 
#include <time.h> 

using std::cout;

int main()
{
    srand(time(NULL)); // initialize rand numbers generator

    int arr[20]; // create an array with random numbers
	for (int i = 0; i < 20; i++)
	{
		arr[i] = rand() % 100;
	}


}	