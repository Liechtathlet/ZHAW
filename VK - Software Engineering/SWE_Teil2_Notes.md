#Change- und Configuration Management
Durchschnittliches Informationssystem: Lebensdauer 12-15 Jahre  
Durschnittliche DB: 20-30 Jahre  
Durchschnittliche Bauzeit, Durchschnittlicher SW: Früher: 42 Monate, Aktuell: ca. 27 Monate  
Informationsmittel: Betriebsmittel, Unterstützende Instrumente

##Change Management als Prozess
RUN-Phase: Im Griff mit Prozessen, Decommit-Phase: Schwierig, Halsbrecherisch, Change / Veränderung: Planung, jemand muss verantwortlich sein, Einführung neuer Arbeitsweisen / Abläufe via IT, Rollout: Braucht Freunde ("Superuser")

**Veränderung**: Über Zielsetzungen: Transformationsziele, Reduktionsziele (Zwischenlösung), Applikationsziele (Theorie)

**Genereller Ablauf Veränderungen:**
  - Zielformulierung
  - Verantwortung definieren
  - Zeitraum
  - Change Control Board (in Industrie: z.T. zu umfangreich)

**Prüfung: Phasen:** Create / Build / RUN / Decommit, Problem Rollout

##Software Maintenance
Standard: IEEE 1219, Kosten: 90 %, 4 Change-Arten: Adaptive, Perfective, Corrective, Preventive  
Projekt: Preis wird gedrückt, nach Abnahme: CR-Zeit (Verrechnung)  
Vermeidung Hohe Kosten, Software nicht fehlerfrei / nicht perfekt, Akzeptable Unterhaltskosten, Effekte: Lineare Attraktoren (Systemzustände mit magnetischen Wirkungen, n+1 Änderung --> das Ganze kippt unaufhaltbar, Explosion Maintenance-Kosten), Pflege von KnownErros (Billigste Art von Fehlerbehebung)

CAPEX: Capital Expenses (Investitionen für Plan, build)  
OPEX: Operational Expenses (Run)  

Maintenance: Nicht mehr alle Wünsche erfüllen, wenn dann eher via Change Request, Diskussionen: Fehler oder CR  
Ziel Entwickler: Möglichst geringe Unterhaltskosten, Konflikt: Perfektionismus / Pragmatismus


##ITIL
Idee: Betriebsmittel als Service
Ziel ITIL (Gegensatz SWE): Es soll so bleiben, Continual Service Improvement: Bringt nichts, wird in der Praxis nicht verwendet.  
Service-Bäume: Logischer Aufbau, nicht hierarchisch, Wo ist die Vertragsschnittstelle
Ticketing-, Knowledge-, Monitoring-, ITIL-System: REMEDY, Tivoly, HPOV  

Relevante ITIL-Prozesse im Betrieb:
  - Wichtig:
    - Incident-Mgmt
    - Problem-Mgmt
    - Change-Mgmt
    - Configuration-Mgmt
    - Release Mgmt
  - Weniger Wichtig:
    - Service-Mgmt
    - Availability-Mgmt
    - Contingency-Mgmt
    - Capacity-Mgmt
    - Continuity-Mgmt
    - Financial-Mgmt

###Beispiel
Es soll so bleiben wie es ist: Etwas ist anders --> Callcenter / Helpdesk --> Trouble Ticket, Max. zur Behebung: Keine Änderung an Konfiguration - geöffnete und geschlossene Incidents- / Trouble-Tickets, Keine Standardisierte Benennung Second- / Third-Level

Reproduzierbare Fehler:  
Nicht-Reproduzierbare Fehler: Aus Betriebssicht keine Fehler, nicht bearbeitbar  
Configuration-Manager ~= Product Manager (Zuständige Person, nicht aus SCRUM)  
3 Eskalationsstufen: 1. Vorfall - Keine sofortige Behebung: 2. Incident (Behebung ohne Systemveränderung, ohne Lösung): Problem (Fachleute, z.B. Reboot, Indexierung, Clean) - 3. Change (Wenn Problem nicht behebbar) | Systemzustand darüber messbar, Anzahl Incidents: egal, Anzahl Probleme: interessant --> Viele Probleme / Wenig Changes --> Plattform etwas schief



#Kosten der Informationstechnologie
##Allgemeines und Ausgaben für die IT
Entwicklungs-Kosten, Betriebs-Kosten (ca. 20% der Entwicklungskosten pro Jahr), Betriebsnutzen, Entwicklungsnutzen (selten kalkuliert, Nutzeneffekte durch Engineering, z.B. Prozessmodellierung), IT heute nur als Kosten in der Buchhaltung (werden heute nicht korrekt verrechnet), Strukturkapital: Strukturen (Businessregeln, etc.), IT: Wachstumsbranche, starker Einfluss auf technologisch orientierte Wirtschaftssektoren, Wertschöpfung: Hälfte durch interne IT, Hälfte durch externe IT, Ausgaben IT: Durchschnitt über alles: 4% des Umsatzes, Dual-Vendor-Strategie (Speziell Schweiz), 20'000 IT-Unternehmen (ca. 1 -4 Angestellte)

##Kennzahlen für die IT
Wie bewertet jemand, der nicht versteht was die IT tut?

  - Kalkulatorische Bewertung (Vor Projekt, Projektantrag)  
    Rechtfertigung durch Investitionsrechnung (Net Present Value oder vereinfacht: Return On Investment)
  - Kalkulatorische Bewertung nach Projekt: unüblich
  - Total Cost of Ownership  
    Kosten von Erstinstandsetzung bis Abschaltung, Zusammensetzung aus direkten (HW, SW, Operations, Verwaltung) und indirekten Kosten (End-User Operations, Downtime)
  - Opportunitätskosten  
    Wird selten benutzt


