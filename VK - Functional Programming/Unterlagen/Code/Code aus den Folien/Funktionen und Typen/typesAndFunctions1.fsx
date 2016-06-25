// Examples: Union types and pattern-matching 

type Shape = 
    | Rectangle of float*float
    | Square of float
    | Circle of float
    
    
let area = function
    | Rectangle (l,h) -> l * h
    | Square l -> l * l
    | Circle r -> System.Math.PI * r * r
    


// Complex numbers in either cartesian 
// or polar representation    

type Complex =
    | Polar of float*float
    | Cart of float*float


// multiplication of complex numbers 
// (yields polar representation)    

let rec mulPolar x y = 
    let toPolar = function
        | Cart (r,i) 
            -> let d = Math.Sqrt (r*r + i*i)
               let a = Math.Atan (i/r)
               Polar (d,a)
        | arg -> arg 
    match  x,y with
    | Polar (d,a), Polar (d',a')
        -> Polar (d * d', a + a')
    |  _ -> mulPolar (toPolar x) (toPolar y)
    

// Returns the list of all primes
// below a given int

let primes n =
    let rec sieve = function
        | [] -> [] 
        | x::xs
             -> let filter y = y % x <> 0
                x::(sieve (List.filter filter xs))
    sieve [2..n]  



// Example: Record types    
    
type Comp = {Re: float; Im: float}

let x = {Re = 0.0; Im = 1.0}

x.Im
