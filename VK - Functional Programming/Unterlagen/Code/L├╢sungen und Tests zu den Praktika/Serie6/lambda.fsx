
// Definition of lambda terms
type Term = 
    | Add 
    | N of int
    | V of string
    | App of Term * Term
    | Lbd of string * Term

// Pretty print lambda terms
let rec print = function
    | N x -> sprintf "%i" x
    | V x -> x
    | App (t,s) -> sprintf "(%s %s)" (print t) (print s)
    | Lbd (v, t) -> sprintf "λ%s.%s" v (print t)
    | t -> sprintf "%A" t 

// Print lambdas in their tree representation (uses latex with synttree package)
let rec treePrint = function
    | App (s, t) -> sprintf "App [%s] [%s]" (treePrint s) (treePrint t)
    | Lbd (s, t) -> sprintf "$\\lambda$ [%s] [%s]" s (treePrint t)
    | V x -> x
    | N x -> sprintf "%i" x
    | t -> sprintf "%A" t

// Computes the free variables of a given term
let freeVar =
    let s, (++), (--) =
        Set.singleton,
        Set.union,
        fun x y -> Set.remove y x
    let rec fV = function
        | V x -> s x
        | App (t,s) -> fV t ++ fV s
        | Lbd (x, t) -> fV t -- x 
        | _ -> Set.empty
    fV

// Save variable substitution
let substitute =
    
    // Auxiliary function checks whether a variable x is among the free variables of a given term
    let isFree x = freeVar >> Set.contains x 

    // Computes a fresh variable that does not exist in the given term
    let freshVar =
        let rec aux var term =
            if isFree var term then aux (var + "'") term else var
        aux "x"

    // safe substitution of term2 for variable var in term1
    let rec sub term1 var term2 = 
        match term1 with
        | V x when x = var -> term2
        | App (t1,t2) -> App (sub t1 var term2, sub t2 var term2) 
        | Lbd (x, t) when x<>var && not (isFree x term2) -> Lbd (x, sub t var term2)
        | Lbd (x, t) when x<>var 
            ->  let z = freshVar (App (t,term2))
                Lbd (z, sub (sub t x (V z)) var term2)
        | _ -> term1

    sub


let rec betaRed term =
    match term with
    | App (Lbd (x, t), s) -> (substitute t x s) 
    | App (t,s) ->  (App (betaRed t,betaRed s))
    | _ -> term


let rec deltaRed term = 
    match term with
    | App (App (Add, N x), N y) -> N (x + y)
    | App (t, s) -> App (deltaRed t, deltaRed s)
    | _ -> term 
 

let rec fix first second t =
    match first t, second t with
    | x,_ when x <> t -> fix first second x
    | _,y when y <> t -> fix first second y
    | _ -> t




// some tests

let add = Lbd ("x", Lbd ("y", App (App(Add,V "x"),V "y")))

let seven = App (App (add, N 3), N 4)

let four = App (App (add, N 3), N 1)

let eleven = App (App (add, seven), four)

eleven |> treePrint

treePrint eleven

eleven|> fix betaRed deltaRed |> treePrint