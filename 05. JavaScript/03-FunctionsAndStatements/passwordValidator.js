function validatePassword(password){
    const letters = /[a-zA-Z]/g;
    const digits = /[0-9]/g;
    
    if(password.length < 6 || password.length > 10){
        console.log("Password must be between 6 and 10 characters");   
    }
    if([...password.matchAll(digits)].length < 2){
        console.log("Password must have at least 2 digits");
    }
    if([...password.matchAll(letters)].length + [...password.matchAll(digits)].length !== password.length){
            console.log("Password must consist only of letters and digits");
        }
        else{
            console.log("Password is valid");
        }
    
}

//validatePassword("logIn");
//validatePassword("MyPass123");
validatePassword("Pa$s$s");