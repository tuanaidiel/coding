// Data Type

// 1. String 

let firstname = "elon";
let lastname = 'musk';

document.write(firstname + " " + lastname + "<br>");

// 2. number

let num1 = 96.5;
let num2 = 96.00;
let x = 10;
let y = '20';   // string


document.write(num1 + "<br>");
document.write(num2 + "<br>");
document.write(x + " ");
document.write(typeof x + "<br>");
document.write(y + " ");
document.write(typeof y + "<br>");

// 3. boolean

let learning = true;
let completed = false;
let o = 20>10;


document.write(learning + " ");
document.write(typeof learning + "<br>");
document.write(completed + " ");
document.write(typeof completed + "<br>");
console.log(o)
document.write(o + "<br>");

// 4. null

let number = null;

document.write(number + " ");
document.write(typeof number + "<br>");
document.write(null == undefined + "<br>");

// 5. object

let person = {
    first_name : 'Abu',
    last_name : 'Bakar',
    age : 35
};

document.write(person + " ");
document.write(typeof person + "<br>");

// 6. array

let nombor = [1,2,3,4,5];

document.write(nombor + "<br>");
document.write(typeof nombor + "<br>");

// 7. function

function msg(){
    document.write("Hello Jegan" + "<br>");
}

msg();
document.write(typeof msg + "<br>");