function substringCounter(text, word){
    let counter = 0;
    let occurences = text.split(' ').filter(w => w === word);
    console.log(occurences.length);
}

substringCounter('This is a word and it also is a sentence', 'is'); // 2