function printMatrix(n){
    for (let i = 1; i <= n; i++) {
        let line = '';
        for (let j = i; j < n + i; j++) {
            line += n + ' ';
        }
        console.log(line);
    }
}

printMatrix(3); // 1 2 3
printMatrix(2); // 1 2
printMatrix(7); // 1 2 3 4 5 6 7