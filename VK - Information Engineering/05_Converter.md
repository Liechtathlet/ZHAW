# Converter
**Unterschied zwischen Converter und Compiler:**
  - Compiler-Input: Sprache vom Typ 2, Compiler-Output: Sprache vom Typ 2, Semantik bleibt erhalten
  - Converter: Konvertiert Informationen, Semantik bleibt nicht erhalten, versteht beliebige Sprache
    - 1: Ergänzt fehlendes
    - 2: Lässt weg

## Hardware-Converter
Einsatz: Digital / Analog Wandler, kann als Teil des Kybernetischen Systems Computer dargestellt werden.

  - General-Purpose Processors (GPU)
  - Application-Specific Instruction Set Processors (ASIP)
    - Microcontroller
    - Digital Signal Processors (DSP)
    - ...
  - Programmable Hardware:
    - Field-Programmable Gate Array (FPGA)
  - Application-Specific Integrated Circuits (ASIC)

Je spezifischer die Prozessorklasse desto weniger Flexibilität

### Digital Signal Processors

  - Verarbeitet digital dargestellte Signale
  - Spezielle Architektur zur Beschleunigung sich wiederholender numerisch intensiver Berechnung (Number-Crunching)
  - Multiplikation-Akkumulation-Operation zur Beschleunigung der Signalverarbeitungsalgorithmen
  - Berechnung Kreuzprodukt
  - Harward-Architektur: 2 getrennte Bus-Systeme (Antwort auf Von-Neumann-Bottleneck) + 2 Memories (Programm + Data), vollständig getrennt
  - Spezielle Speicheradressierungsarten und spezielle Kontrollflussoperationen zur Beschleunigung von Schleifen
  - Spezielle On-Chip periphere Funktionen und Schnittstellen

#### Wichtigste Unterschiede DSP - GPU

  - GPU
    - Von-Neumann-Architektur
    - Allgemeine Adressierungsarten
    - Control Unit, ALU, Register - Allgemeine Verwendung
    - Nur ein interner Datenbus
  - DSP
    - Advanced Harward Architecture
    - Spezielle anwendungsbezogene Adressierungsarten
    - Spezielle Control Units und Register zur Adress- und Datenmanipulationen neben der ALU
    - Mehrere Datenbusse zum parallelen Transport von Daten

## Software-Converter
Übersetzung eines Formates von / in ein propertietäres Format / Standardformat, auf den ersten Blick: Aufbau ähnlich dem Compiler (Frontend: Reader, Backend: Writer)

  - Input: Bekanntes Format
    - Input Normalisation: Rausfilterung nicht wichtiger Informationen
    - Lexical Analysis: Erfüllt Input Alphabet?
    - Syntax Analysis: Prüfung Inhalt
    - Context Handling: Anreicherung / Weglassen von Informationen
    - Tree Generation: Aufbau interne Repräsentation
  - Output:
    - Tree Operations
    - Output Generation: Generierung des Outputs
    - Output Normalisation: Normalisiierung Output
    - Output Testing: Korrektheit Output prüfen
    - Output Format Write: "Ausgabe"

**Einsatzgebiete:**
  - Schnittstellenbau
  - Formatumwandler
  - Sprachübersetzer

### Datenkonversion
Vor allem im Bereich Business Intelligence und Data Warehouse, schematisierter Standardprozess (IEEE) (Abbildung 6.16)

  1. DB: Unload
  2. Reformat
  3. Restructerer
  4. Format
  5. DB: Load

### Beispiel: ETL-Prozess
Data-Warehouse, ETL-Prozess immer gleich, pro System 1 ETL-Strasse

  - Data Source
  - Source Databuffer (Kopie der Daten der Data Source)
  - Transformation Space (Durchführung Transformationen)
  - Consolidation Space (Daten Konsolidierung, Überführung in Ziel-Schema, Zusammenführung von Records)
  - Target Space (Fallback)
  - Target Database

**Herausforderungen:**
  - Aktuellere Daten
  - Zu viele Daten

### Transformational Data Integration
Es werden nur bestimmte Daten übertragen, gesteuerte Events, CTF (Capture - Transform - Flow), z.B. nur neue / mutierte Records

  - Mehrstufige Ad-Hoc Query Unterstützung: Dynamische Anfrage neuer Datenbestände
  - Aktualität: Lieferanten können nur geänderte Datenbestände nachliefern, respektive Zielsysteme können Aktualisierungen verlangen
  - Robust: asynchroner Austausch ist stabiler als ETL-Batch
  - continuous Mirroring: Schnelle Nachführung von parallelen Datenbeständen

Ultimative DWH-Frage: Tell me something interesting?

### Modell Driven Conversion
Operation auf Meta-Daten, Meta-Meta-Daten (Modelle), Konversionen auf Meta-Meta-Daten (Modelle), OMG Standard: Meta Object Facility -> Formulierung vo Plattform Independant Models


## Hints
  - Hardware Converter:
    - Wieso gibt es DSP's?
    - Was ist der Von-Neumann-Bottleneck?
    - Wie sieht die Harward-Architektur aus?
    - Allgemeine Typen von Prozessoren (GPU, ASIPS, ..)
  - Software Converter:
    - Grundlegender Aufbau Converter: Unterschied zwischen Compiler und Converter
    - ETL
