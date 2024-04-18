function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      const selectedElements = document.querySelectorAll('.select');
      for (const element of selectedElements) {
         element.classList.remove('select');
      }

      const searchTable = document.getElementsByTagName('tbody');

      const searchInput = document.getElementById('searchField');

      for (const tableRow of searchTable) {
         const tableDataElements = Array.from(tableRow.getElementsByTagName('tr'));
         
         for (const element of tableDataElements) {
            // TODO: check element sensitivity
            if (element.textContent.includes(searchInput.value)) {
               console.log(element);
               element.className = 'select';
               
            }
         }
      }

      searchInput.value = '';

   }
}