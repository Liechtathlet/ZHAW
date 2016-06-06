# Petabyte Computing
1 Petabyte = 1 Milliarde Bücher oder Output eines Wissenschaftlichen Experimentes in 1 Monat, Keine Vorverdichtung zur Speicherung (Könnte Auswirkungen auf die wissenschaftliche Erkentnisse haben), Rohdaten Speicherung, spezielle Architektur, Petabyte: geprägt durch CERN


## Einleitung
### Petabyte Anwendungen

#### Large Scale Commercial Data Warehouse
Petabyte Computing im Unternehmensbereich = Data Warehousing (Aktueller Rekord bei SAP im Labor), Grösste Data Warehouses: Apple und ebay (DWH von Teradata)


## Grid VS Cloud
**Grid:**
- Scale (CPU / Storage / I/O)
- Global Access
- Standards (1-2)
- Universal Access
- Keine Mandantenfähigkeit

**Cloud**
- Scale (Key: Virtualization)
- Global Access
- Standards (mind. 5)
- Kein Universal Access
- Mandantenfähigkeit (Grösster Knackpunkt: Virtuelle Netzwerke / SW-Defined Networking)


Vorgänger von Cloud-Computing: Grid-Computing, Grid-Computing: Meta-Architektur anstatt Virtualisierung

## Die Basis: Database Engines
Standard-Architektur

**Building Blocks einer relationalten DB:**
  - DB Applikation
  - Database Cache
    - Shared SQL Statements
    - Table Buffers
    - Log Buffers
  - DB Server Pool
    - DB Server Process
  - Shared DB Service
    - DB Writer
    - Transaction Log Writer
    - Other Services
    - Backup Writer
  - Database
    - Transaction Log (Speichert Transaktionen, Wer / Was / Wann)
    - Configuration File
    - Backup File
    - Database File (Daten)

Konstante Zugriffsgeschwindigkeit (theoretisch), unabhängig von der Anzahl Records


### Oracle Database Engine
Entspricht fast dem Standard -> Oracle waren die ersten, die das gebaut haben, Markt für relationale Datenbanken: 4 Hersteller, welche relevant sind

**Organisation:**
  - DB Catalog
    - Tablespace
      - Storage Unit
        - File
        - Raw Device
    - Table
    - Database

### DB2 Database Engine
Gleiche Architektur wie MQ-Series (Messaging Infrastruktur von IBM)

  - System Service Address Space (SSAS)
    - SSAS System Services
      - ISDS
      - Active Logs
      - Archive
      - TSO
      - CICS
      - IMS
      - SPAS
    - User Adress Space
      - CAB
  - Database Service Address Space (DBSA)
    - Relational Data Systems
      - DB2 Optimizer
      - Redo Log Buffer
      - Editproc
      - Validproc
      - SQL Utilities
      - Buffer pools
    - Data Manager
      - Sort Pool
      - EDM Pool
      - BIG Pool
    - Buffer Manager
  - Speicherung: VSAM Media Manager (DB2, Table, Data, DB2 Catalog, DB2 Directory)
  - Intersystem Resource Lock


### Microsoft SQL Engine
Ähnlich der Oracle DB, wenig Dokumentation vorhanden


### MySQL Database Engine
Besonderheit: Query processor ("Compiler")

 - Query Processing
 - Transaction Management
 - Recovery Management
 - Storage Management

### Teradata Database Engine
Spezialisiert auf DWH-Anwendungen, garantiert linearen Zugriff (durch Redundante Speicherung), Abfrage via SQL möglich, Teradata -> SpinOff von NCR

  - Processing Element
    - Access Module Processor
  - Result (wird immer mehrfach gerechnet, schnellste Rückgabe zählt)


## Petabyte Computing Infrastructures

### Computing Model des LHC (Ursprünglich)
  - Tier 0: Infrastruktur des Cern, 1727 Prozessoren, 1.2 Petabyte Disk Kapazität
  - Tier 1: Infrastruktur des Cern, welche zu bestimmten Zeitpunkt eingesetzt wird. 832 Prozessoren, 1.2 Petabyte
  - Tier 2: Regional Centers, weitere 4974 Prozessoren und 8.7 Petabyte
  - Tier 3: Zugriff auf die Versuchsdaten & Auswertung

  - 2005: 500 MB pro Sekunde zwischen RZ's in Europa und USA

### Grid Architecture Basics

  - Fabric: Schnittstelle zur lokalen Kontrolle (z.B. einem Speichersystem)
  - Connectivity: Einfache und sichere Kommuniktions- und Authentifizierungsprotokolle, Single-Sign-On (über gesamtes Grid)
  - Resource: Verwaltet einzelne Resource
  - Collective: Organisiert Interaktion zwischen mehreren Ressourcen
  - Application: Applikation, die in der Umgebung einer virtuellen Organisation ablaufen.



## Big Data
2 Varianten

  - V1
    - "Neue Welt":
      - Dinge erzeugen Daten (Sensoren)
      - Social Networks
      - Lambda-Architektur
        - Verdichtung "BIG"
        - Verdichtung "FAST"
      - Anschliessend gleiche Verarbeitun wie in der traditionellen Welt (aber mit Spezialisierter Software für DatenStreams, unstrukturierte Daten)
    - "Traditionelle Welt":
      - Operational Data Store: (Betriebliche) Tätigkeiten erzeugen Daten in betrieblichen Systemen (z.B. ERP, SCM, CRM)
      - 1. Verdichtung: (Daten reflektieren bestimmten Zeitpunkt, Information über Zeitraum, Wichtigster Kontext im betrieblichen Umfeld: zeit)
        - ETL
        - CFL (Deltas)
        - CLEAN
      - Speicherung in Enterprise DWH (Anreicherung um Dimensionen, Dimensional Data Store)
      - Replication & Propagation (Weiterverarbeitung) zu DataMart (Informationsbereiche)
        - Gather
        - Process
        - Apply
      - Analyse & DataMining in DataMarts
    - Rohdaten -> Informationen
  - V2 (Datenanalyse als wissenschaftliches Tool) - Big Data Ecosystem
    - Apps (DataMining, Analytics)
    - Komponenten
      - Streaming Data (für FAST Data)
      - SQL-Like Queries
      - Data Pipeline Access (Weiterstreamen von Daten)
      - Moving (Sehr grosser Datenmengen)
      - Populate (Befüllung der Datenbereiche)
      - Distributed Query Engine
      - Non-Relational-Database (Zwischenspeicher)
      - Distributed File System (z.B. Hadoop, GFS)
    - Cloud (Infrastruktur)
