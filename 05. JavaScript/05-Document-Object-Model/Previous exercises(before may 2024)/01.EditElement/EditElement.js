const insertButton = document.querySelector('#insertNameButton');

if(insertButton) {
    insertButton.addEventListener('click', ()=> {
    document.querySelector('#h1').innerHTML = "Hello, Document Object Model!";
    });
}
