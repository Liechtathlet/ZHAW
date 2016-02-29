# Aufgaben Serie: 1
## Aufgabe 1
Erledigt

## Aufgabe 2
### a)
~~~
let rec exp3 n =
  match n with
    | 0 -> 1
    | 1 -> 3
    | _ -> (exp3 (n-1))*3;;
exp3 3;;
~~~

### b)
~~~
let rec fak x =
  if x < 1 then 1
  else x * fak (x-1);;
fak 3;;

let fak x = List.fold (*) 1 [1..x];;
fak 3;;
~~~

### c)

### d)
~~~
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
~~~


## Aufgabe 3

## Aufgabe 4
~~~
#r "exerciseTester.dll"
let substring (pattern :string) (input :string) =
  List.exists (fun c -> List.forall (fun p -> input.[c+p] = pattern.[p]) [0..pattern.Length - 1]) [0..(input.Length - pattern.Length)]  ;;

substring "GU" "SUGUS";;
test(substring);

~~~

## Aufgabe 5
### a)
~~~
let parens (input :string) =
  String.collect (fun x -> if x = 'a' then "<a>" else x.ToString() ) input;;

parens "Tannenbach";;
~~~

### b)
~~~
open System
let searchStr = "abc"
let searchC = [0..searchStr.Length-1]
let parens2 (input :string) =
  [0..(input.Length - 4)] |> List.iter (fun i ->
    if (List.forall (fun p -> input.[i+p] = searchStr.[p]) searchC) then
      Console.WriteLine input
    ) ;;
parens2 "TestabcTest";;

let searchStr = "abc"
let searchC = [0..searchStr.Length-1]
let parens2 (input :string) =
  input |> String.mapi (fun i c ->
    if ((i+searchStr.Length) < input.Length && searchC |> List.forall (fun p -> input.[i+p] = searchStr.[p])) then
      "<"+searchStr[0]
    else c);;
~~~
