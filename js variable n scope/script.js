// variable

var m = 30;
var n = "hello world";
document.write(m + "<br>");
document.write(n + "<br>");

let g = 10;
if(g>5){
    let y = 20;
    document.write(y + "<br>");
}

// scope

var x = "hello, full stack developer";

function example1(){
    console.log(x);
    document.write(x);
}
example1();

// block scope

function example2(){
    if(true){
        let bv = "GreatStack";
        console.log(bv);
    }
}
example2();
// console.log(bv)  <----- this is wrong because outside block