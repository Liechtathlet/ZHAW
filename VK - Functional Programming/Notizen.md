# Functional Programming

## Environement
~~~
fsharpi
~~~

## Einführung

### Das imperative Modell
~~~
sum ( L) {
l = length ( L) ;
i = 0;
sum = 0;
while i < l do
sum = sum + L[ i ];
i = i + 1;
return sum ;
}
~~~

  - Basiert auf Zuständen, Zustandsübergängen und deren zeitlichen Abfolge
  - Beschreibt wie ein Problem Schritt für Schritt gelöst wird.
  - Probleme werden in geeignete Arbeitsschritte zerlegt, welche in bestimmter Reihenfolge abgearbeitet werden müssen.

### Das funktionale Modell
~~~
let sum = function
| [] -> 0
| a1 :: rest -> a1 + sum rest
~~~

  - Nahe an mathematischen Notation
  - Definition / Beschreibung einer Funktion, anstelle expliziter Anweisungen
  - Keine Variablen (im Sinn von Veränderlichen)
    - Kein Zustand
    - Keine (explizite) Zeit

### Moderne Interpretation
  - Vollwertige Unterstützung von Funktionen (first class functions): Funktionen höherer Ordnung, Lambda-Terme, Currying, partielle Anwendungen, ...
  - Immutability
  - Hoche entwickeltes Typensystem
  - Rekursion

### Anwendungen
  -  Klassisch: Compilerbau, Theorembeweiser, KI
  - Verbreitet: Numerik, Data Science, Fintech
  - Alles bis hin zu GUI (functional reactive programming)

## Funktionen und Typen

### Typen
"Mindestens" 5 Typen, Typen bewirken, das in einer Anwendung gewisse Konsistenzbedingungen eingehalten / erfüllt werden, "Typen ~= Mengen"

#### Werte und Variablen
Objekte die keine Typen sind, entsprechen Elementen in der Mengenanalogie, werden Werte genannt, in der funktionalen Programmierung haben "Variablen" eine andere Bedeutung (Imperativ: Variable ist eine Referenz auf einen Speicherbereich, Wert ändert sich mit der Zeit - Funktional: Der "Name" der Variable benennt in seinem kontext, unabhängig von der Zeit den Wert)

**Konsequenzen:**
  - Wert-Variable-Relation ist im funktionalen Paradigma zeitunabhängig
  - Unveränderbarkeit, immutability

#### Nebeneffekte
In der FUP wird versucht Nebeneffekte zu vermeiden / vermindern / isolieren.

**Typen:**
  - Interne Nebeneffekte (Bsp let f x = y <- x; x)
  - Externe Nebeneffekte, verändern Zustand des Kontextes (Aussenwelt) (Bsp let f x = launchMissle(); 0)

####  Referenzielle Transparenz
Eigenschaften von Nebeneffektfreiem (reinem) funktionalen Code
  - Eine "Variable" kann in einem Ausdruck immer (unter berücksichtigung des kontextes) ersetzt werden. Der Wert ändert sich dadurch nicht.
  - Der Wert eines Ausdrucks hängt nur von den Werten seiner Teilausdrücke ab
  - Evaluation von Ausdrücken ist unabhängig von Reihenfolge, in der seine Teilausdrücke evaluiert werden (Parallelisierung)

imperativer code ist (im allgemeinen) nicht referenziell transparent

**Vorteile:**
  - Einfachere Programmverifikation
  - Erleichterung Beweisführung

### Algebraische Typen

#### Summen
##### Union / Vereinigung
Mengenanalogie: Summentyp entspricht Vereinigung von disjunkten Mengen, F#: Discriminated Unions, wesentlicher Unterschied: Elemente des Summentyps wird die Zugehörigkeit zum entsprechenden "Summanden" explizit mitgegeben (Tagged Union), Zeigt an aus welcher Menge der Wert stammt, Summentypen können rekursiv sein

~~~
type Shape =
  | Rectangle of float * float
  | Square of float
  | Circle of float

3.5 // Float
Square 3.5 //Square
Rectangle (3.5, 3.5) //Rectangle
~~~

Discriminated-Unions können mit Pattern-Matches dekonstruiert werden.

##### Listen
Listen sind als Summentyp definiert
~~~
type 'a List =
| E
| Cons of 'a * 'a List
~~~

Listen können mit [Elemente1; Element2;...] erzeugt werden, Cons Operator / Konstruktor wird durch :: zur Verfügung gestellt - 1::2::3::[] = [1;2;3;], [1;2]::3 funktioniert nicht, 3 ist keine liste, 3::[1;2] funktionoiert)

**List-Comprehensions:**
~~~
[for i in <Bereich> do yield <Ausdruck>]
[for i in 1..10 do for j in 1..5 do yield (i,i+j)]
[for i in 1..10 do for j in 1..5 do if i%2=0 then yield (i,i+j)]
~~~

#### Produkte
Mengenanalogie: Kartesisches Produkt, Tupel, Records sind Tupel deren Einträge Labels (Namen) tragen.

~~~
type Comp = { Re : float ; Im : float }
let x = { Re = 0.0; Im = 1.0}
x. Im ;;
~~~

