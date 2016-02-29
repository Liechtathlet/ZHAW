(*****************Aufgabe 1 *******************)
//a: Potenzieren mit 3^n
//a1
let rec exp3 n =
match n with
  | 0 -> 1
  | 1 -> 3
  | _ -> (exp (n-1))*3;;
  
exp3 3;;

//a2
let exp3 = pown 3
exp 3;;

//b: Fakultaet
//b1
let rec fak x =
  if x < 1 then 1
  else x * fak (x-1);;

fak 3;;

//b2
let fak x = List.fold (*) 1 [1..x];;

fak 3;;

//c
//c1

//d:Sum 2
//d1
let rec sum f ug og =
  if ug > og then 0
  else (f ug) + sum f(ug+1) og;;

//d2
let sum f ug og = List.fold (fun x y -> x + f y) 0 [ug..og];;

//d3
let sum' (f: int -> int) ug og = List.sum(List.map f [ug..og]);;

//d4
let sum'' (f: int -> int) ug og =
  [ug..og] |> List.map f
           |> List.sum;;
