#Grundlagen des Softwaretestens

##Begriffe und Motivation
SW immaterielle, nicht einfach prüfbar / testbar, Testen: Verringerung Risiken beim Einsatz

###Fehlerbegriff
  * Fehler: Nichterfüllung festgelegter Anforderung, Abweichung Ist / soll
  * Mangel: festgelegte Anforderung / berechtigte Erwartung nicht angemessen erfüllt
  * Fehlerwirkung / failure / Fehlfunktion / Ausfall: Beschreibung Sachverhalt  
    Theoretisch auch durch Umfeld (Magnetismus, Strahlung, ...)
  * Fehlerzustand / fault: Fehlerwirkung hat Ursprung in Fehlerzustand der SW :arrow_right: auch als Defect / Bug bezeichnet  
    Fehlerzustand muss nicht immer (am gleichen Ort) zu einer Fehlerwirkung führen
  * Fehlermaskierung
  * Fehlhandling / error: Einem Fehlzustand / Defect vorausgegangen, Fehlhandlung einer Person (z.B. fehlerhafte Programmierung)

###Testbegriff
  * Debugging / Fehlerbereinigung / Fehlerkorrektur: Lokalisierung Fehler anhand Fehlerwirkung durch SW-Entwickler, Verbesserung Qualität, z.T. auch neue Fehlerzustände :arrow_right: Erneutes Testen
  * Test: Fehlerwirkungen gezielt und systematisch aufdecken, jede Ausführung eines Testobjektes, die der Überprüfung dieses Testobjektes dient, Vergleich Soll- / Ist  
    Ziele: Ausführung Programm mit Ziel: Fehlerwirkung nachzuweisen, Qualität zu bestimmen, Vertrauen in Programm zu erhöen, Analysieren Programm / Dokumente um Fehlerwirkungen vorzubeugen, statische Analysemethoden werden häufig auch zum Test gezählt
  * Testprozess: Ausführen Testobjekt mit Testdaten, Planung, Durchführung, Auswertung Tests (Testmanagement)
  * Testlauf: Umfasst Ausführung eines / mehrerer Testfälle, festgelegte Randbedingungen, Voraussetzungen zur Ausführung, Eingabewerte, vorausgesagte Ausgaben / Verhalten
  * Testszenarien: Aneinanderreihung Testfälle
  * Fehlerfreiheit: Durch Testen nicht erreichbar (ausser bei sehr kleinen Programmen)
  * Kategorien Test-Benennung
    * Testziel: Nach Zweck, z.B. Lasttest
    * Testmethode: Nach Methode welche zur Testspezifikation / -Durchführung eingesetzt wird, z.B. geschäftsprozessbasierter Test
    * Testobjekt: Nach Art des Testobjektes, z.B. GUI-Test
    * Teststufe: Nach Teststufe, z.B. Systemtest
    * Testperson: Nach Personenkreis, z.B. Entwiklertest
    * Testumfang: Nach Umfang, z.B. Regressionstest, Volltest

###Softwarequalität
Testen dient Steigerung SW-Qualität, nachgewiesene Qualität entspricht dann erwartete Qualität, SWQ umfasst mehr, ISO 9126: Qualitätsmerkmale: Funktionalität, Zuverlässigkeit, Benutzbarkeit, Effizienz, Änderbarkeit, Übertragbarkeit - Prüfung durch geeignete Tests, ISO 25012: Ablösung, 3 Modelle: quality in use model, product quality model, data quality model

  * Funktionalität  
    Fähigkeiten miest durch Ein-/Ausgabeverhalten oder Reaktion / Wirkung in System beschrieben, Teilmerkmale: Angemessenheit, Richtigkeit, Interoperabilität, Ordnungsmässigkeit, Sicherheit
  * Zuverlässigkeit  
    Sys Leistungsniveau unter festegelegten Bedingungen über def. Zeitraum wahren, Unterteilung in Reife (Wie häufig Versagen SW durch Fehlerzustände), Fehlertoleranz, Wiederherstellbarkeit, Fehlertoleranz: (automatische) Wiederaufnahme, Robustheit
  * Benutzbarkeit  
    Teilaspekte: Verständlichkeit, Erlernbarkeit, Bedienbarkeit, Einhaltung Standards, Konventionen, Style Guides, Überprüfung beim nicht funktionalen Test
  * Effizienz  
    Messbare Ergebnisse, Zeit / Verbrauch Betriebsmittel für Erfüllung Aufgabe
  * Änderbarkeit & Übertragbarkeit
    Änderbarkeit: Analysierbarkeit, Modifizierbarkeit, Stabilität, Prüfbarkeit - Übertragbarkeit: Anpassbarkeit, Installierbarkeit, Konformität, Austauschbarkeit

Priorisierung Merkmale notwendig

