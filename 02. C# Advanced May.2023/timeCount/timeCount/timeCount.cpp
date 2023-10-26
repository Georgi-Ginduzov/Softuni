#include <stdlib.h> //необходима за функцията rand
#include <time.h>//необходима за функцията time
#include <sys/types.h>
#include <iostream>

void selectionSort(int arr[], int n);

int main()
{
	time_t t0, t1;
	clock_t c0, c1; 
	srand(time(NULL));

	const int ARRAY_SIZE = 100000;
	int array[ARRAY_SIZE];
	for (int i = 0; i < ARRAY_SIZE; i++) {
		
		array[i] = rand();
	}

	t0 = time(NULL);
	c0 = clock();
	
    // Selection sort


    // Bubble sort


    // Insertion sort
}

void selectionSort(int arr[], int n)
{
    int i, j, min_idx;

    // One by one move boundary of
    // unsorted subarray
    for (i = 0; i < n - 1; i++) {

        // Find the minimum element in
        // unsorted array
        min_idx = i;
        for (j = i + 1; j < n; j++) {
            if (arr[j] < arr[min_idx])
                min_idx = j;
        }

        // Swap the found minimum element
        // with the first element
        if (min_idx != i) {
            swap(arr[min_idx], arr[i]);

        }
    }
}
