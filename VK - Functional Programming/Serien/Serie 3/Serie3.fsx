// **** Aufgabe 1
let x1 y z = if y z then 1 else 0
// x1: ('a -> bool) -> 'a -> int

let x2 y z = if z y then 1 else 0
// x2: 'a -> ('a -> bool) -> int

let x3 y z = List.filter y (z y)
// x3: (a' -> bool) -> (('a -> bool) -> a' list)-> a' list


// **** Aufgabe 2)
// f1 Nimmt ein Tupel von (x,y) entgegen. Die Funktion benötigt zwingend ein Tupel als argument und wertet das Ergebnis gleich aus
// f2: Parameter werden als Funktion übergeben. Die Auswertung kann gestaffelt erfolgen. (curried)

//D = (int,int), W= (int)
//D = x:int -> y:int -> int
let f1(x,y) = 2*x+3*y
let f2(x)(y) = 2*x + 3*y

//Aussage ist korrekt, kann aber so nur mit Hilfe von Currying umgesetzt werden.

// **** Aufgabe 3)
//Curried Funktionen können partiell (teilweise) ausgeführt werden.
//Der Zustand der "neuen" Funktion kann gespeichert werden und z.B. in einem späteren Ablauf wiederverwendet werden.


// **** Aufgabe 4)
let rec calculate() =
  printfn "x = "
  let x = System.Console.ReadLine()
  let xP =
    try Some <| int x
      with _ -> None

  printfn "y = "
  let y = System.Console.ReadLine()
  let yP =
    try Some <| int y
      with _ -> None

  let result = match xP with
    | None -> None
    | Some x -> match yP with
        | None -> None
        | Some y -> match (y % 17) with
          | 0 -> None
          | _ -> Some (System.Math.Cos (float (2*x / y )))

  match result with
    | None -> printfn "no valid result"
    | Some x -> printfn "result = %f" x

  printfn "more?  [y/n]"

  match System.Console.ReadLine().ToLower() with
    | "y" -> calculate ()
    | _ -> printfn "au revoir!";;

  calculate ()
