
let E x = failwith "undefined"

let rec iter n f x =
  if n = 0 then x
  else iter (n-1) f (f x)

let fix1 F n = iter (n+1) F E n

let fakF f x =
  if x < 1 then 1
  else x * f (x-1)

let fak = fix1 fakF

fak 5


let colNext x =
  if x % 2 = 0 then x / 2
  else 3 * x + 1

let colF f x =
  if x = 1 then 1
  else 1 + f (colNext x)

let colLength = fix1 colF

let rec fix2' F G x =
  try G E x
  with _ -> fix2' F (F<<G) x


let fix2 F = fix2' F F

let colLength' = fix2 colF

let rec fixU F G x = fixU F (F>>G) x


let rec fix F f = F (fix F) f


let memoize f =
  let m = new System.Collections.Generic.Dictionary<'a,'b>()
  fun x
    -> match m.TryGetValue x with
      | true, y -> y
      | _ -> let y = f x in m.Add (x,y);y

let log f x =
  printfn "compute @ %A" x
  f x

let memoizeF F =
  let m = new System.Collections.Generic.Dictionary<'a,'b>()
  fun f x
    -> match m.TryGetValue x with
      | true, y -> y
      | _ -> let y = F f x in m.Add (x,y);y

let logRecF F f x=
  printfn "compute @ %A" x
  F f x

let fibF f x =
  if x < 2 then 1
  else f (x-1) + f (x-2)

let fibRecLog = fix (logRecF fibF)

fibRecLog 5

let fibRecMem  = fix (memoizeF fibF)
fibRecMem 10000

let fibRecLogMem = fix ((memoizeF << logRecF) fibF)

fibRecLogMem 10
