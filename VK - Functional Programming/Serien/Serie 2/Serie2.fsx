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
  | n -> Succ (interpret (n-1u))

interpret 0u;;
interpret 5u;;

// ***** Aufgabe 2c) *****
let rec ( ++ ) x = function
  | Zero -> x
  | Succ y -> Succ (x ++ y) ;;

let rec ( -- ) x = function
    | Zero -> x
    | Succ y ->
      match x with
        | Zero -> Zero
        | Succ x -> x -- y;;

eval ((interpret 4u) -- (interpret 2u))

let rec ( ** ) x = function
  | Zero -> Zero
  | Succ y -> (x ** y) ++ x;;
//Dekonstruktion, Pattern Match schaut in den Typ rein

let rec fact = function
  | Zero -> Succ Zero
  | Succ n -> (Succ n) ** fact n;;

fact (interpret 5u) |> eval;;

// ***** Aufgabe 2d) *****
type IntNumber = {minuend: NatNumber; subtrahend: NatNumber};;

let embedInt = function
  | Zero ->  {minuend = Zero; subtrahend = Zero}
  | Succ n-> {minuend = Succ n; subtrahend = Zero};;

embedInt Zero;;
embedInt (Succ Zero);;
embedInt (Succ (Succ Zero));;

let evalInt x =
  let a = int <| eval(x.minuend)
  let b = int <| eval(x.subtrahend)
  a - b

evalInt (embed Zero);;
evalInt (embed (Succ Zero));;
evalInt (embed (Succ (Succ Zero)));;

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
  {minuend = x.minuend ++ y.minuend; subtrahend = x.subtrahend ++ y.subtrahend}

eval (add (interpret 2) (interpret 3))

//neg
let neg x =
  {minuend = x.subtrahend; subtrahend = x.minuend};;

eval (neg (interpret 5));;

//sub
let sub x y =
  add x (neg y);;

sub (interpret 3) (interpret 2);;

// **** Aufgabe 3 ****
// Fractran, esoterische, Pseudosprache, Touring-Vollständig, Liste von Brüchen
// (x,y), (a,b), (c,d)
// Funktion von n -> n
// Beispiel: 15 (input) -> ((1/4),(1,5)), Term für Term: input durch Term ganzzahlig teilbar, fertig wenn kein Term mehr teilbar
// Rekursion: Status-Variable mitgeben
// 5I -> BigInt 5

let myProg =  [(1I,4I); (1I,5I)]
let myInput = 15I

let rec interpretFractran prog input =
  let resT = List.tryFind (fun t ->
      match t with
        | (a,b) -> (((a*input) % b) = 0I)) prog
  match resT with
    | None -> input
    | Some (a,b) -> interpretFractran prog (((a*input) / b));;

interpretFractran myProg myInput;;
