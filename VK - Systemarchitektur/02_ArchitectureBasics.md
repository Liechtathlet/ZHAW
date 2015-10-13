##Architecture Basics
###Einleitung
**Enterpriseebene:** Prozesse, Organisation
**Architektur:** Enterprise -> Anforderungen an Anwendungen, Abbildung Enterpriseebene auf Anwendungsebene, von aussen schauen für Architekturbild, z.B. Layering  
**Anwendungsebene:** Wie aufbauen? Wo kommt was hin?

####Architektur
Architektur beeinflusst wie sich System und Systemteile verhalten

**Werkzeugkasten:**
  - Prinzipien
    - Basics
  - Standards
    - Theorie
    - Industrie
  - Know-How
  - Realität
    - \#User
    - \#Transaktionen
    - \#Branche (Line of Business)
    - \#Grösse der Firma

**Cross-Cutting-Concerns:** Anforderungen an allgemeines Verhalten  

Triage der Anforderungen (Relevant für Architektur oder nicht), Mengengerüst wichtig

##2.2 Architektur und Systemeigenschaften

###Messbare Eigenschaften
**Zur Laufzeit messbare Eigenschaften:**
  - **Performance (Garantierte Antwortzeiten):** ~0.7s (von User tollerabel), Vermeidung garantien Antwortzeiten zu Beginn (schwierig zu messen, nicht beeinflussbare Faktoren), TCP / IP: Best Effort, zentrale Systeme: einfachere Verbesserung Performance, Verteilte Systeme: Schwierig
  - **Security (unautorisierter Zugriff, mutwilige Zerstörung):** User Management (keine lokale User-Verwaltungen!), Rollen-basierte Sicherheitskonzepte, Lokalitätsabhängig, Regulatorische Anforderungen hinsichtlich Daten
  - **Availability (Verfügbarkeit):** 3 Parameter: Uptime (% der Gesamtzeit oder Arbeitszeit), nicht redundante Systeme: ~96%, > 96%: Redundante Systeme, Time-to-Recovery-Objective, Recovery-Point-Objective (Wie viele Daten dürfen max. verloren gehen)
  - **Usability (Verwendbarkeit): ** Zweideutig: Ergonomie oder Verwendung für vorgesehenen Zweck
  - **Robustness (Stabilität):** Schwierig, mehrere Umgebungen, bei Einführung: Probleme wegen anderen Datenmengen, Betrieb: Schwierig zu managende Fehler, keine Reproduzierbarkeit auf Testumgebung, Cloud: vermehrte Auslagerung, Self-Recovery  


**Zur Laufzeit nicht messbare Eigenschaften:**
  - **Scalability:** 90% der Fälle: Irrelevant, da für gewisse Anzahl User / Transaktionen konzipiert, z.T. sehr teuer in der Umsetzung (Lizenzen, Softwareentwicklung, etc.), Verlagerung in die Infrastruktur
  - **Integrability:** Was passt zusammen? Technologie- / Plattformentscheide, Integrationsschicht: Austausch von Daten zwischen Anwendungen
  - **Portability:** Verliert an Relevanz, BU-Kritisch (Produktentwicklung / High-End-Bereich), o.ä. von Entwicklerteam Portabilität verlangen -> bessere Qualität
  - **Maintainability:** DevOps, keine Dinge einbauen, die es nicht braucht / nicht zum kern gehören
  - **Testability:** Sinnvolle Logs und Traces einbauen, Änderung Modus ohne Neustart, Defensive Programming (Parameter-Range-Prüfung, One-Exit-Point)
  - **Reusability:** analog Portability, jede Komponente wird im Scnitt 1.3 x verwendet, nützlich für Qualität

Jede Architekturentscheidung hat Einfluss auf eine der Eigenschaften

###Definition
1 Zeichnung reicht nicht für alles (bei Gebäuden funktioniert das), mindestens 3 Darstellungen: Komponenten, Datenflüsse, Prozesse, , Hierarchisch: Unterstrukturen --> Konstruktionselemente

###Formale Definition

  - Architecture
    - Elements
      - Processing Elements (Führend Transformationen auf Data Elements aus)
      - Data Elements (Daten)
      - Connecting Elements (Entweder P.E. oder D. E., z.B. Procedure Calles, Shared Data, Messages)
    - Formale
      - Weighted Properties (Gewichtung Eigenschaften Element, Unterscheidung zentral / dekorativ, Mittel zur Definition Rahmenbedingungen, minimale Anforderungen)
      - Relationships (Definition Platzierung Element in best. Kontext von Elementen)
    - Rationale (Motivation zur Auswahl best. Architektur-Elemente, Ausdruck Abbildung Systemanforderungen, funktional nach allgemeine Systemanforderungen.)
