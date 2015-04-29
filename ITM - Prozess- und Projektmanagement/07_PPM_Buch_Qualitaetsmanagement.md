#Quaitätsmanagement
**Qualität:** IEEE-Standard: The degree to which a system, component or process meets customer or user needs or expectations, Qualität ist, wenn der Kunde und nicht das Produkt zurückkommt

**Prozessqualität vs. Produktqualität:** Hohe Prozessqualität begünstigt hohe Produktqualität

**Konfliktdreieck:** Termin-Kosten-Qualität

**Qualitätskosten: ** Kosten Conformance (Kosten Hineinkostruieren Qualität), Kosten Nonconformance (Kosten, welche durch Fehlerbehebung entstehen) - Schwerpunkt sollte auf Conformance liegen, Qualität kann später nicht hineingeprüft werden, Qualität durch bessere Techniken, Tools, Prozesse und Überprüfungen mit Korrektur

**Qualitätsmanagement: ** beschäftigt sich mit: wie Kundenzufriedenheit erreichen, wie Prozesse & Aktivitäten optimal planen / durchführen, wie kontinuierliche Verbesserungen gestalten, welche Ressourcen für QS-Massnahmen notwendig sind, wie mit Veränderungsprozess im UN umgehen

QS neben Qualitätsplanung und der Prozessverbesserung ein Teilaspekt des QM, formale QS: via Reifegradmodelle, sollte durch externe Q-Org wahrgenommen werden, QS darf nicht von P.Leitung oder Führung überstimmt werden können.

**QS-Verantwortlichkeiten:** Durchführung formale QS, Gewährleistung Kontinuität, Zurodnung QS-Verantwortlicher pro Projekt, PL herausragende Rolle, Zwei Rollen: unabhängige, prüfende Rolle und unterstützende / beratende Rolle (Unterstützung PL: Auswahl P.-Standards, Projekt- / SW-QS-Planung, Durchführung QS-Massnahmen), Aufgaben: Prüfung Einhaltung Vorgaben und Kunden-Req für Arbeitsprodukte und Prozesse (Audits, Reviews), Verfolgung Mangelbeseitigung, Berichtswesen Mgmt, Prüfung Unterauftragnehmern


##Qualitätssichernde Massnahmen
Kategorisierung: konstruktive, analytische, organisatorische Massnahmen

**Konstruktive Massnahmen:** konstruieren Qualität, z.B. linker Ast V-Modell, Techniken Req-Analyse, SW-Design, UML, SDL, Simulationstechniken, Prototyping

**Analytische Massnahmen:** Analyse Ergebnis, Reviewtechniken, Metriken, statische Codeanalyse, dyn. Testverfahren

**Organisatorische Massnahmen:** Unterstützung Abwicklung Projekt

###Statische Verfahren
####Reviews
fester Platz SWE, oft einziges / einfaches / kostengünstigestes Mittel, Dokumente analysiert / bewertet

**Reviewarten:** Schreibtischtest (Prüfer Dokument von Autor, liest kritisch durch, Retour mit Anmerkungen, Aufwand: niedrig), Walktrough (Autor erläutert Dok mit mehreren Prüfern, gemeinsame Sitzung, Aufwand: mittel), Inspektion (Review nach formalisiertem Prozess, Kick-Off, Prüfung, Abschlussitzung, Festhaltung Befunde, Abarbeitung, Aufwand: mittel - hoch), Inspektion inkl. Diskussion VV (Anschluss Inspektion: Diskussion Verbesserungsvorschläge, Aufwand: hoch)

Review-Punkte: Einhaltung Vorgaben (Standards / Richtlinien), Sicherstellung Umsetzung spez. Req, Formale / inhaltliche Überprüfung korrekte Durchführung Änderungen

**Aktivitäten:** Planung, Einführung, Vorbereitung, Reviewsitzung, Überarbeitung, Verbesserung, Nachverfolgung

**Rollen:** Autor, Prüfer, Protokollführer, Inspektionsleiter

**Tipps Umsetzung:** Mehrere Prüfer - mehrere Sichten, Abnahme Effektivität bei intensiver Prüfung nach zwei Stunden, aufteilung in mehrere Teile, Stichprobenbildung (Teile Dokument), Abbruch wenn Reviewsitzung unenügend vorbereitet, Review / Inspektion mit Diskussion: frühe Phasen, Haltung Autor: egoless, Prüfer: Dokument, nicht um Person (Kritik sachlich konstruktiv), Einfrierung Version Prüfling, Ergebnisoffene Gestaltung Reviews, Klassifizierung Fehler (nicht in jedem Fall komplettes Re-Review notwendig)

