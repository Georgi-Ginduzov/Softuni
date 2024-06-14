function addItem() {
    const itemsElement = document.getElementById('items');
    const newItemTextElement = document.getElementById('newItemText');

    const newLiElement = document.createElement('li');
    const newItemText = newItemTextElement.value;

    itemsElement.appendChild(newLiElement);
    newLiElement.textContent = newItemText;


}