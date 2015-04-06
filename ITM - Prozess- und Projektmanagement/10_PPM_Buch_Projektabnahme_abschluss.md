#Projektabnahme und -abschluss
##Projektabnahme
**Validierung:** Technik Projektabnahme, Fragestellung: "Wurde das richtige Sw-Produkt entwickelt?" - 3 Vorgehen: Validierung durch Auftragnehmer / Auftraggeber / Dritte

**Verifikation:** Voraussetzung für Validierung, möglichst frühzeitig, böse Überraschungen und Überarbeitungsaufwände vermeiden, Prüfung Produkt gegen Spez durch Projektteam, Fragestellung: "Haben wir die SW richtig entwickelt, so wie ursprünglich spezifiziert wurde?"


###Typische Probleme
####Externer Auftraggeber
  * Geliefertes SWP ist noch fehlerhaft  
    Konsens: einfaches Vorgehen
  * Kunde verweigert Abnahme des SWP. Aus Sicht Auftragnehmer nicht fehlerhaft, aus Sicht Auftraggeber fehlerhaft
    Gründe für ungerechtfertigte Verweigerung Abnahme durch Auftragnehmer:  
      * Zahlung gelieferte Leistung noch nicht fällig, Aufraggeber spart Geld, (Vermutung) Zahlungsschwieriegkeiten / Liquiditätsschwäche: z.b. in Raten :arrow_right: ermöglicht rasche Abnahme und Abschluss, keine unnützen (fachlichen) Diskussionen
      * Späterer Beginn Gewährleistung  
        Festpreisprojekte: Auftraggeber kann länger Fehler auf Kosten Auftragnehmer ausbesern lassen
      * Überbetonung Abnahmeerklärung  
        Bei Auftraggeber übernimmt niemand Verantowrtung Abnahme, evtl. Abhilfe durch Hinweis anschliessende Gewährleistungsfrist, andere Befürchtung Projektteam löst sich rasch auf, andere Aufgaben, schwer für Fehlerverbesserungen / Änderungen wieder zu bekommen

####Interner Auftraggeber
Keine bewusste Verschleppung Projektabnahme, oft findet aber keine oder nur oberflächlich statt, häufig: Projekte mit externen Auftraggebern besser abgewickelt, als mit intern, Unterschied: Intern häufig kein Vertrag, keine harten Randbedingungen, Einsparung Bürkorkatismus, Begleiterscheinung: kein detailliertes Pflichtenheft, keine Möglichkeit ordentliche Abnahme

##Abnahmevoraussetzungen
  * Interne Verifikation durch Projektteam, möglichst früh
  * Zu jeder Anforderung: klare, messbare Validierungskriterien  
    Höhere Sicherheit: Auftraggeber erhält, was er wollte, Auftragnehmer erhält Bescheinigung Abnahme
  * Abnahmeprozess  
    Klare Vorgehensweise, Verantwortlichkeiten, benötigte Resosurcen, frühzeitig festlegen, planen, im Projektstrukturplan: Planen, Schützen
  * Umgang mit Mängeln  
    Kategorisierung Fehler (z.B. via Schweregrad), Umgang pro Kategorie, Bsp Ergebnisse:  
      * Billing Werk ohne Einwände
      * Abnahme mit unwesentlichen / leichten Mängeln
      * Abnahme trotz wesentlicher Mängel, aber Mängelbehebun bis...
      * Abnahme wegen Mängeln zurückgestellt
      * Abnahme ohne Prüfung
      * Keine Abnahme, Mängelbehebung bis...erneute Abnahme
  * Eng mit Änderungsmanagement verknüpft, Behanldung Mängel im Ende wie CRs

**Dokumentation Abnahme:** Vorfeld Definition Art / Weise Dokumentation Abnahme
  * Projektdaten (P.Bezeichnung, Auftragsnummer, Auftragsdatum, Auftraggeber, etc.)
  * Benennung SW inklusive aller abzunehmenden Produkte (inkl. doku, Begleitmaterial, etc.) (Empfänger, Datum Übergabe, Benennung inkl. Version)
  * Datum, Ort, Teilnehmer Abnahme
  * Art der Abnahme (Gesamt / Teil)
  * Verweis auf weitere Eingangs- / Ergebnisdokumente der Abnahme
  * Abnahmeergebnis
  * Dokumentation Datum "Beginn Gewährleistung", 3 Termine: Datum Auslieferung / Abnahme / Beginn Gewärhleistung
  * Unterschrift Auftraggeber, Auftragnehmer

###Praxis und Tipps
Vorallem für Festpreisprojekte
  * Noramler Fehler, berechtigt, keine Diskussion
  * Streit Funktionalität, aufgrund unsauberer Definition Req, Reduktion Risiko durch Techniken Req-Definition, allefnalls: verbindliche Genehmigung Req vereinbaren + evtl. gemeinsames Review, oft eher zu Lasten Auftragnehmer, evtl. Wartungsphase nach Aufwand :arrow_right: Abfederung / Ausgleich via Preisgestaltung
  * Streit, Auftraggeber: zahlt nicht mehr, Auftragnehmer: Leistung weiterhin liefern, sonst ungerechtfertigte Leistungsverweigerung, evtl. Schadenersatzpflichtig, etc.
  * Hinauszögerung Abnahme, regelmässig schwerwiegender Fehler gemeldet um Abnahme zu verzögern, frühzeitige Planung Vorgehen Abnahme, Abnahmespezifikation, Dokumentation und Bewertung Fehler, häufig auch: Auftraggeber hat eine Zeit, will nicht, Klausel im Vertrag zur automatischen Abnahme (z.B. Frist 14 Tage), Mängel müssen schriftlich gemeldet werden

**Weitere Anmerkungen:**
  * Abnahmeverfahren frühzeitg Abstimmen, besprechen, mit wichtgisten STH, vor offizieller Abnahme: inoffizieller Akzeptanztest in Form Befragung STH, Abnahme dann nur noch formal
  * Abnahmeumgebung, drei Modelle: Abnahme auf Entwicklungsstufe (Auftragnehmer), Abnahme auf Testsystem, Abnahme auf Produktion


##Projektabschluss
Projektabschluss nachgelagert

**Ziele:**
  * Durchführung Aufräumarbeiten (Abschluss Planungsdokumente, nachkalkulation, technische Dokumentatioin)
  * Erfahrungen sammeln, für spätere Nutzung auswerten

grössere Projekte: Abschluss pro Phase, lernen für zukünftige Projekte und Phasen, entweder als Workshops (1 Tag), Projektreview (0.5 Tag), Feedback-Sitzungen (2h)

**Themen & Ablauf:**
  * Vorbereitung
    * Abschluss Dokumentation
    * Nachkalkulation, Vergleich Soll / Ist
    * Betrachtung Effektivität, Effizienz der gelebten Prozesse, objektive Aussage, Interpretation Zahlen
  * Durchführung
    * Diskussion allfällige Abweichungen Nachkalkulation
    * Analyse Zusammenarbeit
    * Betrachtung eingetretene Risiken, Probleme
    * Besprechung Einhaltung Projektprozesse
    * Präsentation & Interpretation Metriken, Identifikation Verbesserungspotenzial, Definition & Planung Massnahmen
  * Nachbearbeitung
    * Dokumentation Verbesserungsotenziale, Aktualisierung Prozessbeschreibungen, Dokumentvorlagen, Checklisten (u.a. Risikokatalog)
    * Aktualisierung MA-Profile bei HR
    * Veröffentlichung Analysearbeit in Unternehmung, nicht nur im Intranet veröffentlichen, Kommunizieren, unternehmensinternes forum o.ä.
