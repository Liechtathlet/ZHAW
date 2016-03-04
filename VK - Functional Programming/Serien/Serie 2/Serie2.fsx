#r @"/home/user/remote/Development/Repositories/github/ZHAW/VK - Functional Programming/Serien/Serie 2/exerciseTester2.dll"

/ **** Aufgabe 1 ****
(*
 Die zweite Funktion gibt immer 0 aus, da y Kontextbezogen ist.
 In der ersten Funktion wird y als Referenz auf einen Speicherbereich verwendet.
*)

let f x =
  let mutable y = 0
  for i in 1..10 do
    printfn "%i" y
    y <- y + i
  x;;

f 5;;

let f x =
  let y = 0
  for i in 1..10 do
    printfn "%i" y
    let y = y+1
    printfn ""
  x;;

f 5;;

// **** Aufgabe 2 ****
// ***** Aufgabe 2a) *****
type NatNumber =
 | Zero
 | Succ of NatNumber ;;

// ***** Aufgabe 2b) *****
let rec eval = function
  | Zero -> 0u
  | Succ n-> 1u + eval n;;

eval (Succ Zero)
eval (Zero)

let rec interpret = function
  | 0u -> Zero
  | n -> interpret (n-1u) |> Succ

interpret 0u;;
interpret 5u;;

// ***** Aufgabe 2c) *****
let rec ( ++ ) x = function
  | Zero -> x
  | Succ y -> Succ (x++y) ;;

let rec ( -- ) x = function
    | Zero -> x
    | Succ y -> Succ (x--y) ;;

let rec ( ** ) x = function
  | Zero -> Zero
  | Succ y -> (x ** y) ++ x;;
//Dekonstruktion, Pattern Match schaut in den Typ rein

let rec fact = function
  | Zero -> Succ Zero
  | Succ n -> (Succ n) ** fact n;;

fact (interpret 5u) |> eval;;

// ***** Aufgabe 2d) *****
type IntNumber = {number1: NatNumber; number2: NatNumber};;

let embed = function
  | Zero ->  {number1 = Zero; number2 = Zero}
  | Succ n-> {number1 = Succ n; number2 = Zero};;

embed Zero;;
embed (Succ Zero);;
embed (Succ (Succ Zero));;

let rec eval = function
  | {number1 = Zero; number2 = Zero} -> 0
  | {number1 = Succ n; number2 = Zero}  -> 1 + eval {number1 = n; number2 = Zero}
  | {number1 = Zero; number2 = Succ n} -> eval {number1 = Zero; number2 = n} - 1;;

eval (embed Zero);;
eval (embed (Succ Zero));;
eval (embed (Succ (Succ Zero)));;

let rec interpret = function
  | 0 -> {number1 = Zero; number2 = Zero}
  | n when n > 0 ->
    let last = interpret (n-1)
    {number1 = (Succ last.number1); number2 = Zero}
  | n when n < 0 ->
    let last = interpret(n+1)
    {number1 = Zero; number2 = (Succ last.number2)};;

interpret 0;;
interpret 5;;
interpret -5;;

//add
let add x y=
   let tmp  = {number1 = x.number1 ++ y.number1; number2 =x.number2 ++ y.number2}
   if tmp.number1 >= tmp.number2 then {number1 = tmp.number1 -- tmp.number2; number2 = Zero}
   else {number1 = Zero; number2 = tmp.number2 -- tmp.number1};;

eval (add (interpret 2) (interpret 3))

//neg
let neg x =
  {number1 = x.number2; number2 = x.number1};;

eval (neg (interpret 5));;

//sub
let sub x y =
  add x (neg y);;

sub (interpret 3) (interpret 2);;

// **** Aufgabe 3 ****
