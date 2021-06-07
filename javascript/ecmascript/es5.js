console.log('######## ECMAScript 5 ########');

/*
'use strict'
- 선언하지 않은 variable, object를 사용/수정/삭제할 수 없다.
- 함수 호이스팅도 제한한다.
- script나 function 시작 부분에 'use strict';을 선언함으로써 사용
- IE9 미지원
*/
'use strict'

//String.trim()
//string 양쪽 공백 제거
console.log('---String.trim()---');
const helloworld = '    Hello World!    ';
console.log(helloworld.trim()); //Hello World!

//Array.isArray()
//Object가 Array인지 검사
//https://developer.mozilla.org/ko/docs/Web/JavaScript/Reference/Global_Objects/Array/isArray
console.log('---Array.isArray()---');
const fruits = ["Banana","Orange","Apple"];
console.log(Array.isArray(fruits)); //true

//Array.forEach()
//Array의 element들을 하나씩 호출
//https://developer.mozilla.org/ko/docs/Web/JavaScript/Reference/Global_Objects/Array/forEach
console.log('---Array.forEach()---');
const numbers = [3,22,4];
numbers.forEach(value=>{
    console.log(value);
    //3
    //22
    //4
});

//Array.map()
//Array를 순회하면서 새로운 Arrary를 만든다.(기존에 있던 Array는 변경되지 않는다)
//https://developer.mozilla.org/ko/docs/Web/JavaScript/Reference/Global_Objects/Array/map
console.log('---Array.map()---');
const numbers1 = [2,5,3,1,6];
let numbers2 = numbers1.map(value=>value*value);
console.log(numbers2);
//[4,25,9,1,36]

//Array.filter()
//조건에 맞는 새로운 Array를 생성
//https://developer.mozilla.org/ko/docs/Web/JavaScript/Reference/Global_Objects/Array/filter
console.log('---Array.filter()---');
const filterNumbers = [33,3,24,676,33,26];
let over30 = filterNumbers.filter((value,index,array)=> {
    console.log(`value:${value}, index:${index}, array:${array}`);
    //value:33, index:0, array:33,3,24,676,33,26
    //value:3, index:1, array:33,3,24,676,33,26
    //value:24, index:2, array:33,3,24,676,33,26
    //value:676, index:3, array:33,3,24,676,33,26
    //value:33, index:4, array:33,3,24,676,33,26
    //value:26, index:5, array:33,3,24,676,33,26
    return value>30;
});
console.log(over30);
//[33,676,33]

//Array.reduce()
//각 element를 순회하면서 새로운 value를 생성한다.(즉, Array를 하나의 single value로 줄인다.)
//기존에 있던 Array는 변경되지 않는다.
//누적계산시 사용
//https://developer.mozilla.org/ko/docs/Web/JavaScript/Reference/Global_Objects/Array/Reduce
console.log('---Array.reduce()---');
const reduceNumbers = [45,4,9,16,25];
let sum1 = reduceNumbers.reduce((accumulator, currentValue, index, array)=>{
    console.log(`accumulator:${accumulator}, currentValue:${currentValue} index:${index}, array:${array}`);
    return accumulator+currentValue;
});
console.log(sum1); //99

let sum2 = reduceNumbers.reduce((accumulator, currentValue, index, array)=>{
    console.log(`accumulator:${accumulator}, currentValue:${currentValue} index:${index}, array:${array}`);
    return accumulator+currentValue;
}, 10);
console.log(sum2); //109

//Array.reduceRight()
//Array.reduce()와 동일하지만, 오른쪽부터 순회한다.

//Array.every()
//모든 Array의 element들이 주어진 조건을 만족하는지 검사
//https://developer.mozilla.org/ko/docs/Web/JavaScript/Reference/Global_Objects/Array/every
console.log('---Array.every()---');
const everyNumbers = [45,4,9,16,25];
let allOver10 = everyNumbers.every(value => value > 10);
console.log(allOver10);//false

//Array.some()
//Array element중에 주어진 조건을 만족하는 element가 있는지 검사
console.log('---Array.some()---');
const someNumbers = [45,4,9,16,25];
let someOver10 = someNumbers.some(value => value > 10);
console.log(someOver10);//true

//Array.indexOf()
//Array element 중 주어진 value와 같은 element의 위치를 반환(제일 첫번째 위치는 0이다.)
//https://developer.mozilla.org/ko/docs/Web/JavaScript/Reference/Global_Objects/Array/indexOf
console.log('---Array.indexOf()---');
const indexOfNumbers = [45,4,9,16,25];
let getIndex = indexOfNumbers.indexOf(16);
console.log(getIndex);//3

//Array.lastIndexOf()
//Array.indexOf()와 동일한 기능이지만, 오른쪽부터 순회한다.

//JSON.parse()
//serialized json string을 object로 변환
//- 키는 무조건 큰따옴표(“”)로 감싼 문자열이어야한다.
//- 주석은 사용할 수 없다.
//- 프로퍼티로 메소드는 불가능하다.
//- 프로퍼티에서도 메소드의 사용이 불가능하다.
console.log('---JSON.parse(), JSON.stringify()---');
const serializedJsonString = '{"name":"Justin", "age":34, "city":"Seoul"}';
const person = JSON.parse(serializedJsonString);
console.log(person);

//JSON.stringify()
//JSON.parse()와 반대기능. object to string(seiralizedJsonString)
const jsonString = JSON.stringify(person);
console.log(jsonString);

//Date.now()
//시간을 millisecond 단위로 변환
console.log('---Date.now()---');
console.log(Date.now() === new Date().getTime());//true


/*
[추가사항]
ES5 주요함수
함수	                     설명
Object.create	            자바스크립트에서 상속을 이용하기 위해서는 생성자 함수를 만든 뒤 프로토타입 체이닝을 이용해야 한다.
Object.defineProperty	    객체의 필드를 정의하는 함수
Object.getPrototypeOf	    인자로 넘어오는 객체의 프로토타입을 추출한다.
Object.keys	                인자로 넘어오는 객체의 키를 배열로 반환한다.
Object.freeze	            객체를 얼린다라는 표현, 즉 불변(immutable)으로 만든다.
Object.getOwnPropertyNames	프로토타입 체이닝에 걸려있는 필드를 제외하고 객체가 직접 들고 있는 필드의 key를 배열형태로 반환한다.
*/