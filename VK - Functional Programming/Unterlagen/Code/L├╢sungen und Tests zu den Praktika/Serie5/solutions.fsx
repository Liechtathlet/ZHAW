//==================================================
// Exercise 1.
//==================================================
//
// Ja/Nein/Nein/Nein/Ja


//==================================================
// Exercise 2.
//==================================================
//


// Gegebene Funktion
let rec sieve pred = function
   | [] -> []
   | x::xs -> x::(sieve pred (List.filter (pred x) xs))

// Akkumulator Pattern
let sieveAcc pred =
      let rec sieve' acc = function
         | [] -> acc
         | x::xs -> sieve' (x::acc) (List.filter (pred x) xs) 
      sieve' [] >> List.rev

// Continuation Pattern
let sieveCont pred =
   let rec sieve' cont = function
      | [] -> cont []
      | x::xs -> sieve' (fun y -> x::(cont y)) (List.filter (pred x) xs)
   sieve' id >> List.rev

// Primzahlen durch Sieb
let primes n =      
   let primesPred x y = y % x <> 0
   sieveAcc primesPred [2..n]

// oder
let primes' n = sieveCont (fun x y -> y % x <> 0) [2..n]

//==================================================
// Exercise 3.
//==================================================
//

let rec fix f x = f (fix f) x

let primesF f = function
    | [] -> []
    | x::xs -> x::(f (List.filter (fun y -> y%x <> 0) xs))


let primes'' n = fix primesF [2..n]
