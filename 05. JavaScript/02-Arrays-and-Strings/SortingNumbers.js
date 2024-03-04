function solve(arr){
    arr.sort((a, b) => a > b ? 0: -1);
    let reversedArr = arr.reverse();
    
    let result = [];
    let k = arr.length - 1;
    for (let i = 0; i < arr.length / 2; i++){
        result.push(arr[k]);
        result.push(reversedArr[i]);
        k--;
    }
    return result;
}

solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);