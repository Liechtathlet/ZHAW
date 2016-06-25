
// binary trees

type 'a bTree = E | Nb of 'a bTree * 'a * 'a bTree


// fold
let rec bFold nd e = function
   | E -> e
   | Nb (l,x,r) -> nd (bFold nd e l) x (bFold nd e r)
   
// map 
let rec bMap f = function
   | E -> E
   | Nb (l,x,r) -> Nb (bMap f l, f x, bMap f r)

// map as fold
let bMap' f = bFold (fun l x r -> Nb (l,f x,r)) E






// depth as fold
let bDepth t = bFold (fun l x r -> 1 + max l r) 0 t

// list trees

type 'a lsTree = Nls of 'a * 'a lsTree list

let rec lsFold nls (Nls (x,ts)) = 
   nls x (List.map (lsFold nls) ts)

// map 
let rec lsMap f (Nls (x,ts)) = Nls (f x, List.map (lsMap f) ts)

// map as fold
let rec lsMap' f = lsFold (fun x ts -> Nls (f x, ts))

// depth as fold
let rec lsDepth t = 
   let folder x = function
      | [] -> 0
      | xs  -> 1 + List.max xs  
   lsFold folder t 



// Tests
let T = Nls (3,[Nls(5,[]); Nls(2,[])] )

lsDepth (Nls(34,[T;Nls (4,[])]))























