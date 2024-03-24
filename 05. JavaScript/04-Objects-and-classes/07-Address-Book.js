function solve(input){
    let addressBook = {};

    for (const line of input) {
        let [name, address] = line.split(':');
        addressBook[name] = address;
    }

    let sortedBook = Object.entries(addressBook);
    sortedBook.sort((a, b) => a[0].localeCompare(b[0]));

    for (const person of sortedBook) {
        console.log(`${person[0]} -> ${person[1]}`);
    }
}

solve(['Tim:Doe Crossing',
'Bill:Nelson Place',
'Peter:Carlyle Ave',
'Bill:Ornery Rd']
);