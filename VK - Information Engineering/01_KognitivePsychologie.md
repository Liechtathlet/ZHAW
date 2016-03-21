# Kognitive Psychologie
## Kognitive Modellierung
Reihe von Methoden um Wahrnehmung, Lernen, Gedächtnis, Denken, Aufmerksamkeit und Sprache zu erforschen, kognitive Modellierung: Computersimulation kognitiver Prozesse

**Phasen:**
  - Aufgabenanalyse:
  - Empirische Untersuchungen: Je nach Modelltyp, idiografisches (rekonstruiert ausgewähltes Problem), prototypisches Modell (konstruiert für alle Probleme), individualisiertes Modell (allgemeine und individuelle Komponenten) - Pendant in IT: Design (Standartlösung, Individuallösung)
  - Modellimplementierung: Programmierung Modell, mittels inkrementeller Modellentwicklung - Pendant IT: Agile Umsetzung
  - Geltungsprüfung: Verifkation Modell mit zwei Aspekten: Identifikatioinsproblem (untersucht Zusammenhang zwischen Modell und Realität bezüglich Abdeckung und Eindeutigkeit), Suffizienzproblem (bestimmt Auflösungsgrad) - Pendant IT: ~Testing

Kognitive Psychologie versucht mittels kognitiver Modellierung herauszufinden, wie unser Hirn funktioniert (bzw. unser Hirn als Informationsverarbeitende Maschine).


## Pattern Recognition
Wahrnehmung von Gegenständen, etc.

**Probleme:**
  - Objektsperation: 2 Objekte auseinander halten
  - Objektisolation: Richtiges Objekt erkennen

### Ansätze zur Erklärung
#### Gestalttheorie
Gesetzmässigkeit finden

**Gestaltgesetzte:**
  - Gesetz der Nähe: Elemente mit geringen Abständen werden zueinander als zusammengehörig wahrgenommen.
  - Gesetz der Ähnlichkeit: Einander ähnlich sehende Elemente werden eher als zusammengehörig erlebt als einander unähnlich sehende.
  - Gesetz der Prägnanz: Gesetz der guten Gestalt - Gesetz der Einfachtheit, möglichst einfache und einprägsame Gestalt.
  - Gesetz der fortgesetzten Linie: Gesetz der guten Fortsetzung, Muster in einer geraden oder sanft geschwungenen Kurve sind in einem Zusammenhang zu sehen. Linien an Schnittpunkten werden bevorzugt im Sinne einer Fortführung gesehen.
  - Gesetz der Geschlossenheit: Geometrische Gebilde: geschlossene Strukturen wirken als Figuren
  - Gesetz des gemeinsamen Schicksals: Muster die eine Bewegung oder Veränderung (Drehung / Verschiebung) in die gleiche Richtung erfahren, werden als Einheit wahrgenommen.

#### Stufenweise Detaillierung
Objektwahrnehmung als Stufenweiser Prozess
  - Physische Welt: Abbild von Objekt auf Retina
  - Grob Sketch: Identifikation von Ecken und Konturen
  - 2.5-D Sketch: verarbetiet globale Flächen aus Rohskizze, Tiefe, Orientierung, Richtungszuweisungen
  - 3-D Model: wandelt die Betrachtung des zu erkennenden Objektes in ein abstraktes, vom Betrachtungswinkel unabhängiges Modell um.

#### Trennung in einzelne Komponenten
Erkennungsprozess von Biedermann, 36 Geons

  - Edge Extraction: Kantenextraktion, Identifikation der 5 Eigenschaften und Zerlegung der Figuren an konkaven Konturen
  - Detection of non-accidential Properties: Eigenschaften (gerade / gekrümmte / symmetrische / asymmetrische / zusammenlaufende Kanten) erkennen
  - Parsing of Regions of Concavity: Alle Bereiche des Objektes werden auf konkave (nach Aussen gewölbte) Schnittstellen hin abgesucht.
  - Isolation of Components: Isolation einzelner Bestandteile
  - Compare Components with Objects: Vergleich mit 36 Geons
  - Pattern Recognition: Erkennung Gesamtobjekt

#### Anwendungsbeispiel Gesichtserkennung
  - Structural Encoding: Aufschlüsselung Geischt gemäss Modell "Objektwahrnehmung als Stufenweiser Prozess"
  - Expression Analysis: Gefühlslage erkennen
  - Facial Speech Analysis: Spracherkennung, erleichtert durch Lippenbewegung
  - Directed Visual Processing: Spezifische Gesichtsmerkmale (z.B. Bart) separat verarbeiten
  - Person Identity Nodes: Knoten beinhaltet persönliche Informationen zu bestimmter Person
  - Name Generation: Name wird separat gespeichert.


## Aufmerksamkeit
Aufmerksamkeit ist der Zustand konzentrierter Bewusstheit, begleitet von der Bereitschaft des zentralen Nervensystems auf eine Stimulation zu reagieren.

  - Fokussierte Aufmerksamkeit
    - Audio
    - Visuell
  - Geteilte Aufmerksamkeit
    - Ähnliche Aufgabe
    - Schwierigkeit der Aufgabe
    - Übung und Automatisierung
  - Unbewusste Aufmerksamkeit (nicht bewiesen)