###Testaufwand
Vollständiger Test praktisch nicht durchführbar, Verallgemeinerung Aufwand nicht möglich, stark vom Projekt abhängig, Fehler können hohe Kosten verursachen, Testaufwand hoch im Vergleich zu was?, Testaufwand verünftiges Verhältnis zum erzielbaren Ergebnis, "Testen ist ökonomisch sinnvoll, solange die Kosten für das Finden und Beseitigen eines Fehlers im Test niedriger sind als die kosten, die mit dem Auftreten des Fehlers bei der Nutzung verbunden sind", Sys mit hohem Risiko müssen ausgiebig getestet werden :arrow_right: Testintensität / -umfang in Abhängigkeit Risiko, Auswahl Testverfahren je Aspekt, Test auch auf Fkt., die nicht gefordert ist, **Testfallexplosion:** Schnell hunderte Testfälle / -varianten, Test-Manager: Beschränkung Anzahl, oft wenig Ressourcen, oft schlechte Karten, wenn im Projekt auch Ressourcen knapp sind, :arrow_right: gute Strategie notwendig :arrow_right: fundamentaler Testprozess, Schlüsse aus früheren Projekten

##Fundamentaler Testprozess
Testen in jedem Vorgehensmodell, Zusätzlich zu Modellablauf: verfeinerter Ablaufplan für Testarbeiten, Inhalt "Entwicklungaufgabe" "Testen": Schritte: Testplanung und Steuerung, Testanalyse und-design, Testrealisierung und -durchführung, Testauswertung und Bericht, Abschluss Testaktivitäten - Auffassung als generische Prozessbeschreibung

###Testplanung und Steuerung
Planung Testprozess am Anfang SWE-Projekt, analog Projekt: regelmässig Kontrolle Planung, Aktualisierung, Anpassung, Kernaufgabe Planung: Bestimmung Teststrategie, Prioritäten anhand Risikoeinschätzung

**Testkonzept:**
  * Aufgaben & Ziele der Tests festlegen
  * Ressourcen einplanen (Zeit, Hilfsmittel, Geräte)
  * ...

**Steuerung:**
  * Überwachung (im Vergleich Planung)
  * Berichterstattung
  * Aktualisierung Planung

**Testmanagement:**
  * Verwaltung Testprozess
  * Testinfrastruktur
  * Testmittel

Testintensität stark Abhängig Testmethode und zu erreichenden Überdeckungsgrad (Kriterium Ende Test) + evtl. Erfüllung Anforderung als Endkriterium, z.B.: Alle Fkt mind. einmal getestet, oder 70% aller möglichen Transaktionen, Ausgangs- / Testendkriterien, Priorisierung Testfälle, Auswahl & Beschaffung Werkzeuge, Prüfung Aktualität vorhandene Werkzeuge, z.T müssen Teile der Testinfrastuktur selbst realisiert werden

**Testrahmen (test bed):** darin werden Systemteile zur Ausführung gebracht, müssen miest selbst programmiert werden

###Testanalyse und Testdesign
Testbasis analysieren: Dokument ausreichend Detailliert umd Testfälle abzuleiten (z.B Req-Dok, Architektur-Dok, Risikoanalyse, weitere), Testbarkeit feststellen: Testobjekt prüfen ob leicht zu testen (z.B. Zugang zu SST), Berücksichtigung bei Programmierung, Grundlage für Konkretisierung Testbedingungen, Berücksichtigung Risiko für weiters Vorgehen,  **Traceability:* zwischen Req und spez. Testfälle, + Verfolgbarkeit Änderungen der Req / Testfälle - Zuerst logische Testfälle, dann Konkretisierung (d.h. Tatsächliche Eingabewerte festlegen), auch umgekehrt möglich (wenn Testobjekt unzureichend spezifziert), konkrete Testfälle im Prozessschritt Realisierung, Auswahl log. Testfälle Basis Testbasis, Spez. Testfälle zu unterschiedlichen Zeiten Entwicklungsprozess (Black / Whitebox), Testfall: Vorbedingungen, Randbedingungen, Erwartetes Ergebniss / Verhalten, Testorakel: z.B. Spezifikation, Entweder Ableitung aus Spez, oder via Inverse-Funktion nach Test - Testfälle nach 2 Kriterien unterschieden: Prüfung spezifizierte / erwartete Ergebnisse / Reaktionen, Prüfung nicht spezifiziert / unerwartete / ungültige Eingaben - Beschreibung Testinfrastruktur

