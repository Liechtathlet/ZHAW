# Integration
Script: 2 Kapitel aus dem Buch "Service Oriented Architecture: An Integration Blueprint"

## Einleitung / Allgemeines
Ebenen: GUI, Prozessse, Logik, Daten  

2 Konzepte für Integration (Praxis): Entweder auf Ebene Prozess oder Daten
  - GUI / Screen: Portal
  - Prozesse: Process Engines
  - Logik: Serviceson
  - Data: EAI Plattform / Middleware (MQ-Series von IBM: 80% Marktanteil, ESB's: IBM: WebSphere, Oracle: OSB, SAP: PI, MS: BizTalk, Tibco (Telekomm), Iona (CORBA), ...)

**Anmerkung:** Appliances für Integration On-Premise-Umgebung mit externen Umgebungen, bzw. der Cloud.

## Begriff: Integration
Kap02, S. 8 (4): A2A, B2B, B2C (eher selten)

### Integrationstyp: Daten
  - **Data Replication:** Häufig: Replizierung der Daten in der Datenbank (Import / Export) in der Nacht
  - **Shared Data:** Sehr selten (Versicherungen), bei hohem Grad an Individualentwicklungen

### Enterprise Application Integration (EAI)
K02S09: Verbindung / Teilung von Daten und Geschäftsprozessen, verschiedene Integrationsebenen: Daten, Objekt, Prozess

### Grundlegende Techniken
  - Messsaging: Typisierte Meldung, Beschreibung einer Aktion (Ebene Objekt / Service) oder von Daten, oft Kombination Daten und Funktion (z.B. Löschmeldung für Kunde), Producer - Queue - Consumer, Grundkonstrukt der Integration
  - Publish-Subscribe: Publisher - Queue - Subscribers, Verfeinerung von Messaging, "Einschreiben" für verschiedene Topics, Parallelisierung möglich
  - Message-Broker: Mehrere Queues, Sender und Subscriber, verschiedene Arten: Hub-And-Spoke-Architektur, Message Routing, Message Transformation
  - Messaging-Infrastruktur (Broker): Relativ granular, Viele Meldungen schnell, prozessieren, Local Queue: Logisches Gebilde, Meldungen werden so oft repliziert, wie diese Gebraucht werden (es müssen alle Consumer bedient werden), 3 Mechanismen: Intermediate Queue, (Wenn nicht geliefert werden kann) Message Management (Versand, Routing, Umwandlung, Tracing, Garantierte Lieferung, ...), Event Management (Steuerung Subscribe-Mechanismus über Ereignisse))
  - Enterprise Service Bus (ESB): Generalisierte Form, Zusätzliche Abstraktionsstufe, Messaging: Meldungs-Orientierter Schnittstellen, ESB: kann alle Schnittstellen bedienen (durch Adaptoren), Adaptoren: z.B. Format-Konvertierungen, ESB vor allem im Umfeld von vielen Standard-Lösungen (da meist proprietäre Schnittstellen)
  - Middleware: Synchron: Warten, bei Verteilten Systemen: Gefahr von Dead-Locks, oft genügt Asynchron, Synchron wenn: Master-System oder (Near-) Real-Time-Anwendung, 5 Kategorien
    - Conversational: Synchrone Kommunikation, Real-Time-Systeme, z.B. Feldbustechnologie, Produktionssteuerung
    - Request / Reply
    - Message Passing: 1 Richtung, Möglichkeit für Callback
    - Message Queuing: Indirekter Versand, Near-Real-Time
    - Publish / Subscribe
  - Middleware-Basistechnologien:
    - Data-Oriented Middleware
    - Remote Procedure Call: Eigentlich Service- / Object / Component-Oriented
    - Transaction-Oriented: Data-Oriented mit einer speziellen Einschränkung
    - Message-Oriented
    - Component-Oriented

** Routing Schemas: ** Anycast: 1:N - best reachable

### Integrations-Architekturvarianten
  - Point-to-Point-Architektur: Logische Integration, Direkter Aufruf, jeder weiss wo der andere ist, billig, autonom, nur bei wenigen Systemen / Verbindungen gut
  - Hub-and-Spoke-Architektur: 1 zentraler Hub, mehrere Spokes, Hub synchronisiert alles, z.B. Fahrplansysteme
  - Pipeline-Architektur: Normalfall: Mehrere zentrale Server, eigentlich benötigte Architektur für ESB, macht ESB teuer (Bezahlung pro Node)
  - Service-Orientierte Architektur

## Service Oriented Integration
K02S27

## Data Integration
K02S30
  - Federation: Erlaubt Zugriff auf verschiedene Datenquelle, Zusammenfassung als 1 logische Datenquelle ("Virtuelle DB"), Verwendung von Meta-Daten, Near-Real-Time-Zugriffe, es werden keine Daten kopiert
  - Population: Daten von 1 oder mehreren Datenquellen sammeln, Verarbeiten und gegen Zieldatenbank appliziert, "ETL-Prozess", es werden Daten kopiert
  - Synchronisation: Vermeiden wenns geht, am Ende meistens in der Multi-Step-Synchronisation

## EAI / EII

  - Direct Connections: Direkte Verbindung von A nach B, Einweg, Real-Time, Legacy
  - Broker: Broker-Rules (Verbindungsregeln), Verteilung Logik / Daten, Nur 1 Interface, mehrere Anwendungen anhängen, z.B. bei Hub-And-Spoke, Quellsystem soll nichts über Zielsystem wissen.
  - Router: Variante von Broker, immer nur genau eine Zielapplikation, z.B. bei Gleichartigen-Systemen (First-come-first-serve)

## Event Driven Architecture (EDA), GRID, XTP
K02S40, Spezialfälle, Eingesetzt im Hochleistungsbereich, relativ selten, häufigste: EDA

- EDA: Reaktions-Tempo, schnelle Aktion notwendig
- GRID: Zugriffs-Tempo, schneller Datenzugriff notwendig
- XTP (eXtreme Processing): Transaktions-Tempo, hohe Transaktionsleistung

### EDA
Event verarbeitet durch Regelanwendung, 1:n Events, einzelne Events nicht problematisch, Häufigkeit des Events über die Zeit ergibt evtl. Problem, Korrelation Event und Zeit, Bsp.: schnell steigender Wasserpegel, Plattform: ESPER

- Event Processing
  - Simple Event Processing
  - Event Stream Processing
  - Complex Event Processing: Abbildung Regeln in Filter-Modell: Filtering - Correlation - Aggregation - Rules

### GRID
Produkt: Coherence (Oracle)  
  - Data Grid
    - In-Memory Data Grid: Verteilte Hochleistungsanwendung, Datenzugriff auf Objekte in Memory, Persistente Datenbasis, aber vollständig transparent, alle Objekte In-Memory zugreifbar
    - Domain Entity Grid
    - Domain Object Grid

### XTP
Daten logisch verteilen, Modebegriff, viele Probleme können heute mit SSD's gelöst werden


## Basistechnologien
### XA-Transaktionen
Vermeiden, wenn möglich, Write- / Update über mehrere verteilte Systeme, Top-Level-Transaktionen über mehrere heterogene Ressourcen, jeder ESB unterstützt das

### OSGI
Protokoll in Fahrzeugen, HLA (High-Level-Architecture) für "Arme", klein, auch für embedded Systems geeignet.
