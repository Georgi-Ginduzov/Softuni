function solve(arr, n){
    let buffer = 0;
    for(let i = 0; i < n; i++){
        buffer = arr.shift();
        arr.push(buffer);
    }
    console.log(arr.join(' '));
}

solve([2, 4, 15, 31], 5);