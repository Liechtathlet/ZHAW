# Informationsvisualisierung
Bereits vor geraumer Zeit war die Visualisierung ein Thema (Stichwort: Napoleon, Edward Tufte: Envisioning Information, Visual Explanations, Visual Display of A.I.), informationisbeautiful.net

  - Es gilt etwas als visualisiert, wenn es sichtbar ist
  - Informationsvisualisierung ist die Transformation des Unsichtbaren
  - Frühe Abstraktion (frühe "Rechenmaschine", grube für Körner)
  - Zwischenzeitlicher Verlust der Abstraktion
  - Mehr schriftlich
  - Mit der Erfindung der Fotografie: Rückkehr der Abstraktion
  - Globales Verständnis auf visueller Ebene (Symbolik)
  - Farben haben sich nicht global durchgesetzt (Landes / Kontinentabhängig)
  - Grundlagen:
    - Transformation
    - Proportionen
      - 3 Grundlagen:
        - Goldener Schnitt (1835), von Martin Ohm, gilt nach wie vor im Häuserbau, Alltagsproportion
        - Tatami: 2:1, japanisch, Baustiel, Betten, Häuser, ...
        - Modulor: Corbusier, Körpermass ausgehend von 1.86
      - Alles was keiner dieser Proportionen folgt, wird nicht als schön wahrgenommen
    - Perspektive
    - Abstraktion (Gemeinsamkeit zwischen Architektur und Informationssysteme)
    - 3d als Erweiterung von 2D
    - Einfachste Dynamik: Drill-Down


# BigData
DataUnser, Zusammengringen sehr grosser Datenmengen aus öffentlichen und privaten Quellen mit modernen und visionären Geschäftsideen in der Geschwindigkeit heutiger Rechnerinfrastrukturen, Wertigkeit der Daten wird zunehmen, nach und nach immer mehr Kombination von internen und externen Daten

  - 3 V's:
    - Volumen (Datenvolumen, Terabyte / Petabeite)
    - Verarbeitung
    - Varianz
  - 3 Ansätze
    - NoSQL: Not Only SQL
      Nicht-Relationale Speicher- und Zugriffs-Technologien: GraphDB, Big Tables, Grid, Document DB, Distributed Cache
    - NewSQL:
      New Generation SQL Technology
    - MAD: Magnetic, Agile Deep (zeigt wie BigData ausgewertet werden kann)
      - Magnetic: Magnetische Anziehung neuer Datenquellen in- und ausserhalb einer Organisation ohne Rücksicht auf "Datenqualitätsluxus"
      - Agile: Schnell aufnehmen, auswählen, verarbeiten anpassen
      - Deep: Tiefgreifende Analyse
    - Information Management

## Mögliche Architektur
  - Execution
    - Input Events
    - Event Engine -> Actionable Events
    - Data Reservoir
    - Data Factory
    - Enterprise Information Store
    - Reporting
    - ...
  - Innovation

  1. Datenquellen
    - Müssen jede Art von Datenquellen laden können (strukturiert / semi- / unstrukturiert, Frequenz, Inhalt, Volumen, Qualität)
  2. Informationsaufnahme
    - Entegennahme Daten
    - Strukturen und Prozesse um Daten in Managed Data Stores zu überführen
  3. Datainterpretation
    - Strukturen und Prozesse um auf Daten in Managed Data Stores zuzugreifen
  4. Die drei Schichten
    - Raw Data Reservoir: Ladevorgang, nichtveränderliche Daten (Hadoop, NoSQL, ...)
    - Foundation Data Layer: Ladevorgang, erste "Veredelungsstufe", Prozessunabhängige Speicherung, Nahe 3NF, Relational
    - Access & Performance Layer: Schicht für optimalen Datenzugriff, Interpretationsvarianten, Ad-Hoc, BI
    - Data Factory: Verantwortlich für Datenverschiebungen innerhalb der Schichten
    - Datenqualität wird von Schicht zu Schicht verbessert
  5. Datenanalyse
  6. Data Factory Ladefluss / Prozessfluss

## Lambda Architektur
  - Sensor Layer
  - Distribution Layer
  - Parallel:
    - Batch-Layer (Komplette Verarbeitung) für Batch View
    - Speed Layer (Delta-Verarbeitung) für Real-Time View
  - Serving Layer

Variante: Kappa-Architektur (mit Feedback / Replay)

# Microservices
Salop "SOA mit kleinen Services"

  - Conway's Law: Zuerst recht übersichtliche Anwendung, man braucht nur eine Anwendung
  - Initiale Aufwände: Neue Anwendung zu realisieren, ist nur scheinbar einfach
  - Komplexität im Betrieb: Grössere verteilte Systeme sind deutlich aufwändiger zu betreiben als kleinere
  - Eigenschaften
    - Skalierbarkeit
    - Verfügbarkeit
    - Agilität
    - Continuous Delivery
