// Primzahlensieb

let primes n =
  let rec sieve = function
    | [] -> []
    | x::xs
      -> x::(List.filter (fun y -> y%x <> 0) xs |> sieve)
  sieve [2..n];;
primes 12;;


type 'wayne List2 =
  | E
  | Cons of 'wayne  * 'wayne List2;;

List.
