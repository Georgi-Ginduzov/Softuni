function solve() {
  const textAreaElement = document.getElementById('input');
  const outputElement = document.getElementById('output');

  const text = textAreaElement.value.split('.').filter(x => x.length > 1);

  const paragraphs = text.filter((x, i) => i % 3 === 0).map((x, i) => text.slice(i, i + 3).join('. ') + '.');

  outputElement.innerHTML = paragraphs.map(x => `<p>${x}</p>`).join('');
}