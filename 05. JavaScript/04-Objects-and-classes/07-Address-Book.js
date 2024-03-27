function solve(input){
    let addressBook = {};

    for (const line of input) {
        let [name, address] = line.split(':');
        addressBook[name] = address;
    }

    let sortedBook = Object.entries(addressBook);
    sortedBook.sort((a, b) => a[0].localeCompare(b[0]));

    for (const name of sortedBook) {
        console.log(`${name[0]} -> ${name[1]}`);
    }
}

solve(['Tim:Doe Crossing',
'Bill:Nelson Place',
'Peter:Carlyle Ave',
'Bill:Ornery Rd']
);