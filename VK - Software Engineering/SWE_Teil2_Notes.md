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
