function findSmallest(a, b, c) {
    if(a < b){
        if(a<c){
            console.log(a);
            return;
        }
        else{
            console.log(c);
            return;
        }
    }
    else if(b < c){
        console.log(b);
        return;
    }
    else{
        console.log(c);
        return;
    }
}

findSmallest(2, 5, 3);