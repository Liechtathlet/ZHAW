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


## Funktionen

List.fold
List.sum
List.map
let (|>) f g = g f
