function solve(input){
    let meetings = {};

    for (const line of input) {
        let [weekday, name] = line.split(' ');

        if (meetings.hasOwnProperty(weekday)){
            console.log(`Conflict on ${weekday}!`);
        }
        else{
            meetings[weekday] = name;
            console.log(`Scheduled for ${weekday}`);
        }
    }

    for (const weekday in meetings) {
        console.log(`${weekday} -> ${meetings[weekday]}`);
    }
}

solve(['Monday Peter',
'Wednesday Bill',
'Monday Tim',
'Friday Tim']
);