##IT-Controlling
Wie gut ist eine IT?, Woher kommen die Zahlen für das Controlling? (Siehe Beilage)

#Pricing & Estimation
##Einleitung
  - Time & Material (Nach Aufwand über Zeit)
    - Pure T&M
    - T&M wire price Limit (Kostendach), sollte nicht gemacht werden, nicht fair, unternehmerisch nicht fair
    - T&M with quantity discount
  - Fix-Pricing ("Werkvertrag")
    - Pure Fix-Price
    - Conditional Fix-Price (z.B. Höherer Preis vor best. Datum, Niedrigerer Preis nach best. Datum)
  - Value Driven Pricing (Preis durch Wertbeitrag festgelegt, z.B. Entwicklung für Start-Up: Kein Preis, Preis auf Verwendungsbasis)
    - Value Driven Price on client saving / earnings
    - Value Driven Price on number of pieces
  - Risk Based Pricing (Preismodell von IBM für Cloud-Services unter Berücksichtigung Risiken)

###Preisgestaltung
Marktwirtschaftliche Preisgestaltung (S. 6): Nicht 1:1 in IT, Stundenansatz (~125.-/h in CH), Erwartete Nachfragemenge (Nicht relevant), Analyse des Marktpreises (Schwierig, Ansatzpunkt Stundensatz), Vergleich Mindestpreis-Marktpreis (Marge, wie viel können wir nachgeben? Marge: ~5-15%)
Reuse-Faktor von Projekten sehr gering / unwahrscheinliche, Selbstständiger: Ein Drittel der Einnahme sofort weg (Preis: 127.- + 1/3), Preisberechnung für Systeme mit Umsystemen schwierig

###Lizenzen
Buch "Das 1x1 des Lizenzmanagements", ca. 1/2 aller Firmen falsch lizenziert (über- / unterlizenziert)

##Offertprozesse
Angebote sind im Prinzip Chef-Sache (auf Seite Anbieter), Vereinheitlichung Angebotsprozess schwierig

###Öffentliche Vergabeverfahren
Öffentliche Hand: guter Kunde (Ausnahme: Spanischer Staat), Liefer- oder Dienstleistungsauftrag, www.simap.ch (Öffentliche Ausschreibungen), Leistungsbezüger (LB): Auftraggeber, Leistungserbringer (LE): Auftragnahmer, Grenze für öffentliche Ausschreibung: 0.5 Mio. CHF (von WTO festgelegt)

  - Offenes Verfahren [S. 12]  
    Angebot ausarbeiten und einreichen: Üblich Fragerunde bei Ausschreibung, alle Fragen und Antowrten aller potenziellen LE werden an alle versendet
  - Selektives Verfahren [S. 13]  
    Zahl der Anbieter aufgrund von Anforderungskriterien einschränken.
  - Einladungs-Verfahren  [S. 14]  
  - Freihändiges Verfahren [S. 14]  
    Anbieter wird ausgewählt, eher in der Industrie

Heute: Kontingente für offene Verfahren, z.B. Reservation von bestimmter Anzahl Tage in den nächsten x Jahren, Auswahl mit freihändigem Verfahren bei konkretem Bedarf, Dienstleistungslose

##Verfahren zur Aufwandschätzung
Algorithmische Verfahren: Verlassen Hochschule nie, keine Verwendung in Praxis, Schützung: Durchschnittliches Projekt (40% Codierung, 20% Projektleitung, 20% Testing, 20% Admin), Puffer auf Basis Risikoeinschätzung: 10-20%, werden oft in Preisverhandlungen wieder weggegeben, Serios wenn Risikoaufschlag ausgewiesen, Höherer Preis durch mehr Testing / bessere Qualität: In Praxis funktioniert das nicht

  - Algorithmic (Nicht angewendet)
    - COCOMO: Constructive Cost Model, Produktgrösse als Basis für den Aufwand in Personenmonaten und Laufzeit verwendet
    - COCOMO Intermediate: Erfahrungsfaktor
    - COCOMO II
    - SEER
    - PRICE
    - CoBRA
    - KnowledgePLAN
  - Productivity (sehr selten angewendet)
    - Sizing Based Model: (z.B. nach Function Points, nicht geeignet, schwer nachvollziehbar)
    - Function Based Model
    - Object Based Model
  - Subjective
    - Experts View (Einzel- / Mehrfachbefragung, Delphi-Methode, Schätzklausur)  
      Delphi: Ab gewissem Projektvolumen (5-10 Mio.)
    - Expirience Based
  - Others
    - Parkinson  
      Klassische Berechnung + Kontrolle durch Berechnung Benötigte / Verfügbare Personen über Projektlaufzeit und Stellenprozent
    - Price to Win
      Unternehmen will gewinnen, auf dieser Basis wird der Preis festgelegt

Wichtigste Schätzmethode: Expertenschätzung (mehr Experten != bessere Qualität), Prüfen mit Parkinson, Nachvollziehbarer Preis, Budgetierung gemeinsam mit Kunde

Wichtig (Prüfung): Arten Preisgestaltung (Time & Material, Fixed Price, Value Driven), Was ist fair aus Sicht Betreibswirtschaft, Prozesse Auswahl öffentliche Hand, Wieso Subjektive Schätzmethode die wichtigste? Erklären Parkinson / Price to Win, Wie würden Sie zählen? (irgendeine Antwort, einfachste Antwort: So das es jemand versteht --> nachvollziehbar)

#Mündliche Prüfung
3 Fragen, Hinweise aus dem Unterricht
