function printLoadingBar(number){
    let result = "[";
    result += "%".repeat(number / 10);
    result += ".".repeat(10 - number / 10);
    result += "]";

    if (number === 100){
        console.log("100% Complete!");
        console.log(result);
    }
    else{
        console.log(`${number}% ${result}`);
        console.log("Still loading...");
    }
}

printLoadingBar(30); // [%%%.......]
printLoadingBar(50); // [%%%%%%%%%%]
printLoadingBar(100); // [%%%%%%%%%%]