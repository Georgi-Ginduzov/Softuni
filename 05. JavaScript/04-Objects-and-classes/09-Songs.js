class Song{
    constructor(typeList, name, time){
        this.typeList = typeList;
        this.name = name;
        this.time = time;
    }
}

function solve(input){
    const n = input[0];
    console.log(n);

    songs = [];

    for (let i = 1; i < input.length - 1; i++) {
        const [typeList, name, time] = input[i].split('_');
        songs.push(new Song(typeList, name, time));
    }

    songs.forEach(song => {
        if(song.typeList === input[input.length - 1])
            console.log(song.name);
    });
}

solve(
    [3,
    'favourite_DownTown_3:14',
    'favourite_Kiss_4:16',
    'favourite_Smooth Criminal_4:01',
    'favourite']
);