###Zusammenfassung
  - Werkzeugkasten der Architektur
  - Architektur hat Ordnungsfunktion, beeinflusst Art und Weise wie eine Anwendung oder Systemlandschaft geordnet wird (mit Werkzeugkasten)
  - Architektur hat direkten Einfluss auf allgemeine Systemeigenschaften
  - Messbare / Nicht-Messbare Eigenschaften

##2.4 Architektur und Moduleigenschaften
Gute Architektur in konkretem SW-Design sichtbar, baasiert auf Reihe klar definierter Prinzipien. Prinzipien beziehen sich auf einzelne Module oder Verhältnis der Module zueinander

###Architekturbild
Webseite: Logik: z.B. nach Bereichen, oder nach Use Cases, Cross-Cutting-Concerns auf Schichten aufteilen (1 Schicht -> 1 CCC)

1. In Schichten einteilen
2. Ordnungskriterium auswählen (Use Cases, etc.)

###Moduleigenschaften
  - **Modularity:** Eigenständige, in sich geschlossene Komponente, Arbeitsteilung, je grösser System, desto wichtiger, Typisch: User-Mgmt, Rule-Engine, SW ist Modular: wenn vernünftig sortierbar
  - **Portability:** Auch in anderen Umgebungen lauffähig, Organisation Gesamtarchitektur
  - **Changeability:** System verändert sich während Lebenszeit (Umfeld, UI, ...),Wie weit kann System verändert werden?
  - **Conceptual Integrity:** Was zusammen gehört, muss zusammen wachsen, ähnliche Gestaltung ähnlicher Funktionalitäten, Referenzimplementationen, zentral
  - **Intellectual Control:** Verständnis / Unterstützung durch Beteiligte, zentral
  - **Buildability:** geht aus Conceptual Integrity und Intellectual Control hervor, System muss so spezifiziert werden, dass es von gegebenen Team in gegebener Zeit realisiert werden kann, zentral
  - **Coupling and Cohesion:** Gemäss Programmierunterricht, Idealform: Lose Koppelung, je nach Situation: sinnvoll Koppelung aufheben (Performance)
    - Data Coupling
    - Stamp Coupling (Austausch Datenstrukturen)
    - Control Coupling (Austausch steuert Kontrollfluss)
    - Content Coupling (verändert Daten von anderem Modul)
    - Coincidental Cohesion (Gruppierung durch Zufall)
    - Logical Cohesion (Fkt. in Modul zusammengefasst, bezieht sich aber nich aufeinander)
    - Temporal Cohesion (Zeitpunkt Verwendung bestimmt Gruppierung)
    - Procedural Cohesion (Aufrufreihenfolge bestimmt Gruppierung)
    - Communications Cohesion (Gruppierung durch gemeinsamen I/O)
    - Sequential Cohesion (Abfolge Datenbearbeitung best. Gruppierung)
    - Functional Cohesion (Gruppierung hat Ziel dass Modul Logik und Daten lokal halten - Information Hiding)
    - Erreicht mit Independece of Design, Small Interfaces, Low Interface Traffic, Unity, Encapsulation

###Übergreifende Themen
  - **Design for Change:** Robust gegenüber Veränderungen, verschiedene Änderungsklassen:
    - Domain Specific Changes: Fachliche Änderungen, z.B. SAP
    - Analytical Changes: Nachbesserungen
    - Downsizing Changes: Reduktion gewisser Funktionalitäten, bei Agile: bereits eingebaut

##2.5 Schwierigkeiten SW-Design:
    - Complexity
    - Conformity: Kein stabiler Untergrund
    - Changeability: SW kann immer verändert werden
    - Invisibility: keine visualisierung, keine geometrische Repräsentation

##2.6 Vorteile / Ziele einer Architektur
  - SWA Grundlage für Kommunikation: Verständnis, Detail-Fragen
  - SWA treibende Kraft des System-Designs
  - SW Rahmen für Wiederverwendung SW-Artefakte
  - Träger von Qualitätscharakteristika (messbare allgemeine Systemeigenschaften) und nichtfunktionaler Eigenschaften
  - Invariante über mehrere SW-P, Vereinfachung Entwicklungsprozess
  - Analyse bestimmter Systemeigenschaften
