function censor(text, word){
    let censored = "*".repeat(word.length);
    let result = text.replace(word, censored);
    while(result.includes(word)){
        result = result.replace(word, censored);
    }
    console.log(result);
}

censor('A small sentence with some words', 'small');