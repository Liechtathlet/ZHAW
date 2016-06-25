
//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
// Model solutions exercise sheet 1
//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


//-----------------------------------------
// Exercise 2
//-----------------------------------------

// 2. a)
let exp3 x = pown 3 x


// 2. b)
let fact x = List.fold (*) 1 [2..x]


// 2. d)
let sum f m n = [m..n] |> List.map f |> List.fold (+) 0


// 2. c)
let sumSq = sum (fun x->x*x) 


//-----------------------------------------
// Exercise 3
//-----------------------------------------

// see Exercise 2. c)


//-----------------------------------------
// Exercise 4
//-----------------------------------------

let rec substring u v = 
    let l = String.length u
    l=0 || ((l <= String.length v) && ( u = v.[..l-1] || substring u v.[1..])) 


//-----------------------------------------
// Exercise 5
//-----------------------------------------

// 5. a)
let parens = String.collect (function 'a' -> "<a>" | x -> string x)

// 5. c)
let rec parens2 w =
    if String.length w < 3 then w
    else 
        match w.[..2] with
        | "abc" -> sprintf "<abc>%s" <| parens2 w.[3..]
        | x -> sprintf "%c%s" x.[0] <| parens2 w.[1..]   

