function factorialDivision(a, b){
    if (a === 0){
        a = 1;
    }
    if (b === 0){
        b = 1;
    }
    
    if (a < b) {
        const buffer = a;
        a = b;
        b = buffer;
    }

    let result = 1;
    for(let i = a; i > b; i--){
        result *= i;
    }

    console.log(result.toFixed(2));
}

factorialDivision(5, 2); // 60
factorialDivision(6, 2); // 360