function solve(input){
    let dictionary = [];
    
    for (const row of input) {
        let termDefinitionPair = JSON.stringify(row);
        let [term, definition] = termDefinitionPair;
        console.log(definition);
        dictionary.push(termDefinitionPair);
    }

    for (const term of Object.entries(dictionary)) {
        //console.log(term);
    }

    //console.log(Object.entries(dictionary));

}

function fancySolve(input){
    const dictionary = {};

    const words = input.map(JSON.parse)
    
    for (const wordObj of words) {
        const word = Object.keys(wordObj)[0];

        dictionary[word] = wordObj[word];
    }
    
    Object.entries(dictionary)
        .sort((a, b) => a[0].localeCompare(b[0]))
        .forEach(([term, definition]) => console.log(`Term: ${term} => Definition: ${definition}`))
}

fancySolve([
    '{"Cup":"A small bowl-shaped container for drinking from, typically having a handle"}',
    '{"Cake":"An item of soft sweet food made from a mixture of flour, fat, eggs, sugar, and other ingredients, baked and sometimes iced or decorated."}',
    '{"Watermelon":"The large fruit of a plant of the gourd family, with smooth green skin, red pulp, and watery juice."}',
    '{"Music":"Vocal or instrumental sounds (or both) combined in such a way as to produce beauty of form, harmony, and expression of emotion."}',
    '{"Art":"The expression or application of human creative skill and imagination, typically in a visual form such as painting or sculpture, producing works to be appreciated primarily for their beauty or emotional power."}'
    ]    
);