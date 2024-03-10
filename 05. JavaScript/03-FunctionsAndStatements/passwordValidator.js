function validatePassword(password){
    const letters = /[a-zA-Z]/g;
    const digits = /[0-9]/g;
    let result = "";

    if(password.length < 6 || password.length > 10){
        result += "Password must be between 6 and 10 characters\n";   
    }
    
    if([...password.matchAll(letters)].length + [...password.matchAll(digits)].length !== password.length){
        result += "Password must consist only of letters and digits\n";
    }
    
    if([...password.matchAll(digits)].length < 2){
        result += "Password must have at least 2 digits\n";
    }
    
    if(result == ""){
        console.log("Password is valid");
    } else {
        console.log(result);
    }
}

//validatePassword("logIn");
//validatePassword("MyPass123");
validatePassword("Pa$s$s");