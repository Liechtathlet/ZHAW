// Term (V1)
type Term =
  | Add | IsZero
  | N of int
  | V of string
  | App of Term * Term
  | Lbd of string * Term

// Term (V2)
  type Term =
    | ADD | IsZero
    | N of int
    | V of string
    | App of Term * Term
    | Lbd of V * Term

// Term (V3)
    type Term =
      | ADD | IsZero
      | N of int
      | string
      | App of Term * Term
      | Lbd of string * Term

// Term (V24
    type Variable = V of string
    type Term =
      | ADD | IsZero
      | N of int
      | Variable
      | App of Term * Term
      | Lbd of Variable * Term


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

let rec FV = function
  | Lbd (v, t) -> Set.remove v (FV t)
  | App (t1, t2) -> Set.union (FV t1) (FV t2)
  | V x -> set [x]
  |  _ -> Set.empty

let myTerm2 = App (V "y", Lbd ("x",Add))
print myTerm2
FV myTerm2
