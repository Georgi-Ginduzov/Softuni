window.addEventListener("load", solve);

function solve() {
    // Add contact elements
    const inputNameElement = document.getElementById('name');
    const inputPhoneNumberElement = document.getElementById('phone');
    const inputCategoryElement = document.getElementById('category');
    const addButtonElement = document.getElementById('add-btn');

    const checkListElement = document.getElementById('check-list');

    addButtonElement.addEventListener('click', () => {
        // Get input information
        const name = inputNameElement.value;
        const phoneNumber = inputPhoneNumberElement.value;
        const category = inputCategoryElement.value;

        // Check empty element
        if (!name || !phoneNumber || !category) {
            return;
        }

        const contactLiElement = createContactElement(name, phoneNumber, category);

        
        // clear inputs
        inputNameElement.value = '';
        inputPhoneNumberElement.value = '';
        inputCategoryElement.value = '';
    })

    
    function createContactElement(name, phoneNumber, category) {
      // Contact info
      const nameLiElement = document.createElement('p');
      nameLiElement.textContent = `name:${name}`;

      const phoneNumberLiElement = document.createElement('p');
      phoneNumberLiElement.textContent = `phone:${phoneNumber}`;

      const categoryLiElement = document.createElement('p');
      categoryLiElement.textContent = `category:${category}`;

      const articleElement = document.createElement('aricle');

      articleElement.appendChild(nameLiElement);
      articleElement.appendChild(phoneNumberLiElement);
      articleElement.appendChild(categoryLiElement);

      // Buttons
      const editButtonElement = document.createElement('button');
      editButtonElement.classList = 'edit-btn';
      editButtonElement.addEventListener('click', () => {
        // send data to inputs
        inputNameElement.value = name;
        inputPhoneNumberElement.value = phoneNumber;
        inputCategoryElement.value = category;

        // Clear preview (should remove event listeners also)
        liElement.remove();
      });
      
      const saveButtonElement = document.createElement('button');
      saveButtonElement.classList = 'save-btn';

      const divElement = document.createElement('div');
      divElement.appendChild(editButtonElement);
      divElement.appendChild(saveButtonElement);

      const liElement = document.createElement('li');
      liElement.appendChild(articleElement);
      liElement.appendChild(divElement);

      checkListElement.appendChild(liElement);
    }
    

    // o	Name, Phone Number, and Category should be non-empty strings
  }
  