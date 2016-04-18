# Prozessortechnologie
## Allgemeines
Microprozessorarchitektur: Dokument, welches das Verhalten aller möglichen Implementationen beschreibt, eine Implementation ist ein einzelner Chomputer-Chip, Architektur für mehrere Generationen von Chips, Architektur muss Verhalten sehr genau beschreiben, aber nicht die Art und Weise einer spezifischen Implementation, Verhalen im Befehlssatz (Instruction Set), Unterstützt Grammatik vom Typ 2 (nach Chomsky, kontextfreie Sprache)

### Random Access Machine
Theoretische Ebene: Basis für Theoretische Informatik, Weiterentwicklung des Von-Neumann-Modells: Random Access Machine, 3 Zusätze
   - Trennung Input / Output-Tapes
   - Programcounter (Ablaufsteuerung des Programs)
   - Memory (Prozessorinterne Register)

### Parallel Random Access Machine
Besteht aus einer Reihe von unabhängigen RAM's, Kommunikation via Shared Memory

**Klassifikation**:
  - EREW-PRAM: Exclusive Read- Exclusive Write (ein RAM kann zur Zeit lesen / schreiben)
  - CREW-PRAM: Concurrent Read - Exclusive Write
  - CRCW-PRAM: Concurrent Read - Concurrent Write (Kern: Workspace, virtueller Prozessor)

### Vector Random Access Machine
Einsatz: Vektorbasierte Massenverarbeitung (z.B. Wettervorhersage)

**2 Prozessoren:**
  - Skalarer-Prozessor (normal)
  - Vektor-Prozessor (Speicher und Register für Vektoren)

## Flynn's Taxonomie
**Klassifikation Rechnerklassen:** ()
  - SISD: Single Instruction Stream, Single Data Stream (Mono-Prozessoren)
  - MIMD: Multiple Instruction Stream, Multiple Data Stream (Multiprozessoren, verteilte Systeme)
  - SIMD: Single Instruction Stream, Multiple Data Stream (Vektorrechner, Arrayrechner)
  - MISD: Multiple Instruction Stream, Single Data Stream (Pipelinerechner)

### SISD
Direkte Umsetzung RAM, "von Neumann Computer", 4 Teile: CPU, ALU, Memory, I/O - Von-Neumann-Bottlenck: Instruktionen und Daten über die selbe Verbindung (Bus)

### MIMD
Ressourcen können zwischen Prozessoren geteilt werden und interagieren (Coupling) - Loosely Coupled MIMD (Prozessoren / Memory via Netzwerk - Cross-Bar-Switch), Tightly Coupled MIMD (Prozessoren / Memory auf einem Node), Grundarchitektur aller Parallelrechner

### SIMD
Jede Einheit folgt der selben Instruktion (aber auf unterschiedlichen Daten)

#### Array Computer
1 Control Processor, Array von Processing Elements, erster Supercomputer: Cray-1

#### Connection Machine von Thinking Machines Corporation
Umsetzung Array-Computer als Nachbau des menschlichen Hirns

  - Front End 0 - 3: User Interface
  - Bus Interface
  - Nexus
  - Sequencer 0 - 3
  - Connection Machine: 16'384 Prozessoren
  - Data Vault: Massenspeicher
  - Graphic Display

### MISD
Grafikprozessoren (nicht rein MISD, oft kombiniert)

## Prozesorfamilien - Konzepte und Techniken
### Logischer Aufbau
  - CPU
  - Register
  - ALU (Arithmetic Logic Unit)
  - Control Unit: Ausführung Maschinenbefehle im Prozessor
  - Clock: Synchronisation interne Operationen der Prozessoren mit den anderen Systemkomponenten
  - Bus: Data-Bus, Control-Bus (Synchronisation), Adress-Bus (Instruktionen)


### Virtuelle Maschine
Maschine, die eine Maschine simuliert, Flexibilität der Informatik basiert auf diesem Prinzip / Konzept, 2 VM's: Mikroarchitektur (Abbildung Mikroarchitektur, Microinstructions, in sich bereits eine VM), Instruction Set Architecture: Zugriffsebene auf Prozessor, Veröffentlichung durch Hersteller von Assemblern / OS

## Hints
  - Logischer Aufbau des Rechners
  - 2 wichtige Busssysteme: In konventionellen Rechnern zusammengefasst (Von Neumann Bottleneck)
  - Virtuelle Maschine: Grundlage der Flexibilität der SW / hardwarenahen SW
  - Zeichnung High Performance Computing Java
