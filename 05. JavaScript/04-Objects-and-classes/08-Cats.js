class Cat{
    constructor(name, age){
        this.name = name;
        this.age = age;
    }

    meow(){
        console.log(`${this.name}, age ${this.age} says Meow`);
    }
}

function solve(input){
    cats = [];

    for (const line of input) {
        let [catName, age] = line.split(' ');
        
        cats.push(new Cat(catName, age));
    }

    for (const cat of cats) {
        cat.meow();
    }
}

solve(['Mellow 2', 'Tom 5']);