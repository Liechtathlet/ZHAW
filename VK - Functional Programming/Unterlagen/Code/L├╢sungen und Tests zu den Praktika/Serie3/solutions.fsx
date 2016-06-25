//========================================================
//  Exercise 1.
//========================================================
// Vgl. FSI

//========================================================
//  Exercise 2.
//========================================================
//
// f2 ist die "gecurriete" Variante der Funktion f1. Wenn man
// in der Eingabe das '_' als Platzhalter für einen beliebigen
// Wert interpretiert, dann entspricht f1(3,_) der partiellen
// Anwendung von f2 auf 3.


//========================================================
//  Exercise 3.
//========================================================
//
// Curried Funktionen erlauben partielle Anwendung. Man kann
// daher generischen/parametrischen Code schreiben ohne für die
// Parameter "dummy-Werte" einsetzen zu müssen.

//========================================================
//  Exercise 4.
//========================================================


//--------------------------------------------------------
//  Basic "option-functions"
//--------------------------------------------------------

let printOption def = function
   | Some x -> sprintf "%A" x
   | None -> def

let liftOptionPair = function
   | (Some a, Some b) -> Some (a,b)
   | _ -> None

let save f x =
    try 
        f x |> Some
    with
        | _ -> None

//--------------------------------------------------------
// App specific functions
//--------------------------------------------------------


// The function that needs to be computed
// without "DivideByZeroException"
let oldFun (x,y) = 
   (2*x) / (if y% 17 = 0 then 0 else y) 
   |> float |> cos


// Returns the answer to a user defined input given as 
// a pair of strings. 
let answer (x,y) =         
    (save int x, save int y)       // first savely parse the input
     |> liftOptionPair             // next lift option out of the tuple
     |> Option.bind (save oldFun)  // then apply the save variant of the old function
     |> printOption "Bad result"   // finally print the answer


//--------------------------------------------------------
// The main function
//--------------------------------------------------------

let rec main () =
    
    // Request user input    
    printfn "x = "
    let x = System.Console.ReadLine()
    
    printfn "y = "
    let y =  System.Console.ReadLine()

    // print answer    
    printfn "%s" <| answer (x,y)
    
    // Terminate or iterate main        
    printfn "more? [y/n]"
    
    match System.Console.ReadLine().ToLower() with
    | "y" -> main ()
    | _ -> printfn "Au revoir!"
    


//--------------------------------------------------------
// Toplevel: call main   
//--------------------------------------------------------

main ()
