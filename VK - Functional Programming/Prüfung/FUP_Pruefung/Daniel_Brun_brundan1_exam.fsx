//=====================================
// Aufgabe 1
//=====================================

//------------------------------------
// a) 
// "list cons" ermöglicht die Erstellung von Listen. Als Shortcut kann "::" verwendet werden. Bsp.: 1::2::3::[] = [1;2;3;]


//------------------------------------
//b)
let StringToCharList (str: string) = str.ToCharArray() |> Array.toList

let upper x = List.contains x ['A'..'Z']

let countUpper str = 
    StringToCharList str
    |> List.filter (fun x -> (upper x)) 
    |> List.length

//------------------------------------
// c)
let claim f xs ys = List.map f (xs @ ys) = (List.map f xs) @ (List.map f ys)  


// i) 
// claim f x y gibt immer true zurück.

// ii)
// Teil a: List.map f (xs @ ys)
// Teil b: (List.map f xs) @ (List.map f ys)
// Im Teil a wird zuallererst eine Liste aus den beiden Listen xs und ys. Daraus resultiert eine Liste mit allen Elementen von xs und ys
// anschliessend wird die Funktion f auf jedes einzelne Elemente angewendet. Das Resultat ist eine Liste mit Elementen (mit gleich vielen Einträgen wie die konkatenierte Liste)

// Im Teil b wird zuerst auf beide Listen getrennt die Funktion f angewendet. Daraus resultieren zwei neue Listen mit den "gemappten" Elementen.
// Diese werden anschliessend wieder konkateniert.

// Da die angewendete Funktion für eine Eingabe das selbe Resultat liefert und die Listenelemente identisch sind, wird der Ausdruck immer "true" ergeben.
// Stichworte: immuutability, Referenzielle Transparenz


//------------------------------------
// Tests sollten true ergeben
countUpper "Hat zwei Grossbuchstaben" = 2



//=====================================
// Aufgabe 2
//=====================================

//------------------------------------
// a) Für mehrstellige Funktionen gibt es zwei Sichtweisen:
// 1: n-stellige Funktion nimmt ein n-Tupel als Eingabewert (Beispiel Typ (a1 * a2 * ... * an)) -> b)
// 2: n-stellige Funktion gibt eine (n-1)-stellige Funktion zurück. (Beispiel Typ (a1 -> (a2 -> (... -> (an -b)))))
// Currying bezeichnet nun die Übersetzung vom 1 in den 2 Ansatz.

// Für die funktionale Programmierung iit der Ansatz zentral, da damit die "Partielle Anwendung" realisiert wird. Bei der "Partiellen Anwendung" wird eine 
// Funktion nicht erschöpfend mit Argumenten versehen. (Beispiel: let plus6 = (+) 6)


//------------------------------------
// b) 
type 'a tree =
    | Leaf of 'a
    | Node of 'a * 'a tree list

let t1 = Leaf 1
let t2 = Node (1, [Leaf 1; Leaf 1])
let t3 = Node (1, [t1; t2])
let t4 = Node (1,[Leaf 1; t3; t2])

// i) A

// ii)
let t5 = Node (1,[Leaf 1; t2; Leaf 1])

// iii)
let rec map f tree = function
    | Leaf x -> Leaf (f x)
    | Node (x, ts) -> 
        Node( f x, (List.map (map f) ts))


//------------------------------------
// Tests sollten true ergeben
map (fun x -> 2 * x) t4 = Node (2, [Leaf 2; Node (2,[Leaf 2; Node (2,[Leaf 2; Leaf 2])]);Node (2,[Leaf 2; Leaf 2])])

map (fun x -> 3) t1 = Leaf 3

let rec sum = function
    | Leaf x -> x
    | Node (x, ts) -> x + List.sum (List.map sum ts)
    in sum (map (fun x -> 3*x) t5) = 18 



//=====================================
// Aufgabe 3
//=====================================

let rec unzip = function
    | [] -> ([],[])
    | (a,b)::xs -> (a::(fst (unzip xs)), b::(snd (unzip xs)))  

//------------------------------------
// a) Die Funktion unzip nimmt eine Liste von 2-Tupel (a,b) entgegen und bildet daraus einen ein 2-Tupel mit zwei Listenelementen ('a list, b' list) welche die einzelnen a und b Elemente beinhalten.


//------------------------------------
// b) 
let unzipTail g =  function
    |  [] -> ([],[])
    | (a,b)::xs -> (a::(fst (unzip xs)), b::(snd (unzip xs)))  

//------------------------------------
// Tests sollten true ergeben
unzip [for i in 1..2..20 do yield (i,i * 2)] = unzipTail [for i in 1..2..20 do yield (i,i * 2)]

([],[]) = unzipTail [] 

unzipTail [for i in 1..2..10 do yield (i,i+1)] = ([1; 3; 5; 7; 9], [2; 4; 6; 8; 10])


//=====================================
// Aufgabe 4
//=====================================

//------------------------------------
// a) Beim Lambda-Kalkül handelt es sich um eine funktionale "Proto-Sprache". Es wird dabei der Ansatz der "Ausdrucksevaluierung" verfolgt. 
// Turing Vollständige Sprache. Bestehen aus Termen, Regeln und Typensystem (evtl. / optional)

//------------------------------------
// b) ii) ist in der Beta-Normalform

//------------------------------------
// c)
// i)  b und c sind freie Variablen
// ii) (((Lxyz.((x y) (x z)) Lx.a) b) c) 
//     => (((Lyz.(Lx.y Lx.y)) b) c) 