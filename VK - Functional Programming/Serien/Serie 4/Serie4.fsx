// Aufgabe 1
// Betehende Implementation
let logger f x =
  printfn "computing %A..." x
  f x

let loggedMap f x = List.map (logger f) x

loggedMap (fun x -> x*x) [1..4]

//Fix Punkt Implementation
let log f x =
  printfn "compute @ %A" x
  f x

let logRecF F f x=
  printfn "compute @ %A" x
  F f x

let rec fix F a = F (fix F) a

let fibF f x =
  if x < 2 then 1
  else f (x-1) + f (x-2)

let fibRecLog = fix (logRecF fibF)

//Rekursives Logging mit Zielfunktion aufrufen
//Resultierende partielle Funktion als Argument für fix
//

fibRecLog 5

//Implementation mit Funktional
let log f x =
  printfn "compute @ %A" x
  f x

let logF f =
  let rec log' x =
    printfn "compute @ %A" x
    f log' x
  log'

let fibF f x =
  if x < 2 then x
  else f (x-1) + f (x-1)

let logFibF = logF fibF

logFibF 2


//Aufgabe 2
// Binary tree
type 'a bTree = E | Nb of 'a bTree * 'a * 'a bTree


let rec foldABT folder state = function
  | E -> state
  | Nb (a,b,c) ->
    folder b (foldABT folder state a)
    |> folder (foldABT folder state c)

let myTree = Nb (Nb (E,1,E),1,Nb (E,1,E))

foldABT (+) 2 myTree

// List tree
type 'a lsTree = Nls of 'a * 'a lsTree list

let rec foldALST folder lv = function
  | Nls (v,[]) -> folder v lv
  | Nls (v,ls) ->
    if (List.isEmpty ls) then
      v
    else
      let res = List.map (fun (a') -> (foldALST folder lv a')) ls
      v :: res |> List.reduce (fun acc elem -> folder acc elem)

let myListTree = Nls (1,[Nls (1,[Nls (2,[])]);Nls (1,[Nls (3,[])]);Nls (1,[])])

let myListTree2 = Nls (1,[])
foldALST (+) 1 myListTree2

let myListTree3 = Nls (1,[Nls (1,[]);Nls (1,[]);Nls (1,[])])
foldALST (+) 1 myListTree3


let rec foldALST folder state = function
  | Nls (a,[]) -> folder a state
  | Nls (a,ls) ->
    List.fold (fun acc elem ->
      foldALST folder state elem
      |> folder acc ) state ls
    |> folder a
