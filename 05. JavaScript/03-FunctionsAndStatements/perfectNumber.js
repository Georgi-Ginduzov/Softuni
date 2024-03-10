function isPerfectNumber(n) {
    let divisors = [];
    for (let i = 1; i <= n / 2; i++) {
        if (n % i === 0) {
            divisors.push(i);
        }
    }

    // TODO let lastDivisor = n / 2;
    /*while (lastDivisor > 0) {
        
        if (n % lastDivisor === 0) {
            divisors.push(lastDivisor);
        }
        lastDivisor = Math.ceil(lastDivisor / 2);
    }*/
    console.log(divisors);
    let divisorsSum = divisors.reduce((a, b) => a + b, 0);

    if (divisorsSum === n) {
        console.log("We have a perfect number!");
    }
    else {
        console.log("It's not so perfect.");
    }
}

isPerfectNumber(6);
isPerfectNumber(28);
isPerfectNumber(1236498);