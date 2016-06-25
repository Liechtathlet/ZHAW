// type inference example

let x y z = y (z y)


// polyadic functions and their interpretation

let add (x,y) = x + y 
let max (x,y,z) = max (max x y) z
let avg (x,y,z,u) = (x + y + z + u) / 4. 

let add' x y = x + y 
let max' x y z = max (max x y) z
let avg' x y z u = (x + y + z + u) / 4. 

let curry f x y = f (x,y)
let uncurry f (x,y) = f x y


// Partial functions and optional values

let parse (x: string) =
    try Some <| int x
    with _ -> None

let f x =
    x |> String.map (function '1' -> '2' | y -> y)
      |> String.filter (fun x -> x<>'a')
      |> parse
      |> Option.map (fun x -> x * x)
      |> Option.map (printfn "%A")
      
let div x = function
    | 0 -> None
    | y -> Some (x/y)
    
let p = div 5 >> Option.map (fun x -> x*x)
