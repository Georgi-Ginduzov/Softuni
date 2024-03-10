function checkForPalindromes(arr) {
    const isPalindrome = (num) => {
        let reversedNum = Array.from(num.toString()).reverse().join('');
        if (num.toString() === reversedNum) {
            return true;
        }
        else {
            return false;
        }
    }
    
    for (let i = 0; i < arr.length; i++) {
        if (isPalindrome(arr[i])) {
            console.log(true);
        }
        else {
            console.log(false);
        }
    }
}

checkForPalindromes([123, 323, 421, 121]); // false, true, false, true