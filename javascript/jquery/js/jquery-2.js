'use stric'

let a = { what: "A regular JS object" },
  b = $( "body" );
 
if ( a.jquery ) { // Falsy, since it's undefined
    console.log( "a is a jQuery object!" );
}

console.log(b.jquery);
 
if ( b.jquery ) { // Truthy, since it's a string
    console.log("b is a jQuery object!");
}