###Testrealisierung und Testdurchführung
Bildung konkrete Testfälle aus log. TF, Realisierung Testinfrastruktur und Testrahmen im Detail, Testläufe durchführen / protokollieren, Priorisierung TF, TF zu Testszenarien, Testrahmen programmiert und geprüft - Nach Übergabe an Test: Prüfung Vollständigkeit Systemteile :arrow_right: prinzipielleStart- / Ablauffähigkeit, Start Test mit Smoketest (Prüfung Hauptfkt.), Testdurchführung: Infos / Dok: Testrahmen, Eingabedaten, Testprotokoll, etc., Reproduzierung später, Bei allfälligem Fehler: Entscheid Fehler Ja / Nein, evtl. ergänzende TF, Klassifizierung Fehler

###Testauswertung und Bericht
Prüfung ob in Planung festgelegte Ausgangskriterien erfüllt sind, kann zur Beendigung Testaktivitäten führen, angemessenes Endkriterium pro Methode, weitere Tests wenn mind. 1 Kriterium nicht erfüllt, evtl. weiterer Tests notwendig (! nicht alle Tests bewirken Annäherung Endkriterium), Berücksichtigung Risiko, , Nichterfüllung Ausgangskriterium (z.B, durch tote Programmanweisungen) :arrow_right: Hinweis auf ungereimtheiten in Spez, evtl. Überarbeitung Planung - Kriterien: Testabdeckungskriterium, Fehlerfindungsrate -  Praxis: Testende häufig durch Zeit / Kosten - Alle Abschlusskriterien erfüllt: Zusammenfassender Bericht für Entscheidungsträger, Komponententest: Mitteilung Erfüllungsgrad an Projektmanager

###Abschluss der Testaktivitäten
oft vernachlässigt, Abweichungen Planung / Umsetzung, Ermittlung Gründe, Daten: Datum Freigabe SW-Sys, Datum Testende / -abbruch, Meilensteine, Wartungsreleases, wichtige Informationen: Welche geplanten Ergebnisse wurden wann erreicht? unvorhergesehene Ereignisse?, offene Probleme / Änderungswünsche?, Akzeptanz wie hoch? - Kritischer Rückblick, Verbesserungspotential, Konservierung Testmittel für Wartung

##Psychologie des Testens
Errare humanum est, Testen nicht destruktiv, sondern extrem kreativ / intellektuell herausfordernd, **Entwicklertest:** genügedn Abstand, eigenes Produkt kritisch prüfen, Gefahr sinnvolle Tests zu vergessen / nur oberflächlich, grundsätzliche Designfehler durch falsch verstandene Aufgabenstellung, Testfall kommt ihm nicht in den Sinn (Blind), Vorteil: keine Einarbeitung notwendig - **Unabhängiges Testteam:** Förderlich Qualität, Schärfe, Unvoreingenommenheit, Aneignung Know-How, dafür Test-Know-How, Art und Weise Mitteilung Fehler sehr wichtig, nicht einfach / leicht, Reaktion Entwickler "It's not a bug, it's a feature" nicht hilfreich, Förderlich Zusammenarbeit: Gegenseitige Kenntniss Arbeit, analoges Problem auf Mgmt-Ebene

##Allgemeine Prinzipien Softwaretest
  1.  Testen zeigt Anwesenheit von Fehlern  
      Kein Beweis für keine Fehlerzuständie im Testobjekt
  2.  Vollständiges Testen ist nicht möglich
  3.  Mit dem Testen fürhzeitg beginnen
  4.  Häufung von fehlern  
      Gleichverteilung Fehlerwirkungen meist nicht gegeben
  5.  Zunehmende Testresistenz (pesticide paradox)  
      Tests lassen in Wirksamkeit nach, TF regelmässig prüfen / modifizieren / ersetzen
  6.  Testen ist abhängig vom Umfeld
  7.  Trugschluss: Keine Fehler bedeutet ein brauchbares System

##Ethische Leitlinien
Tester häufig Zugang zu vertraulichen / sensiblen Informationen, angemessener Umgang

**Ethik-Kodex für "Certified Tester"**
  * Öffentlichkeit  
    Verhalten in Übereinstimmung öffentlichem Interesse
  * Kunde und Arbeitgeber  
    Wahren Interessen Kunde / Arbeitgeber in Übereinstimmung öffentlichem Interesse
  * Produkt  
    Sicherstellung glieferte Arbeitsergebnisse erfüllen höchstmögliche fachliche Anforderungen
  * Urteilsvermögen  
    Bewahren Rechtschaffenheit und Unabhängigkeit in sachverständiger Beurteilung
  * Management  
    SWT-Manager / Testleiter moralisch einwandfreie Einstellung zum Management SW-Test
  * Berufsbild  
    Fördern Integrität und Ansehen ihres Berufes in Übereinstimmung öffentliches interesse
  * Kollegen  
    Gegenüber Kollegen: fair und hilfsbereit, Förderung Kooperation
  * Persönliche Einstellung  
    berufsbegleitend kontinuierlich fort- / weiterbilden, an diesen Leitlinien orientierte ethische Einstellung fördern
