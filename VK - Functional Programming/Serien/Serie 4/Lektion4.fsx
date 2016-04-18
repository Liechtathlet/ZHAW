let rec primRec g c n x =
  if n < 1 then
    c x
  else
    g (primRec g c (n-1) x) (n-1) x

let fak  =
  let g a n x = (n+1) * a
  let c x = 1
  fun n -> primRec g c n 0

// c: Funktion für Defaultwert
// g: Funktion zur Bestimmung des nächsten Wertes
// n:
// x:


let col x =
  match x with
    | 1 -> 1
    | x when (x%2) = 0 -> x/2
    | _  -> 3*x + 1

let rec collSeq x =
  match x with
    | 1 -> [1]
    |_ -> x::(collSeq  (col x))

collSeq 5000

let rec length x =
  if x = 1 then 1
  else 1 + (length (col x))

length 17
