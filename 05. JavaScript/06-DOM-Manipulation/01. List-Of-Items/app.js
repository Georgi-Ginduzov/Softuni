function addItem() {
    const items = document.getElementById('items');
    const inputData = document.getElementById('newItemText');

    const liElement = document.createElement('li');
    console.log(inputData.value);

    items.appendChild(liElement);

    liElement.textContent = inputData.value;

    inputData.value = '';
}