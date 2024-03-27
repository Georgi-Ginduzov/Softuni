function solve(currentStock, orderedProducts){
    let storeProducts = [];

    for (let i = 0; i < currentStock.length; i += 2) {
        storeProducts[currentStock[i]] = parseInt(currentStock[i + 1]);
    }

    for (let i = 0; i < orderedProducts.length; i += 2) {
        if (storeProducts.hasOwnProperty(orderedProducts[i])) {
            storeProducts[orderedProducts[i]] = parseInt(storeProducts[orderedProducts[i]]) + parseInt(orderedProducts[i+1]);
        }
        else {
            storeProducts[orderedProducts[i]] = parseInt(orderedProducts[i+1]);
        }
    }

    for (const product in storeProducts) {
        console.log(`${product} -> ${storeProducts[product]}`);
    }
}

solve([
    'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
    ],
    [
    'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
    ]
);