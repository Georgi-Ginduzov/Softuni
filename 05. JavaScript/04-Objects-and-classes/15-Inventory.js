function solve(input) {
    const heroes = [];

    for (const row of input) {
        const [name, level, items] = row.split(" / ");
        let hero = {
            name,
            level: Number(level),
            items: items.split(', '),
        };

        heroes.push(hero);
    }

    heroes.sort((a, b) => a.level - b.level);
    heroes.forEach(hero => {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items.join(", ")}`);
    })
}

solve([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
    ]
);