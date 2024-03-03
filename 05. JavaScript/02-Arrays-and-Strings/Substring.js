function makeSubstring(string, start, end) {
    let result = string.substring(start, end + start);
    console.log(result);
}
makeSubstring("SkipWord", 4, 7);
/*
Write a function that receives a string and two numbers. The numbers will be a starting index and count of elements to substring. Print the result.
*/