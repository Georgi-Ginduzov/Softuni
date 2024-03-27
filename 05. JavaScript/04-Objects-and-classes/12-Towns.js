function solve(input){
    let towns = [];

    for (const row of input) {
        let [town, latitude, longitude] = row.split(" | ");

        latitude = String(parseFloat(latitude).toFixed(2));
        longitude = String(parseFloat(longitude).toFixed(2));
        towns.push({
            town,
            latitude,
            longitude,
        });
    }

    for (const town of towns) {
        console.log(town);
    }
}

solve(['Sofia | 42.696552 | 23.32601',
'Beijing | 39.913818 | 116.363625']
)