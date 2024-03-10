function factorialDivision(a, b){
    const factorial = (n) => {
        let result = 1;
        for(let i = 1; i <= n; i++){
            result *= i;
        }
        return result;
    }

    if (a === 0){
        a = 1;
    }
    if (b === 0){
        b = 1;
    }
    
    console.log((factorial(a) / factorial(b)).toFixed(2));
}

factorialDivision(5, 2); // 60
factorialDivision(6, 2); // 360