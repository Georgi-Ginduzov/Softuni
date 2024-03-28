function solve(input){
    let parkingLot = [];

    for (const row of input) {
        const [direction, carNumber] = row.split(', ');

        if (direction === "IN") {
            parkingLot[carNumber] = direction;
        } else if (direction === "OUT") {
            delete(parkingLot[carNumber]);
        }
    }

    const sortedParkingLot = Object.entries(parkingLot).sort();
    
    if (Object.keys(sortedParkingLot).length === 0) {
        console.log("Parking Lot is Empty");
    } else {
        for (const carNumber of sortedParkingLot) {
            console.log(carNumber[0]);
        }
    }
}

solve(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'IN, CA9999TT',
'IN, CA2866HI',
'OUT, CA1234TA',
'IN, CA2844AA',
'OUT, CA2866HI',
'IN, CA9876HH',
'IN, CA2822UU']

);