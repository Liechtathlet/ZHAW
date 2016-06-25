let myString = "hello"

//-------------------------

let rec exp2 x =
   if x < 1 then 1
   else 2 * exp2 (x-1)


//-------------------------

let add x y z = x + y + z

let add10 x = add 0 10 x 

let sub x y = add 0 x -y

sub 100 58


//-------------------------

let isEvenAndNonzero x =
   match x with
   | 0 -> false
   | x when x % 2 = 0 -> true
   | x -> false 
   
//------------------------

let compose f g x = f (g x)

//------------------------

//denotes a function f with f x = 5 * (x + 10)
compose (fun x -> 5 * x) (fun x -> x + 10)

//------------------------

let f x = 
   function
   | 1 -> "Eins"
   | 2 -> "Zwei"
   | 3 -> "Drei"
   | _ -> "viel"

   
//------------------------

// define "infix" functions
// with brackets
let rec (^) x y =
   if y < 1 then 1 
   else x * (^) x (y-1)

// apply "infix"
2 ^ 10

//------------------------

   