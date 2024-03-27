function solve(input){
    const words = input.toLowerCase().split(' ');
    
    let wordsCounter = [];
    
    for (const word of words) {
        if (wordsCounter.hasOwnProperty(word)){
            wordsCounter[word]++;
        }
        else{
            wordsCounter[word] = 1;
        }
    }

    for (const word in wordsCounter) {
        if (wordsCounter[word] % 2 === 0) {
            delete(wordsCounter[word]);
            continue;
        }
    }

    console.log(Object.keys(wordsCounter).join(' '));
}

solve('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');