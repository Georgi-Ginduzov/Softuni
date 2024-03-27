function solve(input){
    const wordsCounter = [];

    for (const word of input[0].split(' ')) {
        wordsCounter[word] = 0;
    }

    for (let i = 1; i < input.length; i++) {
        const word = input[i];
        if (wordsCounter.hasOwnProperty(word)){
            wordsCounter[word]++;
        }
    }

    const sortedWordsCounter = Object.entries(wordsCounter)
        .sort((a, b) => b[1] - a[1]);

    for (const [word, count] of sortedWordsCounter) {
        console.log(`${word} - ${count}`);
    }
}

solve([
    'this sentence', 
    'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
    ]
);