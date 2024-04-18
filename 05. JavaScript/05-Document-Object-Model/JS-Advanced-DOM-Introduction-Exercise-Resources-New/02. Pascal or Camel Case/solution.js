function solve() {
  const textElement = document.getElementById('text');
  const namingConventionElement = document.getElementById('naming-convention');
  const resultElement = document.querySelector('#result');

  const text = textElement.value;
  const namingConvention = namingConventionElement.value;

  const convertToPascalCase = (text) => 
    text
      .split(' ')
      .map(word => word[0].toUpperCase() + word.slice(1).toLowerCase())
      .join('');
      
  const convertor = {
    'Pascal Case': (text) => convertToPascalCase(text),
    'Camel Case': (text) => convertToPascalCase(text).charAt(0).toLowerCase() + convertToPascalCase(text).slice(1),
      default: () => 'Error!'
  };

  resultElement.textContent = convertor[namingConvention] ? convertor[namingConvention](text) : convertor['default']();
}