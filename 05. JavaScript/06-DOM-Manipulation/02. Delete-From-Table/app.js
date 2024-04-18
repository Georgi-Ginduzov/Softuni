function deleteByEmail() {
    const resultElement = document.getElementById('result');

    const emailInputElement = document.querySelector('input[name="email"]');

    let found = false;

    for (const item of document.getElementsByTagName('tr')) {
        if (item.parentElement.tagName === 'TBODY') {
            const tableRowEmail = item.getElementsByTagName('td')[1].textContent;

            if (tableRowEmail === emailInputElement.value) {
                found = true;            
                
                item.parentElement.removeChild(item);

                break;
            }
        }
    }

    if (found == false) {
        resultElement.textContent = "Not found.";
    }
    else{
        resultElement.textContent = "Deleted."
    }
}