function oddAndEvenSum(input) {
    const numberArray = Array.from(input.toString().split(''));
    let oddSum = 0;
    let sum = 0;

    for (const number of numberArray) {
        if (number % 2 !== 0) {
            oddSum += Number(number);
        }
        sum += Number(number);        
    }
    console.log(`Odd sum = ${oddSum}, Even sum = ${sum - oddSum}`);
}

oddAndEvenSum(1000435);