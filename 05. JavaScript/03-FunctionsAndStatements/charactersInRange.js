function printCharsInRange(char1, char2){
    let firstAsciiIndex = char1.charCodeAt(0);
    let secondAsciiIndex = char2.charCodeAt(0);

    if ( firstAsciiIndex > secondAsciiIndex){
        printAscii(secondAsciiIndex, firstAsciiIndex);
    }
    else {
        printAscii(firstAsciiIndex, secondAsciiIndex);
    }

    const printAscii = (start, end) => {
        let asciiElements = [];
        for (let i = start + 1; i < end; i++){
            asciiElements.push(i);
        }

        let result = String.fromCodePoint(...asciiElements);
        console.log(result.split('').join(' '));
    }
    
}

printCharsInRange('a', 'd'); // bc