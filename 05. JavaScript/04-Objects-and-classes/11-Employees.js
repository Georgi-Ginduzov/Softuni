function solve(input){
    let employees = [];

    for (const name of input) {

        employees[name] = name.length;
    }

    for (const employee in employees) {
        console.log(`Name: ${employee} -- Personal Number: ${employees[employee]}`);
        
    }
}

solve([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
    ]
);