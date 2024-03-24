function solve(name, lastName, hairColor){
    let person = {
        name,
        lastName,
        hairColor
    }

    let stringifiedPerson = JSON.stringify(person);
    
    console.log(stringifiedPerson);
}

solve('George', 'Jones', 'Brown');