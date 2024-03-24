function solve(jsonString){
    let object = JSON.parse(jsonString);

    for (const key in object) {
        console.log(`${key}: ${object[key]}`);
    }
}

solve('{"name": "George", "age": 40, "town": "Sofia"}');