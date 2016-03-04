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

## Funktionen

List.fold
List.sum
List.map
let (|>) f g = g f

'<SomeName> : Indikator für generischen Typ, Bsp List<'a> = 'a List

Typen: rechtsassoziativ
Funktionen: linksassoziativ
