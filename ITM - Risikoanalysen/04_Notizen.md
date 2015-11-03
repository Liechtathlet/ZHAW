## Lektion 5 & 6
### Boolesche Algebra
Für quantitative Risiko- und Zuverläsigkeitsanalsen

**Theorie:** Zustand (techn. System) als Boolesche Funktion, Gesucht: Vorgehensweise um Ausfallwahrscheinlichkeit zu berechnen, Problem: Übergang in kanonische Darstellung notwendig  

**Boolesche Variable:** L: Zustand erfüllt, O: Zustand nicht erfüllt

**Boolesche Operatoren:** und, oder  

**Boolesche Axiome (Schaltalgebra):** Kommutativgesetz, Assoziativgesetz, Distributivgesetz, Idempotenzgesetz, Absorptionsgesetz, Komplementärgesetz, Verneinungsgesetz, de-Morgansches Gesetz, Extremalgesetze, Neutralitätsgesetze  

#### Kanonische Darstellung Boolescher Funktionen
**Disjunktive Normalform (DN):** Konjunktionsterm aus einfahcen oder negierten Booleschen Variablen

**Ausgezeichnete DN (ADN):** in jedem Ki kommt jede Variable genau einmal vor (enfach oder negiert), Minterm (MI)

**Vorgehensweise:** Unvollständige Konjunktionsterme erweitern (Anwendung der Gesetze der Schaltalgebra)

#### Verfahren Quantifizierung
  - Zuverlässigkeitsblockdiagramme
  - Minimalschnitte und -pfade
  - Funktions- bzw. Wahrheitstabellen
  - Fehlerbäume

## Einfache Systemmodellierung: Zuverlössigkeitsblockdiagramme
Grafische Darstellung Boolesche Gleichung, Seriensystem, Parallelsystem  

  - Überlebenswahrscheinlichkeit: $ P(X_i = 1) = P(x_i) = p_i $

### Systemanalyse
Systemwahrscheinlichkeiten über Erfolswege ermitteln, Regel (Vereinfachung): Wenn 0: dann (1- xi)

#### Minimalschnitte

#### Minimalpfade



## Quantitative Tests
**Teststand:** 100 Glühbirnen, 2 Zustände: Funktioniert, Funktioniert Nicht
  - t = 0: Alle sind neu (keine Vorbelastung), WSK Funktionsfähig: 1
  - t = unendlich, WSK Funktionsfähig: 0
  - t = 1 Woche  (^P = n/N ) (Dach auf P: laufender Versuch), Pt(T <= t1w) = Summe (i) Pr(T=ti)

T = { t1, t2, t3, ..., tn}, 1 Komponente nacheinander fllt aus, Schrittlänge unterschiedlich

  - Ausfallrate = ^lambda = n/(N*tbetrieb) (Bezogen auf Zeit (interval))
  - Ausfallwsk: F(t) = 1-e^(-lambda t), konstante Ausfallrate

  **MeanTimeToFailure (MTTF):**
    - Konstante Ausfallrate: 1 / lambda

  Badewannenkurve der Ausfallrate (Zuerst Einführung, dann "Betrieb": e-Gleichung, dann "End-of-Life")

  ## Notes / Hints
    - Wahrscheinlichkeit: Demensionslose Grösse
    - Rate: irgendetwas pro zeit
    - Ausfall: Alles was repariert werden müsste / wurde

  ## Prüfung
    - Definitionen: Risiko, etc.
    - Besprochene Methoden (Fishbone, Master-Logik-Diagramm, FMEA, Bow-Tie, Zuverlässigkeitsblockdiagramme, ...): Wie geht das, was kann man damit machen
    - Berechnung einfacher Blockdiagramme
    - Ausfallrate (lambda = n/(N*t_betrieb)), zeitlich Konstant, Zusammenhänge Badewannenkurve
    - Ausfallwahrscheinlichkeit (P = n/N)
    - MeanTimeToFialure (1/x)
    - Wahrscheinlichkeit: F(t) = 1-e^(-lambda t)
    - Ausfalldichte anschauen (Steigung in einem Punkt)
    - Einteilung Badewannenkurve