### Auditative Aufmerksamkeit
Shadowing Effekt: Selektives Hören (auch dichotisches Hören), Ausblendung umleigender Geräusche
  - Single Channel: Bandbreitenbeschränkung der Auswahl, automatische Selektion aufgrund Limit, Aufmerksamkeit wird auf bestimmten Bereich gelegt.
  - Filter Bottleneck: Selektion aufgrund Filter
  - Late Selection: Bewusste Selektion aufgrund Inhalt.
  - Two Stage Selection: Selektion in zwei sChritten, erste Vorselektion auf physikalischen Charakteristika, zweite Selektion aufgrund von Schlüsselwörtern

### Visuelle Aufmerksamkeit
  - Stroop Effekt: Inhalt (Farbname) und Form (Farbe) wmüssen übereinstimmen, damit diese schnell aufgenommen werden.
  - Spotlight-Metaphor: visuelle Aufmerksamkeit kann wie ein Scheinwerfer bewegt werden, selektives sehen.
  - Visual Sensoric Memory: visuelles System kann viele Informationen aufnehmen, ohne Aufmerksamkeitszuweisung gehen die Informationen schnellverloren. Kurzzeitspeicher ("Icons" merken), Alle Details merken? Nur Kurzfreistig abrufbar, zwischen 2-7 Wörter merkbar
  - Mustererkennung: Erkennung von Kombinationen von primitiven Merkmalen

### Kombinierte Modelle
**Supervised Attentional System:**: Wie funktioniert die Kombination von auditativer und visueller Aufmerksamkeit, automatische Aufmerksamkeit (gewisse Reize sind trainierbar, bis zum Reflex, Reflex kann nicht / nur schwer unterbunden / geändert werden), Grundüberlegung: automatisierte Verarbeitung wird durch Schematas kontrolliert, Überwachung durch "Contention Scheduling", bei Konflikt: entscheidet was zuerst weiterverarbeitet wird, Steuerung durch "Supervisory Att"entional System"

## Gedächtnis
2 Wege in der Informatik für Annäherung an die Abbildung eines Gedächtnisses, Modellierung des Gehirns als SW oder in HW, Free Recall Test, 2 Arten von Gedächntnissen: Langzeit (erste Einträge einer Liste werden häufiger als die in der Mitte reproduziert) und Kurzzeit (letzte Einträge einer Liste werden am häufigsten korrekt reproduziert).

Daraus resultierte ein Zweistufenmodell. Aus diesem wurde anschliessend ein Mehrstufenmodell abgeleitet.

### Mehrstufenmodell
  - Sensoric Memory (Store): Pro Sensor: Speicher zur Vorselektion - Visuall, Auditiv, Olfaktorisch, Haptisch, Propriozeption (Schmerz, Hunger, Anspannung, ...), Gleichgewichtssinn
  - Shortterm Memory: Kurzzeitgedächnis mit Spanne von 7 +/- 2 vorverarbeiteten sensorische Einheiten
  - Longterm Memory: Langzeitgedächtnis mit sehr grosser Kapazität

### Erweitertes Mehrspeichermodell
Weitere Unterteilung des Langzeitgedächnisses:
    - Working Memory: Central Executive: Steuert die folgendne Varianten und arbeitet mit dem Semantic Memory zusammen
      - Visuell-Räumlicher Speicher
      - Phonologische Schleife (speichert kurze Ziffernfolgen, Wörter) - Phonologischer Ähnlichkeitseffekt, Wortlängeneffekt, Effekte der artikulatorischen unterdrückudng, Transfer von Informationen zwischen den Codes
    - Longterm Memory
      - Semantic Memory: individuelles Wissen über die Welt, unabhänig von konkreten Lern- / Ereigniskontext, "Vestehen"
      - Episodic Memory: Autobiographische Ereignisse
      - Procedural Memory: Speicherung verinnerlichter hochautomatisierter Vorgänge

### Die mentale Organisation des Wissens
  - Knowledge
    - Simple Organization
      - Object Concepts
      - Relational Concepts
    - Complex Orgnaisation
      - Relational Concepts
      - Events and Other Knowledge Structures
        - Schemata
        - Frames
        - Scripts

#### Simple Organization
  - Klassierung durch Attribute
  - Network Theory of Semantic Memory
  - Allgemeines Netzwerkmodell
  - Feature Comparison Model
  - Prototyp Modelle: Kategorien um zentrale Prototypen, Prototyp: Sammlung von charakteristischen Attributen oder bester Repräsentant seiner kategorie, Abbildung in IT via neuronale Netzwerke
    - Relationales Modell: Grundsätzlich Erweiterung der "isa"-Relation
      - Kann immer durch Prädikatelogik dargestellt werden.
    - Semantische Dekomposition: 12-15 "primitive actions", die alle Relationen umfassen

**Onthologie:** Beliebige Klassifizierung von Wissen, muss nicht hierarchisch sein, muss Knoten von darüberliegenden Knoten nicht vererben.

#### Complex Organisation - Schemata, Frames, Scripts
  - Schemata / Scripts: bestehen aus Beziehungen, Variablen und Werten, verschiedene Ausprägungen, Variablen können wiederum Schemata / Scripts sein
  - Schema: Strukturierter cluster von Konzepten, Struktur ist situativ, auf Basis der vorhandenen Wissens.
