## Architektur Standards
### Enterprise Architecture Management
Anwendungslandschaft zentraler Unternehmenswert, Ziel EAM: Sicherstellung der effizienten IT-Unterstützung, Umfeld: Geschäftsprozesse, Produktportfolios, Vertriebskanäle

Zusammenarbeit Unternehmens- / IT-Strategie

#### Architekturtypen
**Beispiele:**
  - Business Architecture
  - Information Architecture
  - Technology Architecture
  - Solution Architecture

#### Methoden & Frameworks
  - ISO
  - Information System Architecture (ISA): 30 Modelle
  - Open Distributed Processing (ODP): Verschiedene Betrachtungswinkel, Zusammenhänge
  - TOGAF
  - GERAM
  - CIMO
  - PERA
  - ...

#### Business Architecture
**Die Idee:** Formalisierung Geschäftstätigkeit, Problematik: Formalisierung IT sehr weit fortgeschritten, aber: geschäftliche Tätigkeit kennt Formalisierung nur im Bereich Business Process Engineering --> ein Stück fehlt

**Die Elemente:** Wertschöpfungsnetzwerk, Geschäftsmodell, Prozesslandkarte und Wertschöpfungsketten, funktionenmodell, Informations- und Datenmodell, Bebauungsplan zur Strategieumsetzung

  - Wertschöpfungsnetzwerk: Was macht wer in der Wertschöpfung? Visualisierung im Markt mit Position und Umfeld, Darstellung Marktrollen
  - Geschäftsmodell: Visualisierung, Beschreibung Fkt, Schnittstellen, Soll-Bruchstellen, strat. Optionen
  - ...

  ####IT Governance
  Ausgangsbasis: Gesamtbetrachtung

  **Betrachtungsweisen:**
    - Information Architecture
    - Information Quality
    - Information Security


#### Herausforderungen
  - Trennung Anwendungen und Daten (Ablauf & Aufbau)
  - Verschiedene Systemtypen


### Allgemeine Hinweise
Heute eingesetzte Standards (flächendeckend, Industrie): Java EE, .NET, TOGAF  

#### Java + .NET
  - Zweck: Wie baue ich eine Enterprise-Lösung als Individual-Software
  - Inhalt: Bewährte Methoden, Libraries, Best Practices, Do's, Don't's
  - Eignen sich grundsätzlich für das selbe (Enterprise Anwendungen)

#### Individual-Software-Entwicklung
  - Local (meist nicht relevant für Architektur)
    - Big: C, C++
    - Small / Medium: Viele Teillösungen, spezialisierte Sprachen, VB, PHP, Phyton
  - Distributed (Architekturrelevant)
    - Big / Medium: .NET / Java
    - Small: Swift, Objective C, ...

### Java Platform, Enterprise Edition
  - Ursprung: Programmiersprache Java (Green Project), Haushaltssteuerung, Objecct Application Kernel (OAK)
  - Interpretierbar via VM
  - Aufbau Modell
    - Web Browser: HTML
    - Web Server: Servlets, JSPs (Rendering)
    - Application Server: EJBs, POJOs
    - Backend Systems
  - Libraries / Methoden um Daten zwischen verschiedenen Tiers auszutauschen

### .NET Framework
  - Jünger als Java
  - Interpretierbar via VM (Common Language Runtime: CLR, Classloader, Managed Native Code, Execution & Security Checks, JIT Compilation with optional verification)
  - Aufbau Modell (grundsätzlich analog Java)
  - Libraries / Methoden um Daten zwischen verschiedenen Tiers auszutauschen

### Information Systems Architecture (ISA) - Historisch
Formale Darstellung Geschäftstätigkeiten in allen Aspekte, einfachere Ableitung Systeme, Verschiedene Perspektiven, Fokus, 3 Teilbereiche der Formalisierung haben sich durchgesetzt:
  - Prozesse
  - Organigramm / Aufbauorganisation
  - Logisches & Physisches Datenmodell
  - Geschäftsregeln (teilweise)
  - State / Event Mechanismen (teilweise)

### Open Distributed Processing (ODP) - Historisch
Universelles Framework, vollständige Darstellung Anwendung, 5 Viewpoints (Enterprise, Information, Computation, Engineering, Technology), Transitionen zwischen Viewpoints

### Common Object Request Broker Architecture (CORBA) - Historisch
Ur-Standard für Verteilte Systeme, Idee: Infrastruktur für Aufbau transparente (nicht sichtbar auf Ebene Einzelobjekt) verteilte Systeme, Verteilung transparent, jedes Objekt ist lokal (auch wenn es physisch nicht lokal ist), Umleitung durch Infrastruktur, Kernstück: ORB (Object Request Broker), Programmiersprachenunabhängig

  - Corba Facilities: Branchenspezifisch, eigentlich nicht umgesetzt
  - Corba Services: umgesetzt (äquivalente in WebServices zu finden)
    - Naming Service: Objekte via Name finden
    - Life Cycle Service
    - Persistence Service
    - Concurrency Control Service
    - Transaction Service
    - Time Service
    - Security Service
    - Licensing Service
    - ...

Eignet sich als Checkliste für Architektur


### Referenzarchitektur (Branchenstandard) - Telecommunications Management Network
Sämtliche beteiligte Komponenten standardisiert (M3100), 90er Jahre, Interoperabilität für Telefonie-Komponenten, Grundelement: Managed Object (4 Charakteristika, Verhalten, Benachrichtigungen, Funktionen, Eigenschaften ), Architektur in Funktionale Bereiche aufgeteilt (Security, Accounting, Fault, Performance-Management)

  - Funktionale Architektur: Operation Systems Function, Network Element Function, WorkStation Function, ...
  - Layering: Business-, Service-, Network, -Element Management Layer, Network Element Layer

Ablauf Verbindung:
  - 0: "Ich bruache eine Leitung", Verbindung zur Zentrale (Schweiz: 2x16)
  - 00: Landesvorwahl, Verbindung nach Internationale Zentrale (Schweiz: 3)
  - 0041: Schliessung Verbindung IZ
  - 0041 44: 2 Redundante Verbindungen zu 2 zentralen in Zürich

  - Zentrale: Netzwerk Element (OSF)
  - CDR: Core Detail Record (Kostentransparenz)


### TOGAF
  - ABB: Architecture Building Blocks
  - SBB: Solution Building Blocks
  - 3 Ebenen
    - 1: Geschäftsarchitektur (Formale Darstellung Geschäftstätigkeit, Prozesse, Organisation, Treiber / Ziele, logische Informationsobjekte)
    - 2: Informationssystemarchitektur (Systeme, Daten)
    - 3: Technologiearchitektur (HW + Verbindung)