## Funktionstyp
Funktion: Stellt jeder Eingabe x genau eine Ausgabe f(x) gegenüber, reine Funktion hat keinerlei Nebeneffekte, funktionstypen werden mit -> dargestellt., f:a -> b ist eine Funktion von a nach b

Funktionspfeile sind rechtsassoziativ: f: int -> int -> int ist äquivalent zu f:int -> (int -> int)

~~~
let x y z = y (z <)

x: (a -> b) -> ((a -> b) -> a) -> b
y: a -> b
z: (a -> b) -> c
~~~

### Mehrstellige Funktionen
Funktion mit mehreren Parametern

  - Variante 1: n-stellige Funktion, welche als Eingabewert ein n-Tupel akzeptiert.
  - Variante 2: n-Stellige ist eine Funktion, die eine n-1 stellige Funktion als Returnwert zurückgibt.

## Currying
Currying und Uncurrying: Übersetzen zwischen Variante 1 und 2 (Mehrstellige Funktionen)

## Partial Application
Eine "curried" funktion wird nicht "erschöpfend" mit Argumenten versehen. Im Endeffekt werden mehrstellige Funktionen immer über eine partielle Anwendung angewendet. Hat nichts mit partiellen Funktionen zu tun. ist in FUP ein Mittel um "generischen" Code zu erzeugen.

~~~
let plus4 = (+) 4
~~~

## Optiontypes
~~~
type 'a Option =
  | Some of 'a
  | None
~~~

Modellierung partieller Funktionen:
~~~
let parse (x:string) =
  try Some <| int x
  with _ -> None
~~~

**Vergleich zur Null-Referenz:**
Durch Verwendung eines Option-Types wird explizit gemacht, dass die gegebene Funktion partiell ist.
  - Unterschied zwischen Null-Referenz und validem Objekt sind für Typensystem "unsichtbar"
  - Null-Referenzen machen in FUP wenig Sinn: Werte sind unveränderlich, Namen stehen nicht für Speicherbereiche
  - Null-Referenzen zerstören referenzielle Transparenz (NullReferenceException ist ein Seiteneffekt)

## Höhere Funktionen
Eine Funktion höherer Ordnung ist eine Funktion, die Funktionen als Argumente erhält oder Funktionen als Ergebnis leifert.

~~~
let ref fold folder state = function
  | [] -> state
  | x::xs -> fold folder (folder state x) xs
~~~

## Rekursion
### Formen der Rekursion
  - Primitive Rekursion
  - Wertverlaufsrekursion
  - Strukturelle Rekursion

#### Primitive Rekursion
Rekursive Definitionen zeichnen sich durch die Bezugsnahme auf das zu definierende Objekt aus. Funktionswert an Stelle 0 ist bekannt, gegebenes Verfahren, wie aus bekanten Funktionswerten unbekannte Funktionswerte erzeugen kann (Algorithmus)

#### Wertverlaufsrekursion
Spezialfall: in rekursiver Definition wird auf mehrere "Vorgänger" Bezug genommen

~~~
let rec cor g n =
  g <| List.init n (cor g)

let fib =
  let g xs
    match List.rev xs with
      | x::y::rest -> x+y
      | _ -> 1
  cor g
~~~

~~~
let rec g = function
  | n when n < 3 -> pown 2 n
  | n -> g (n-1) + g(n-2) + g(n-3)
~~~

#### Allgemeine Rekursion
Bis jetzt: Rekursion entlang der "üblichen Ordnung" < der natürlichen Zahlen, Rekursion kann entlang jeder Relation angewendet werden.

#### Strukturelle Rekursion
Spezialfall der allgemeinen Rekursion, Dekonstruktion von induktiv definierten Typen, (Konstruktor wird ersetzt durch Funktion: Siehe Beispiel eval), Rekursion ist universell

~~~
type term =
  | Num of int
  | Sum of term*term
  | Prod of term*term

let rec eval = function
  | Sum (x,y) -> (eval x) + (eval y)
  | prod (x,y) -> (eval x) * (eval y)
  | Num x -> x

let t = Sum (Prod (Num 3, Num 7), Num 2)
eval t
~~~

### Fixpunkte
Fixpunkt: bietet einen konstruktiven Zugang zu rekursiv definierten Funktionen, Fixpunkt = f(x) = x, analog bei höheren Funktionen, Funktion kann keine Fixpunkte haben (f(x) = x+1), kann einen Fixpunkt haben oder mehrere Fixpunkte haen. Einschränkung: Siehe Slides, Leere Menge: Kleinstes Element, Teilmenge von allen, Grösstes Element: Gibt es nicht, Maximale Elemente: Bildet alle ab (Totale Funktionen: failt nie, ist überall definiert), jede Kette hat eine kleinste obere Schranke

### Kombinatoren
Fixpunktkombinator: Funktion die von gegebenen Funktionalen den Fixpunkt berechnet

## Funktionen

List.fold
List.sum
List.map
let (|>) f g = g f

#time
'<SomeName> : Indikator für generischen Typ, Bsp List<'a> = 'a List

Typen: rechtsassoziativ
Funktionen: linksassoziativ
