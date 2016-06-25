
open System
open System.IO

// Einlesen der Daten
let dataReader path = 
    File.ReadAllLines path
    |> Array.map (fun x -> x.Split(',')) 
    |> Array.tail
    |> Array.map (Array.map int)
    |> Array.map (fun x -> (x.[0], x.[1..]))


let trainingData = dataReader <| "hier Pfad von trainingsample1.csv" 

let validationData = dataReader <| "hier Pfad von validationsample1.csv"


// Jedes Element der einglesenen Daten ist vom Typ int * int [].
// Die Elemente repräsentieren einzelne handschriftliche Ziffern von 0 bis 9 als Graustufenbild, zusammen mit dem entsprechenden Wert als int.
// Die Graustufenbilder sind im Format 28x28 mit Grauwerten von 0 bis 255 als int [] der Länge 784 (= 28 * 28) gegeben.


// Befor wir uns daran machen die Bilder zu klassifizieren, wollen wir sie ausgeben können.
// Implementieren Sie eine Funktion print, die ein Datenelement entgegennimmt und das enthaltene 
// Graustufenbild auf der Konsole (oder sonstwie) 'Zeichnet'. Sie können für die Graustufen die Liste ' '::['░'..'▓'] verwenden.
// Eine Ausgabe der print funktion könnte etwa wie folgt aussehen:
(*                            
                            
              ░▓▒           
              ▓▓▒           
             ▒▓▓            
            ░▓▓░            
            ▓▓▓             
           ▒▓▓░             
           ▓▓▓              
          ▓▓▓░              
          ▓▓▒  ░▒▓▓▓░       
         ▒▓▓░ ░▓▓▓▓▓▒       
         ▓▓▓ ░▓▓▒ ░▓▓░      
        ░▓▓░░▓▓▒    ▒▓      
        ░▓▓░▒▓▓     ░▓░     
        ░▓▓░▓▓      ▒▓▓     
        ░▓▓▒▓▓      ▓▓░     
         ▓▓▓▓▓     ▓▓▓      
         ▒▓▓▓▒   ▒▓▓▓░      
          ▓▓▓▓▓▓▓▓▓▓░       
           ▒▓▓▓▓▓▓▓░        
             ▒▒▒▒           
                            
*)

let print x =
    let greys = ' '::['░'..'▓']
    [ihr code]

// Testen Sie Ihre Funktion mit Array.iter print validationData

Array.iter print validationData

// Nun geht es darum einen Algorithmus zu entwerfen, der mithilfe von trainingData die Bilder der 
// validationData ihren entsprechenden int werten zuordnen kann.
// Als Klassifizierungsmethode wollen wir einen einfachen k-Nearest-Neighbor-Algorithmus verwenden (de.wikipedia.org/wiki/N%C3%A4chste-Nachbarn-Klassifikation).
 
// Nun geht es darum eine 'Distanzfunktion' auf der Menge der Graustufenbilder zu definieren.
// Die Signatur dieser Funktion sollte (int [] -> int [] -> int) sein. Ähnliche Bilder sollten einen kleinen Wert hervorbringen wohingegen sehr unterschiedliche Bilder
// "weit entfernt" voneinander sind. 
// Schliesslich werden Sie mit verschiedenen "Distanzfunktionen" experimientieren und testen welche die besten Resultate liefern.

let dist a b = 
    [ihr code]

// Diese Funktion soll zu gegebener Distanzfunktion 'metric' und gegebenem n: int und Datenelement 'sample' aus einer Mengen 'collection'
// von Datenelementen die n bezüglich der Distanzfunktion 'metric' nächsten Elemente ausgeben.
// Die Signatur könnte etwa wie folgt aussehen:
// metric:('a -> 'b -> 'c) ->
//    n:int -> 'd * 'b -> collection:('e * 'a) [] -> ('e * 'a) []
let findNearestN metric n sample collection =
    [ihr code]

// Wir setzen nun

let guess metric n sample = findNearestN metric n sample trainingData

// Damit erhalten wir eine Funktion die zu jedem gegebenen Sample (z.B. aus der Validation Set) die bezüglich der angegebenen 
// Metrik die n ähnlichsten Elemente aus trainingData zurückgibt. Damit lässt sich nun einfach ein k-nearest-neighbour algorithmus implementieren.
// Als Mass für die Qualität ihres Algorithmus geben Sie prozentual aus, wieviele Samples aus validationData richtig zugeordnet werden konnten.
// Zusätzlich können Sie z.B. ihren Algorithmus so schreiben, dass nicht erkannte Ziffern auf der Konsole ausgegeben werden. 





