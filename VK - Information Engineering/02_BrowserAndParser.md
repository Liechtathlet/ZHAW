# Browser und Parser
Voraussetzung für Verständnis von Information: Sprache in der Information definiert worden ist, muss verständlich sein. Maschinen können natürliche Sprachen nicht verwenden, um Informationen zu verstehen.


## Browser als Parser
Mit grösster Wahrscheinlichkeit am meisten verwendete Software der Informatik, MOSAIC: erster grafischer Browser, dann NetScape und IE, heute ca. 60 Web-Browser (~+5 Pro Jahr), Browser: Sprachinterpreter (HTML) aka Parser, Transformation Sprache

  - HTML: Kontextfreie Sprache
  - Grammatik und Syntax
  - Sprachverarbeitende Maschine
    - Sprache - Formale Sprache - Kontextfreie Sprache - Grammatik mit XML-Schema Description - HTML-File
    - Browser: Scanner - Parser - Rendering Engine - Visual Output

**Ursprung:** Trennung Form und Inhalt, Vorteil: Form unabhängig vom Inhalt, kann vorher oder nachher definiert werden, individualisierbar, Vorgänger von HTML: SGML (Standard Generalized Markup Language - Illustrationen, Tabellen, Verkettung von mehreren Dateien, Referenzen, ...)

### Web Browser Reference Architecture
    - Browser Engine
    - Rendering Engine: Parsing HTML-Dokumente, enthält Scanner und Parser für HTML und CSS
    - GUI
    - Plugin Adapter: Adapter für Darstellung und Interpretation von speziellen Dateiformaten oder für spezielle Zwecke
    - Networking
    - JavaScript Interpreter
    - Display Backend
    - Data Persistence

## Natürliche Sprache
"Sprechen ist Anletung zum Handeln", Natürliche Sprachen werden mittels Konstituenz (Wortfolgen), Dependenz (Abhängigkeiten) und Valenz (Kontext) beschrieben.

### Definitionen
#### Konstituenz
Kategorisierung von Einheiten (Wörtern) durch Phrasen, Zusammenfassbar, Kriterien Zusammenfassbarkeit: Ersetzbarkeit, Verschiebeprobe, Pronominalisierung

#### Dependenz
Relationierung von Einheiten, Instanz einer Dependenz: Dependenzgrammatikken, hierarchisch angeordnet, Kriterien Anordnung: Abhängig von Wortformen und Bedingtheit des Auftretens von Wörtern

#### Valenz
Erlaubt Zuordnung funktionaler Rollen als Einheiten mittels lexikalischer Information (Quantitative, Qualitative, Selektionale Valenz), Wörter über Valenz aufgrund Kontext zugeordnet.

#### Lexem
Ungebeugte Grundform eines Wortes oder Wortstammes

### Grammatik
Dependenz Grammatik: Gibt Regeln an, wie die Abhängigkeiten der Lexeme einer natürlichen Sprache über einem gegebenen Alphabet gebildet werden. Tupel (R,L,C,F)
  - R: Menge der Dependenzregeln
  - L: Menge von Lexemen
  - C: Menge von Wortklassen
  - F: Zuweisungsfunktion der Lexeme auf die Wortklassen

Menge der Dependenzregeln ist wiedersprüchlich und nicht endlich

### Implizite Voraussetzung zu Komunikation: Geltungsansprüche
Rede / Sprache als "System universaler und notwendiger Geltungsansprüche", Grundelement: Syntax - Bereiche: Wahrhaftigkeit, Richtigkeit, Wahrheit der Aussage, Syntax der Sprache, Verständlichkeit

**Regeln zur Verständlichkeit von Winograd:** Versuch natürliche Sprache mit allgemeinen Regeln zu definieren: Vokabular, Wortstruktur, Semantik, Referenzen, Zeit, Gesprächsstruktur, Ausrufe, Betonung, Sprachstile, Allgemeinwissen

### Modellierung der natürlichen Sprache
Modellierung über kybernetisches Model des "Language Users", Gehörtes wird über "Sound Pattern" interpretiert

### Natural Language Processing Systems
Zwei Ansätze für Natural Language Processing:
  - Semantic Representation (Semantische Nähe zu gespeichertem Modell finden)
  - Vergleichsmethode

## Formale Sprache
Formale Sprachen werden mittels Wörtern und Alphabeten beschrieben. Gebaut um von Maschinen interpretiert zu werden, wohldefiniert (wiederspruchsfrei)

  - Grundelement: Alphabet (keine Lexeme) (nichtleere, endliche Menge von Zeichen, Buchstaben, Terminale)
  - Wort: Wort über Alphabet ist eine endliche Folge von Zeichen, spezielles Wort: leeres Wort
  - Sprache: Teilmenge des Alphabets
  - Grammatik: Beschreibt Regeln wie aus einem Alphabet die Worte einer bestimmten Sprache gebildet werden.

