function search() {
   const listItemsElement = document.getElementsByTagName('li');
   const textInputElement = document.getElementById('searchText');
   const resultElement = document.getElementById('result');

   const towns = Array.from(listItemsElement);
   let matchesCount = 0;

   for (const town of towns) {
      town.style.textDecoration = 'none';
      town.style.fontWeight = 'normal';      
   }
console.log(towns);
   for (const town of towns) {
      if (town.textContent.includes(textInputElement.value)) {
         town.style.textDecoration = 'underline';
         town.style.fontWeight = 'bold';
         matchesCount++;
      }
   }

   resultElement.textContent =  `${matchesCount} matches found`;
}
