

//-----------------------------------------
// Exercise 2
//-----------------------------------------

// 2. a)
type NatNumber =
    | Zero
    | Next of NatNumber


// 2. b)
let rec eval = function
    | Zero -> 0u
    | Next x -> 1u + (eval x)

let rec interpret = function
    | 0u -> Zero
    | n -> Next (interpret (n-1u)) 


// 2. c)
let rec (++) x = function
    | Zero -> x
    | Next y -> Next (x ++ y) 
    
let rec ( ** ) x = function
    | Zero -> Zero
    | Next y -> (x ** y) ++ x

let rec fact = function
    | Zero -> Next Zero
    | Next n -> (Next n) ** (fact n)


// 2. d)

type IntNumber = {minuend: NatNumber; subtrahend: NatNumber}

let embed n = {minuend = n; subtrahend = Zero}


let add x y = {minuend = x.minuend ++ y.minuend; 
               subtrahend = x.subtrahend ++ y.subtrahend}

let neg x = {minuend = x.subtrahend; subtrahend = x.minuend}

let sub x y = add x (neg y) 

let rec interpretI x =
    if x < 0 then neg (interpretI -x)
    else (embed<<interpret<<uint32) x

let evalI x = ((int<<eval) x.minuend) - ((int<<eval) x.subtrahend)


//-----------------------------------------
// Exercise 3
//-----------------------------------------

let run program =
    let rec aux prog progState valState =
        match progState with
        | [] -> valState
        | (x,y)::xs when (valState * x) % y = 0I
             -> aux prog prog ((x * valState) / y)
        | x::xs 
             -> aux prog xs valState
    aux program program