### Gramatik
Gibt Regeln an, wie eine formale Sprache über einem gegebenen Alphabet gebildet wird

**Formal:**
  - Alphabet
  - V: Menge von Variablen
  - R: menge von Regeln (Produktionsregeln)
  - S: Satzzeichen / Startsymbol

**Eigenschaften:**
  - Keine Variable darf gleichzeitig Keyword sein
  - Variablen sind Platzhalter, die in folgenden Ersetzungsschritten durch die Anwendung von Produktionsregeln ersetzt werden.
  - Menge von Regeln ist endlich
  - Startzeichen ist ein Element der Variablenmenge
  - Grammatik G erzeugt eine Sprache L, Wort w aus Alphabet gehört zur Sprache L

### Chomsky Hierarchie
  - All Languages
    - Recursively Enumerable Language (Type 0)
      - Decidable Languages
        - Context-Sensitive Language (Type 1)
          - Context-Free Language (Type 2) (Alle Programmier- / Script Sprachen)
            - Regular Language (Type 3)

### Beschreibungsmöglichkeiten
Beschreibung mit Hilfe von Metasyntax
  - Backus-Nauer Form (BNF)
  - Extended Backus-Nauer Form (EBNF)
  - XML EBNF
  - Syntaxdiagramme (Terminal: Runde Ecken, Nicht-Terminal: Eckig, Wdh: Pfeile), t: alphanumerisch, a: alpha (Buchstaben), n: numeric
Produktionsregeln: endlich, Beschreibung entweder formal als EBNF oder

#### XML EBNF
~~~
<postal-address> ::= <name-part> <street-address> <zip-part>
<name-part> ::= <personal-part> <last-name> [<jr-part>] <EOL> | <person-
al-part> <name-part>
<personal-part> ::= <name> | <initial> "."
<street-address> ::= [<apt>] <house-num> <street-name> <EOL>
<zip-part> ::= <town-name> "," <state-code> <ZIP-code> <EOL>

Daniel Brun
40 Alte Landstrasse
Thalwil, CH 8800
~~~

~~~
<postal-address> ::= <name-part> <street-address> <zip-part>
<name-part> ::= <personal-part> <last-name> <EOL> | <personal-part> <name-part>
<personal-part> ::= <name>
<street-address> ::= <street-name> <house-num> <EOL>
<zip-part> ::= ["CH-"]<ZIP-code>"," <town-name>  <EOL>
~~~

### Formal Language Processing
Welche Produktionsregeln wurde angewendet -> Verarbeitung

## Scanner und Parser

### Scanner
Durchführung lexikalische Analyse, Zerlegung Input-Stream, Bildung von Einheiten, welche durch Produktionsregeln verarbeitbar sind, Bestimmt ob es sich um ein Terminale oder Lexem handelt, Error-Handling für unzulässige Zeichen, Entfernung von Leerzeichen, etc.

  - Reader: Einlesen Character Stream
  - Lookahead Read: Prüfen und isolieren des nächsten tokens, Was ist der nächste Non-Terminal? Alles dazwischen einlesen, Process dieser Non-Terminal, jeder Non-Terminal: Methoden-Aufruf
  - Symboltable: Tabelle mit Keywords, zulässigen Zeichen / Zeichenketten / Trennzeichen, Aufbau während Scanning
  - Write: Schreiben einzelner Tokens

### Parser
Prüft korrekte syntax anhand der gegebenen Grammatik
  - Management: Mechanismus zur Verwaltung eines Parse-Trees
  - Control: Kontrollsystem zur Steuerung der Verwaltung durch den Baum
  - Input Processor: Mechanismus, der die input Tokens vom Scanner entgegennimmt.
  - Partial Parse Trees: Bereits abgearbeitete Teilbäume

**Tätigkeiten:**
  - Prüfung syntaktische Korrektheit der Tokens
  - Für test syntaktische Korrektheit: Aufbau Parse-Tree

**Parse-Tree:**
  - Wurzel ist das Startsymbol S der Grammatik
  - Innere Knoten: Nonterminals
  - Blätter: Terminals oder leer

Bildung von Teilbäumen anhand der Produktionsregeln der Grammatik, Parse-Tree entweder als Bottom-Up oder Top-Down

## Hints
 - Unterschiede natürliche / formale Sprache
 - Jede Programmiersprache ist eine kontextfreie formale Sprache vom Typ 2
 - Wie kann man eine Grammatik entwickeln: EBNF (Formal), Syntaxdiagramme
 - Verarbeitung formale Sprache: Scanner und Parser (keine Interpretation)
 - Scanner: Vorsortierung anhand Angaben Syntaxdiagramm
 - Parser: Parse-Tree aufbauen, Syntaxbaum: Ausgangslage für weitere Operationen
 - Architektur Web-Browser
