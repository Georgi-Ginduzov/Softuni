function calculatePddAndEvenSum(arr){
    let evenNumbers = arr.filter(n => n % 2 === 0);
    let evenSum = 0;
    for(let evenNumber of evenNumbers){
        evenSum += evenNumber;
    }

    let oddNumbers = arr.filter(n => n % 2 !== 0);
    let oddSum = 0;
    for(let oddNumber of oddNumbers){
        oddSum += oddNumber;
    }

    return evenSum - oddSum;
}

console.log(calculatePddAndEvenSum([4.5, 7.5]));
/*
Write a program that calculates the difference between the sum of the even and the sum of the odd numbers in an array.
*/