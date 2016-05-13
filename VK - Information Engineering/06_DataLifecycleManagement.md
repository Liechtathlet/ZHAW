# Data Lifecycle Management
## Einleitung
**Data Management:** Wie verwalte ich Daten Gesamtheitlich?
**House of Data:**
  - Governance (Dach des Hauses)
  - Lifecycle
  - DQM: Data Quality Management (Definition & Messung Datenqualität)
  - EA: Enterprise Architecture (Systeme) - Architekt

Security aktuell in EA, dauert noch bis als Querschnittsfunktion

### Definition
Strukturierter Umgang mit Daten über gesamten Lebenszeit hinweg:
  - Im weiteren Sinne: Bereitstellung von Policies, Processes, Practices, Services und Tools zum strukturierten Umgang mit Daten über ihre ganze Lebenszeit hinweg
  - Im engeren Sinne: Storage Management-Konzept, welches Informationsobjekte während der gesamten Lebenszeit aktiv verwaltet.

**Typische Phasen:**
  - Create
  - Transport: 3.5 x mehr Daten transportiert als gespeichert
  - Modify: Nur 10% werden verändert.
  - Use / Store: Ab 30 Tag nach Speicherung: Zugriff auf ca. 20% der Daten
  - Archive: Abhängig von regulatorischen Vorgaben
  - Delete: gezielte und gesteuerte Vernichtung von Daten

Lifecycle-Management: Steuerung / Behandlung der Übergänge, Vorgaben, welche Steuerung beeinflussen / bestimmen

  - Wert der Informationsobjekte
  - Gesetzliche Rahmenbedingungen

Wert der Informationen: Alle gehen von einem Wert aus, aber wie der Wert bestimmt wird, ist nicht definiert / verschieden.

### Grund für DLM
  - Datenzuwachs
  - Kosten für Speicherung
  - Zugriffs-Anforderungen
  - Komplexität
  - Regulatorien

## Wert von Informationen
### Informations-Produktivität
Information Productivity = Information Value-Added (output, Gewinn nach Steuern, vor Wertbereinigungen) / Transaction Costs (input, Kosten für Mgmt, Planung, RW, Marketing, Forschung), These: Unternehmen die am Geschicktesten mit Informationen umgehen, sind auch am profitabelsten (nicht belegt)

### Informationswert als Funktion
Wert der Information = Funktion(Information, Anwendung, Verwendungszweck, Aktionen, Resultat), gemessen wird Quantiät, Qualität und Zeit

**Information hat 4 Werte:**
  - Development Base (Aufwand zur Informationserstellung)
  - Operational Base (Wertbeitrag einer Information zu best. Situation)
  - Market Base (situativer Wiederverkaufswert und Aktualität)
  - Collection Base (Sammelwert)

**Beispiel: Zwischenprüfung Studium:**
  - Development Base: 300 (2 * Stundensatz)
  - Operational Base: 12'000 (Wert Studium: 1.2 Mio bis Pensionierung, 100 Prüfungen)
  - Market Base: < 12'000 (Zeitabhängig)
  - Collection Base: 0

### Informationsklassen
Klassifizierung der Informationen im Unternehmen

### Information und betriebliche Prozesse
Betriebliche Informationsarten können dem generellen Prozessmodell zur Durchführung betrieblicher Abläufe zugeordnet.

### Subjektiver Wert der Information
"Limonandenstand-Versuch"
  - Normative Bewertung: Information hat unabhängig vom Verwendungszweck einen fixen Wert, Bestimmung anhand objektiv messbaren Kriterien, erlaubt Einbezug der Qualität der Information
  - Realistische Bewertung: Bewertung nach Benutzung der Information, hilft nicht bei Entscheidungen
  - Subjektive Bewertung: Bewertung durch Individuum, welches Information beziehen möchte, beeinflusst durch verschiedene Faktoren
    - Reduzierung Ungewissheit
    - Indikatoren
    - Besitztumseffekt

### Information hat gar keinen Pries
**3 Gesetzte der Cyber-Ökonomie:**
    - Der Preis der Information wird gegen Null tendieren.
    - Der Preis der Kommunikation wird gegen Null tendieren.
    - Der Preis der Transaktion wird gegen Null tendieren.

