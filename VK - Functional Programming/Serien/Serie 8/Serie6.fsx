type Term =
  | Add | IsZero
  | N of int
  | V of string
  | App of Term * Term
  | Lbd of string * Term

let rec print = function
  | Lbd (v,t) -> sprintf "λ%s.%s" v (print t)
  | App (t1,t2) -> sprintf "(%s %s)" (print t1) (print t2)
  | V x -> x
  | N x -> sprintf "%i" x
  | Add -> sprintf "Add"
  | IsZero -> sprintf "isZero"


let myTerm = Lbd ("x", Lbd ("y", App (App (Add, V "x"),V "y")))
print myTerm

let rec freeVar = function
  | Lbd (v, t) -> Set.remove v (freeVar t)
  | App (t1, t2) -> Set.union (freeVar t1) (freeVar t2)
  | V x -> set [x]
  |  _ -> Set.empty

let myTerm2 = App (V "y", Lbd ("x",Add))
print myTerm2
freeVar myTerm2

//Aufgabe 1
let isFreeVar t x=
  Set.contains x (freeVar t)

//alternative: let is FreeVar x = Set.contains x << freeVar

isFreeVar myTerm2 "x"


let rec freshVar term =
  let x = System.Random().Next(100)
  let name = "v" + string x
  if isFreeVar term name
    then freshVar term
  else name

freshVar myTerm2

let rec substitute t1 var t2 =
    match t1 with
      | V y when y = var
          -> t2
      | App (tx1, tx2)
          -> App ((substitute tx1 var t2), (substitute tx2 var t2))
      | Lbd (v, t) when v = var
          -> t2
      | Lbd (v, t) when not <| (isFreeVar t2 v)
          -> Lbd (v, substitute t var t2)
      | Lbd(v,t)
          ->  let z = freshVar t
              let newLbd = substitute t v (V z)
              Lbd (z, substitute newLbd var t2)
      | _ -> t1

let tl = Lbd ("x", Lbd("y", App (App("x", "y"), "z")))

print (substitute tl "z" (V "u"))
print (substitute tl "z" (V "x"))
