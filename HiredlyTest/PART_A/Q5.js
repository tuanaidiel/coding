let values = [8, 10, 7, 3, 2, 9, 1, 5, 4, 6];

let evenNumbers = [];
let oddNumbers = [];

for (let value of values) {
    if (value % 2 === 0) {
        evenNumbers.push(value);
    } else {
        oddNumbers.push(value);
    }
}

console.log("Even Numbers:", evenNumbers);
console.log("Odd Numbers:", oddNumbers);
