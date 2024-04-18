function toggle() {
    let toggleButtonElement = document.querySelector('.button');
    const extraContentElement = document.getElementById('extra');
    
    let currentbuttonText = toggleButtonElement.textContent;
    if (currentbuttonText === 'More') {
        extraContentElement.style.display = 'block';
        toggleButtonElement.textContent = 'Less';        
    }
    else {
        extraContentElement.style.display = 'none';
        toggleButtonElement.textContent = 'More';
    }
}