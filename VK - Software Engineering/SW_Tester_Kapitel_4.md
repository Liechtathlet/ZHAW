#Kapitel 4
Betrachtung Prüfobjekt durch Mensch / Werkzeug  
**Reviews:** Manuellle Prüfung, 1:n, kann bei allem angewendet werden  
**Statische Analyse:** Automatisierte Prüfun mit Werkzeugen, Dokumente mit formaler Struktur (Code, UML)

##Strukturierte Gruppenprüfungen
**Review:** Oberbegriff verschiedene Prüfverfahren: Inspektion, Walktrough, Technisches Review, Informelles Review, Peer Review - effizientes Mittel zur Sicherung der Qualität, Ende Projektphase: Review

###Grundlagen
Analyse Testobjekt durch intensive Betrachtung, Ziel: Ermittlung Fehlerzustände im Dokument, Grundidee: Prävention, so früh als möglich erkennen

###Reviews
Nicht-Werkzeuggestutzt: Nutzung menschliche Analyse- / Denkfähigkeit, intensives Lesen / Nachvollziehen, verschiedene Vorgehensweisen

####Grundlegende Vorgehensweise
**Arbeitschritte:**
  1.  Planung
  2.  Kick-Off
  3.  Individuelle Vorbereitung
  4.  Review Sitzung
  5.  Überarbeitung
  6.  Nachbereitung

#####Planung
Mgmt. bestimmt Dokumente für Review, Schätzung und Einplanung Review, Eingangs- / Austrittskriterien für Durchführung Review, Manager wählt geeignete Person aus / Zusammenstellung Review-Team, Prüfung Kooperation Autor "review-fähiger"-Status, Festlegung Ort und Zeit Kick-Off

#####Kickoff
Informationen an beteiligte Personen durchgeben, Überprüfung Eingangsbedingungen, Schrifltiche Einladung / Sofortiges Treffen, weiter Unterlagen für Beteiligte bereitstellen, Prüfkriterien festlegen

#####Individuelle Vorbereitung
Gutachter mit Dokument auseinandersetzen, Fragekatalog erstellen

#####Sitzung
Moderator kann Sitzung absagen / abbrechen (Gutachter kommt nicht, ungenügend vorbereitet), Resultat (nicht Autor) wird diskutiert, keine Angriffe auf Autor, Autor dar sich / das Resultat nicht verzeitigen, Moderator darf nicht Gutachter sein, keine allgemeinen Stilfragen, Entwicklung / Diskussion Lösung nicht Aufgabe Reviewteam, Jeder Gutachter Befunde angemessen präsentieren, Konses Gutachter laufend protokollieren, Befunde in Form von Anweisungen an Autor, Gewichtung: z.B. Kritischer Fehler, Hauptfehler, nebenfehler, Gut - Review-Team: Empfehlung Annahme (Akzeptieren ohne Änderung, mit Änderung ohne Reviewe, nicht akzeptieren), Protokoll Liste aller Befunde: Informationen zum Prüfobjekt, verwendete Dokumente, Beteiligte Personen, Rollen, Zusammenfassung / Protokoll, Ergebnis + Empfehlung

#####Überarbeitung
Behebung Befunde (durch Autor), evtl. Rücksprache Gutachter

#####Nachbereitung
Kontrolle Durchführung Überarbeitung, Prüfung Korrekturen / Fehlerzustände, Sammeln Metriken, Prüfung Austrittskriterien, Manager entscheidet ob er Empfehlung Gutachter folgt (alleinige Verantwortung beim Manager), evtl. weiteres Review bei nicht Akzeptanz

####Rollen
  * Manager  
    Enscheidet über Durchführung Review, Prüfobjekte, Ressourcen für Review-Team zusammenstellen, Überprüft Review-Ziele, Entscheidet über Vorgehen
  * Moderator  
    Leitet Sitzung / Entscheidende Person Erfolg Review, Planungsaktivitäten, Vermittlung Standpunkte, Keine Voreingenommenheit / eigene Meinung
  * Autor
    Ersteller Dokument (Hauptverantwortlicher), Kritik nicht als Kritik an Person auffassen
  * Gutachter (Reviewer, Inspektor)
    max. 5, gut befundene Teile entsprechend benennen, Kennzeichnung Mängel, so gewählt, dass verschiedene Sichten / Rollen vertreten
  * Protokollant

####Reviewarten
  * Gruppen von Reviews (Produkte / Teilprodukt, Prozesse / Projektablauf)
  * Walktrough (Mittelpunkt: Sitzung, kein formaler Ablauf)
  * Inspektion (Formalstes Review)
  * Technische Review
  * Informelles Review

##Statische (werkzeugbasierte) Analyse
Keine Ausführung Testobjekt, Viele Defekte erst bei dynamischen Tests erkennbar, Überprüfung, Vermessung, Darstellung Dokument / Programm, Prüfung Einhaltung Konventionen / Standards, Datenflussanalyse, Kontrollflussanalyse, Metriken

###Compiler als statisches Analysewerkzeug
Syntax, Cross Reference List, Typgerechte Verwendung, Ermittlung nicht deklarierte Var, Nicht erreichbarer Code, Über- / Unterschreitung Feldgrenzen, Prüfung Konsistenz SST

###Prüfung Einhaltung Konventionen und Standards
Programmierkonventionen durch Analysatoren, Richtlinien: sollten automatisch prüfbar sein.

###Datenflussanalyse
Untersuchung Verwendung Daten auf Pfaden: ur-Anomalie (undefiniert Wert Var auf Programmpfad gelesen) - du-Anomalie (Var erhält Wert, der ungültig wird, ohne dass dieser verwendet wurde), dd-Anomalie (Var erhält auf Programmpfad ein zweites Mal einen Wert, ohne dass der erste Wert verwendet wurde)

###Kontrollflussanalyse
Programmstück als Kontrollflussgraph, Anweisung + Sequenz von Anweisungen = Knoten, Änderungen durch Verzweigungen und Schleifen, Visualisierung: Einfache Erfassung Anomalien (Sprünge aus Schleifen, Mehrere Ausgänge)

###Ermittlung von Metriken
Number of Variables, Number of Methods, Weighted Method Complexity, Lack of Coehsion of Methods, Number of Redifined Methods, Number of childern, Depth of Inheritance tree

###Zyklomatische Zahl
Gesucht (g) = e - n + 2, n: Anzahl Knoten, e: Anzahl Kanten, höher als 10: nict tolerabel, für Wartbarkeit von Bedeutung, gibt Auskunft über Testaufwand: obere Grenze Anzahl benötigte Testfälle