####Metriken
effektives, wirksames Werkzeug Steuerung Projekte, kontinuierlicher Prozess, Messdaten für def Prozesse oder Arbeitsprodukte definiert, gesammelt, analysiert, bewertet - Ziel: verstehen, kontrollieren, steuern, optimieren - Aufwand / Kosten reduzieren, Produkt verbessern, unterstützt effektives PM, Zielorientierte Messung, Reflektion Geschäftsziele Org., zentrales Prinzip der Goal/question/Metric-Methode (GQM) - Messziele auf Basis Geschäftsziele :arrow_right: Konkretisierung mittels Fragen :arrow_right: Ableitung Messwerte, Beantwortung Fragen: Messwerte operationalisiert, Bewertung

Sammlung, Interpretation Messdaten, Via Messergebnisse Fragen beantworten und Zielerreichung messen

###Dynamische Verfahren
####Testphasen
Gliederung Test in Phasen
  * Modul- / Komponententest
    kleinste selbstständig übersetzbare SW-Einheit oder einzelne Funktion/Prozedur/Klasse, relativ leicht Konstruktion Testfälle, Prüfung ob Modul Spez erfüllt.
  * Integrationstest
    Zusammenfügen einzelne Module/Komponenten, Untersuchung Subsystem, Module bereits getestet, Fokus auf SST zwischen Modulen, Integrationstest gegen Architekturspez. durchführen.
  * Systemtest
    Untersuchung Fkt Gesamtsystem, spezifzierte Testfälle, Anhand Spez   / Entwurfsdokumente (z.B. Sequenzdiagramme)
  * Abnahmetest
    Zusammen mit Auftraggeber, Validation System,
  * Regressionstest
    beliebig wiederholbarer Test, Wiederholung frühere Tests

####Blackbox-Tests
typischerweise in allen Testphasen, Objekt als Blackbox, nicht an internem Verhalten interessiert, Eingabe / Ausgabe, All Kombinationen zu teste: unmöglich, Selektion geeigneter Testfälle

**Strategien:**
  * Äquivalenzklassenbildung
    Zusammenfassung Eingabewerte mit identischem Verhalten, Ergebnis unterscheidet sich, nicht aber Verahren der Verarbeitung, pro ÄK mind. 1 Testfall
  * Grenzwertanalyse für Eingabe- und Ausgabewerte
    Grenzbereich Parameter-Fehler, Auswahl aus Rändern, spezielle Äquivalenzklassenbildung (bsp: Eingabe 0 - 100 erlaubt, Prüfung 0, 100, und -1, 101)
  * Test spezieller Werte
    Kritische Testfälle, Auswahl aufgrund Erfahrung / Kenntnis Aufgabenstellung, kein reiner Blackbox-Test mehr
  * Zufallstest

####Whitebox-Tests
Internes Verhalten im fokus, Betrachtung SST + Algorithmus, nur in Testphase Modultest, Kontrollstruktur verwendet, um Ziele zu definieren

  * Anweisungsüberdeckung (C0-Test)
    Alle Anweisungen (alle KNoten Kontrollflussgraph) müssen durchlaufen werten, gleichmässige Bewertng jeder Anweisung, geringe Fehleridentifizierungsquote im Vergleich zu anderen kontrollflussorientierten Testverfahren, notwendiges, nicht hinreichendes Testkriterium
  * Zweigüberdeckung (C1-Test)
    Verschärfend Ausführung aller Zweige gefordert
  * Pfadüberdeckung (C2-Test)
    Programme mit Wiederholungen / Schleifen ausreichend testen, Ausführung aller unterschiedlicher Pfade gefordert, mächtigstes kontrollstrukturorientiertes Verfahren, Verfahren nicht immer ohne weitere Einschränkungen praktikabel (Schelifen)

  * Datenflussorientierte Verfahren
    Tests auf Basis Wertzuweisungen, Variablenzugriffe
  * Zustandsautomatenorientierte Verfahren
    Testfälle Basis Zustandswechsel, Benutzung Strukturelemente Zustände, Transitionen, Zustandsüberdeckung: typischerweise: jeder Zustand einmal durchlaufen, Transitionsüberdeckung: jede Transition einmal durchlaufen

##Planung Qualitätssicherung
fehlende Q-Planung: Q-Kriterien nicht identifiziert, QS-Massnahmen nicht durchgeführt, ausgelassene P.-Schritte, lange Zeitdauer bis Probleme entdeckt / gelöst

