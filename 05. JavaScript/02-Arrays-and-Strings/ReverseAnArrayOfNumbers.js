function reverse(n, arr) {
    return arr.splice(-arr.Length, n).reverse().join(' ');
}

console.log(reverse(3, [10, 20, 30, 40, 50]));
console.log(reverse(3, [10, 20, 30, 40, 50]));

/*
Write a program, which receives a number n and an array of elements. Your task is to create a new array with n numbers from the original array, reverse it and print its elements on a single line, space-separated.
*/