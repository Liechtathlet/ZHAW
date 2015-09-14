##Systems Engineering
Bemerkung: Big Bigger Biggest (BBC Serie)

###Einleitung
System: systema: zusammengesetztes, Komplex interagierender Elemente, drei Dimensionen: Identität (bleibt auch unter Änderungen stabil, Identität durch Symbole / Traditionen), Organisation (Struktur, Regeln, Gesetzmässigkeiten, def. Beziehungen), Zielgerichtetheit

Nach INCOSE: System Kombination von interagierenden Elementen, welches einem def. Zweck zu erfüllen hat. HW, SW, Firmware, Menschen, Information, Techniken, Einrichtungen, Dienste und andere Hilfsmittel, künstliches / technisches System

Kybernetik: Allgemeine Theorie der Maschinen

Enterprise Architecture Management: TOGAF (nur subset)

Aufgaben Architekt:
Ordnung, Positionierung im richtigen Layer (Welche Logik wohin)

###Hierarchie eines Systeme
Systemhierarchie, Architektur: Neue Anforderunge: wohin gehört diese? Gliederung / Anordnung, Problem: immer mehrere Teilelemente betroffen, Service-Baum im Configuration Management (kennt Mehrfachverknüpfungen, entspricht nicht der Systemhierarchie)

Beispiel: Nicht relevant

###Systemmodel als Basis
Architektur betrifft das ganze, keine Trennung SW / HW


###Flash-Back
- System-Begriff: Bertallan... / INCOSE
- Artikel lesen:
  1.  Abstract lesen
  2.  Zusammenfassung lesen
  3.  Titel lesen, interessante markieren
  4.  Zeichnung anschauen
  5.  Entscheid: Weiterlesen Ja / Jein / Nein
- 2 wesentliche Zeitschriften (1 Jahr Vorsprung)
  - Communications of the ACM (www.acm.org)
  - IEEE Computer


  ###Systemdenken - Systemtypen - Systems Engineering
  Problem in Teilprobleme aufsplitten bis Teilproblem lösbar

  1 Innerer, 3 Äussere Zyklen

  ...

  ####Transparent
  IT: Wenn nicht durchsehbar, für andere: wenn durchsehbar

  ####Komplexität
  Komplexität != kompliziert, kompliziertes Problem: Zerlegung in Teilprobleme, Komplexität: u.U. nicht lösbar, Schranken / Eckpfeiler: System wird an diesen Punkten instabil, Lösung: im stabilen Bereich

  Def. von Webster: Aus Sicht Engineering falsch, damit können wir umgehen


  ###Flash-Back
  - Was ist ein System? (Big Bigger Biggest)
  - Tatsachen rund um Systeme (Ursprünglich für Bau komplexer technischer Systeme, Verschmelzung mit SWE, da System of Systems (Alles vernetzen))
  - Systemdenken (Zerlegung, IT kann alle Probleme lösen, gegeben durch Denke, Unverständnis bei Kunden)
  - Systemtypen
  - Komplexität (vs kompliziert, Reduktion möglich oder nicht?, Komplexität verstecken, Transparenz)


##System der Systeme (System of Systems, SoS)
Heute: Leute mit Req., 1 Technologie, 1 System, 1-n Rechner
Zukunft: Leute mit Req, Viele Systeme, die bereits verbunden sind, Problemstellung: Verknüpfung mit der Systeme mit einem neuen System, N-Technologien, benötigt: ganzheitliches Engineering, Verständnis der Interaktion zwischen den Systemen  

**SoS Prinzipien / Eigenschaften**
  1.  Unabhängigkeit (Dezentrale Verwaltung)
  2.  Evolution (System verändert sich mit Daten, die es verarbeitet)
  3.  Eigendynamik (Systeme: Wasserstände messen, Wetter messen - Hochwasser + Schlechtwetter vorhersage, nur in Kombination sinnvoll - Überwachungsdrohne für Überprüfung, SoS für Koordination / Monitoring)
  4.  Geografische Verteilung

##Systems Engineering Prozesse
Systems Engineering Vorteile gegenüber SWE: IEEE: jedes System hat einen Lifecycle (Lifecycle und Produkt gehören zusammen), Mensch ist Teil des Umsystems | INCOSE: 5 Prozesse: Technical Management, Acquisition & Supply, System Design, Product Realization, Technical Evaluation - Einige Teilprozesse noch nicht etabliert

SEP: Naturgemäss umfangreicher als beim SWE, Standards auch umfangreicher, wesentlicher Standards: IEEE, INCOSE, DAU gibt es nicht (da Mensch teil von System, nicht für System zugelassen)


##Adaptive Systeme
Konzeptionelle Grundidee aus 90er Jahren, Engineering Ansatz

**Konzepte:**
  - Ubiquitous Computing (Allgegenwärtig)
  - Autonomous Computing
  - Semantic Web

###Ubiquitous Computing
Computing erst nützlich, wenn wir es nicht mehr sehen

Kontext: Cyber-Physical-Systems (Smart Devices mit Sensor oder Aktor, Netzwerk), Lokationsmodelle (Location Based, Object Identification, Situation Based)

###Autonomous Computing
Grundlage: Agent, dynamisches System, können kommunizieren

###Semantic Web
Inhalt verstehen, Strukturierung Inhalt via Onthologien (Wissensbäume), Reaktion auf Wissensbäume, hat sich nicht durchgesetzt

###Computational Reflection
Introspection: Selbstbeobachtung, Intercession: Aktionen auf bestimmte Beobachtungen - via Metaobject Protocols
