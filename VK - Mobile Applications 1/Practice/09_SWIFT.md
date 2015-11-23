# SWIFT
## Variables and Types
---
var x : Int;  
x = 99  
x = 88; x = 99;  
print(x);   

----

  - UInt
  - Double (Conversion: = Double(x))
  - Float
  - Character
  - String (Conversion: var k:String = String(c))
  - Bool

## Constants
---
let pi : Double = 3.2 (supports the whole unicode character set)

---

## Optionals
---
var a : Int?;  
a = 9;;  
print(a!);   (unpack, will crash if a is nil)  

var a : Int?;
var b : Int;

b = a (won't work, a is optional)
b = a! (will crash)

if a != nil({b=a!}) (check for nil)

var a = b ?? 0 (b will be a if a has a value or 0 if a is nil)

---

## Arrays
---
var integerArray = [Int]();  
integerArray.append(12345);
print (integerArray.count);  
integerArray[0] = 1234;
print(integerArray[1]) (returns an optional, may bi nil)  

var threeDoubles = [Double]{count:3, repeatedValue:00.0)};  
var integerArray : [Int] = [99,8,12,102];  
integerArray += [5,22,232]  
integerArray.removeAtIndex(1)  

---

## Dictionary
---
var simple = [Int : String]();  
simple[1] = "a value";  
var ratingOfArtists : [String : Int] =
["Elvis Presley" : 9, "Bob Marley" : 8, "Neil Diamond" : -1];  
print (ratingOfArtists.count)  
print (ratingOfArtists.isEmpty())  
ratingOfArtists.removeValueForKey("Elvis Presley");

---

## Tuples
---
var errorNoSession = (-22, "User has no session")  
var errorNoRegistration = (-1, "User not registered")  
let (errorCode, errorMessage) = errorNoSession  
print (errorMessage)

---

## Loops
---
var counter = 0;  
for (var i : Int = 0; i < 5;i++) {  
counter += i;  
}  

for index in 0...4 {  
counter += index;  
}  

for (key,value) in myDictionary {  
print (key + " " + String(value));   //prints "Hello 1" /newline/ "World 2"  
}  

for key in myDictionary.keys ...  
for value in myDictionary.values ...  

var counter = 0;  
var i = 10;  
while i-- > 0 {  
counter += i;  
}  

do {  
counter++;  
} while (i-- > 0);  

---

## If THEN ELSE
---
if (a==0) {  
print ("a is null")  
}  

if b == 6 && c == 5 {  
print ("b is six and c is five");  
}  

---

## Switch
---
switch (film) {  
case 1: print("Flew over the Cuckoo's nest");  
case 3: print("Couleurs");  
case 5: print ("Elements");  
case 6: print("Sense");  
case 7: print("Magnificent");  
case 8: print ("And a half");  
case 9: print("District");  
case 11...13: print ("Ocean's");  
case 123: print ("Taking of Pelham");  
case 300: print("This is sparta");  
//the default must always be set!
default: print("I don't know");  

---


## Functions
---
func printGoodMorningFor(name : String) {  
print("Good Morning " + name);  
//the following won't compile as name   is const:  
name = "Hallo Welt"
}  

func sum(a: Int, b: Int) -> Int {  
return a + b;  
}  

printGoodMorningFor("Peter");  
//if you have more than 1 parameter, you need to add their name when calling (b:)  
var result = sum(5, b: 2);  

func printGoodMorningFor(name : String = "Mr X") {  
print("Good Morning " + name);  
}  

func changeName(inout name : String) {   
name = name + "!";   
}  

changeName(&name);  

func plus(a: Int, b: Int) -> Int {  
return a + b;  
}  

func printRes(f : ((Int, Int) -> Int), a : Int, b : Int) {  
print(f(a, b));  
}  

printRes(plus, a : 30, b: 20);  

---


## Closures
---
let sortedNames = names.sort(  
{ (s1: String, s2: String) -> Bool in  
return s1 < s2  
}  
)

let sortedNames = names.sort(
{  
return $0 < $1  
}
)  

---

## Enumerations
---
enum Planet {  
case Mercury, Venus, Earth, Mars, Jupiter, Saturn, Uranus, Neptune, Pluto
}

---