### Der taktische Wert von Informationen
  - Richtigkeit
  - Relevanz
  - Rechtzeitigkeit
  - Brauchbarkeit
  - Vollständigkeit
  - Genauigkeit

### Kosten fehlerhafter Informationen
Gemäss Untersuchung: 1-5% der Daten eines Unternehmens sind fehlerhaft.

  - 1. Kosten
    - 8-12% des Einkommens eines Unternehmens
    - 40-60% der Ausgaben für Dienstleistungs-Unternehmen
  - 2. Andere Einflussfaktoren
    - Langsamere und nicht akkkurate Entscheidungen
    - Schwierigere Strategie-Definition und -Umsetzung
    - Zunehmendes Misstrauen dem Unternehmen gegenüber
    - Ablkenkung der Aufmerksamkeit der Unternehmensführung

## Die Klassierung von Datenbeständen
### Einfache Klassierung von Daten
Anhand der Wichtigeit der Daten für Tätigkeit eines Unternehmens:
  - Critical Data
  - Business Performance
  - Essential Data
  - Sensible Data
  - Non-Critical Data

### Klassierung der Data Protection Initiative
Klar strukturierte Klassierung der SNIA (Storage Networking Industry Association), mit Vorschriften zur Behandlung der Datenklassen
  - Recovery Point objective: Zeitraum zwischen zwei so genannten "Data Protection Events", Maximale Datenmenge, die verloren gehen darf.
  - Recovery Time Objective: Wie viel Zeit darf vergehen bis ein System wiederhergestellt ist
  - Data Protection Window: Zautraum, der verwendet werden darf, um Daten zu sichern während das System nicht online ist.

Kennwerte in Tabelle 7.2 (Script S. 16)

**Daten-Kategorien:**
  - Business Transactions
  - Financial Transactions
  - Customer Service
  - Business Intelligence
  - Manufacturing Operations
  - POS / Order entry
  - Medical Records
  - eMail Records
  - Accounting
  - Legal Records
  -
## DLM-Konzepte
Konzept: Kombination von Technologie und Prozess

### System Managed Storage
Verwaltung von Informationsobjekten (Hardwarenah, Logical Storage Units), nicht Inhaltsbezogen (höchstens abgeleitet), Grossrechner / Host

IBM: System Managed Storage (SMS), 3 Klassen:
  - Data-Class
  - Storage-Class
  - Management-Class

**SMS:**
  - Basic Data Access Services
  - Data Movement Services
  - Availability & Space Management
    - Backup, Dump and Recover
    - Disaster Recovery
  - Policy Management Functions

### Storage Ressource Management (SRM)
Steuerung / Überwachung Speicherressourcen und Datenbestände, NAS / SAN

#### Hierarchical Storage Management
  - (In-Memory)
  - Online
  - Inline
  - Nearline
  - Offline

### ILM des BITKOM
Steuerung durch Lifecycle-Management, Facebook: Leicht angepasstes Konzept für die Speicherung der Bilder (Facebook cold Storage)

**Prozesse:**
  - Erstplatzierung
  - Replikation
  - Datensicherung
  - Archivierung
  - Löschen / Zerstören
  - Verlagerung* (ireversibel)
  - Verdrängung* (Verschiebung in Speicherhierarchie)

### ILM von StorageTek

### Das ILM Framework der SNIA
Nur für grosse Unternehmen geeignet.

## Hints
  - DLM: Arbeitet mit Lebenszyklus (Create - Store - Archive - Del), nicht festgelegt (4-7 Schritte), in jedem Zyklus relevant: Technologie, in jedem Übergang: zeitpunkt wichtig, definiert Regeln für Übergänge zu best. Zeitpunkt
  - Bewertung von Informationen weicht von objektiver Bewertung ab, was ist nachvollziehbar / was ist Quatsch? / Was prefärriert man selbst?
  - Raster kennen (Kap. 7.3), aber nicht auswenndig
  - DLM: Versuch Data-Management als Ganzes auf Unternehmensebene organisieren
  - DLM: Braucht technische Infrastruktur, Bewertung der Daten, Möglichkeit zu messen, Mechanismus für die Überwachung auf Basis von Vorgaben
  - Verlustfall: am konkretesten, hat gewisse Problematiken, klüger über Risiken nachzudenken