Aktivitäten / Prinzipien Projektplanung auf Q-Planung übertragen:
  * Projektumfang
    aus Sicht Q-Planer, Q-Ziele, Q-Req, Vorgaben ermitteln
  * Ableitung Aktivitäten um Q-Req zu erfüllen
  * Ressourcen, Verantwortlichkeiten für Durchführung

Typsicherweise formale Reviews (für Abschlusskriterien Milestones) aktiv eingeplant, Testphasen bereits früh planen, ergebnisse Q-Planung in SWQS-Plan

**Beispiel Planung:**
  0.  Geltungsbereich
  1.  Zuständigkeit und Befugnisse QS-Personal
  2.  Benötigte Ressourcen
  3.  Budgetierng der QS-Aktivitäte
  4.  Qualitätssichernde Massnahmen und Zeitplan
  5.  Bei den Prüfungen zu grunde liegende Normen und Verfahren
  6.  Verfahren Behandlung Abweichungen (Eskalation zum Mgmt)
  7.  Zu erstellende Doku
  8.  Art und Weise Feedback Projektteam

##Prozzessverbesserung
Motivation aus Mischung folgender Faktoren: Q-Verbesserungen, Kostensnekungen, Produktivitätssteigerungen, Verkürzung Entwicklungszeiten, Bessere Schätzungen, Äussere Zwänge, Beherrschung Komplexität, Technische Probleme mit Produkten, Erfüllung gesetzlicher Anforderungen

###Vorgehen
z.B. Spice, Schritte
  1. Geschäftsziele Org berücksichtigen
     Bereitstellung finanzielle Mittel durch Mgmt, Gewinnung Mgmt
  2. Verbesserungszyklus initiieren
     Benötigt: Sponsoren, PPM, Budget, Meilensteine, Verantworltichkeiten, etc.
  3. Gegenwärtige Leistungsfähigkeit bewerten
  4. Aktionsplan entwickeln
     Schwächen, Misststände, Auswirkungen, Umsetzung einfache Verbesserungen mit grosser Wirkung, Darstellung Prozesse für ordentlcihe Projektdurchführung, Verbesserungsmöglichkeiten mit Wirkung auf allen anderen Prozesse

Meist sehr viele Verbesserungsmöglichkeiten, Priorisierung, pro Verbesserung: konkrete, messbare Ziele aufstellen,
  * Ziele Fehlerreduzierung (kurzfristige Q-Verbesserung Produkte)
  * quantitative Prozessziele (messbare Verbesserung Parameter, Voraussetzung: Vergangenheitsdaten)
  * Reifegradziele

Schritte 1-4 nicht streng sequentiell, miest initialer IMpuls, Assessment, konkrete Planung, Start Erneut bei 1 und 2

  5. Verbesserungen umsetzen
     Gemäss pPan umsetzen, Erfolgsfaktoren: klares / verbindlcihes commitment Mgmt, Aktive Mitarbeit mgmt an Verbesserungsprjekt, Beauftragung beste MA, als Projekt durchführen, Definition messbare Erfolgskriterien / Verfolgung, Bewusststein Investition, Ziel: tatsächliche Verbesserung (nicht höhrerer Reifegrad)
     4 Phasen:
      1. Prozessdefinition
      2. Pilotierung
      3. Transitioning
      4. Rolout
     nicht streng sequentiell, Überlappungen, Erfolgskontrollen: Assessments, Konformitätsprüfungen (interne Audits)
   6. Verbesserungen bestätigen
      Überprüfung Erreichung geplante Ziele, Konformitätsprüfung, kleinere Org (< 100 Entwickler, 1 Asessment), grössere Org (> 1000, rollout über Jahre / Monate, intelligente Strichprobenstrategie)
   7. Verbesserungen aufrechterhalten
      natürliche Erosion Verbesserungen, Druck Tagesgeschäft, Konformitätsprüfung als dauerende Einrichtung, Balanced Scorecards, städnige Weiterentwicklung
   8. Prozesse Überwachung

###Aufwand / Dauer Verbesserungszyklus
Reifegradmodelle: ca. 2 Jahre, geringere Streuung nach unten, grössere nach oben, Übergang nachhaltige Kulutränderungen, Nachhaltige Veränderungen viel Mühe, Zeit und Geld, Kosten: ca. 5-10% Entwicklungsbudgets: internes Personal (PL, Process Owner, Trainer, coaches, Unterstützung Verbesserung), Exeterne Berater
