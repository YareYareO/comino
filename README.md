# comino

Eine Augmented Reality Indoor Navigations Applikation.
Entwickelt mit der Unity Engine im Rahmen eines Semesterprojekts

Für ein besseres Verständnis ist im Repository eine Pdf Praesentation verfübar. 

Die Kernfunktionen sind da und zwei kleine Dummy-Datensätze findbar.

Erklärung der App:
Die App ermöglicht es durch jede begrenzte Umgebund zu navigieren. In AR! 
Die dafür benötigten Datensätze bestehen lediglich aus einfachen JSON Dateien.
Jede Datei enthält mögliche Startpositionen, aussuchbare Ziele und eine Auflistung der Verbindungen zwischen allen Räumen der Umgebung.
Der Nutzer öffnet die Anwendung und sucht zuerst die Umgebung aus, inder er sich aktuell befindet. 
Die Umgebungen / Datensätze befinden sich aktuell auf einer Firebase Realtime Database.
Mit der ausgewählten Umgebung sucht der Nutzer nun Startposition und Ziel aus.
Hierbei geht das Programm schrittweise vor: Umgebung -> Startposition -> Ziel -> Suche starten. Demonstriert mit dem ProceedButton.
Dabei kann man immer wieder entweder einen Schritt zurück (Back Button) oder komplett von neu starten (Reset Button)
Sobald die relevanten Daten der Suche ausgesucht wurden, berechnet ein Algorithmus den direktesten Weg vom Start bis zum Ziel.
Der Algorithmus nutzt die übliche Breitensuche, kombiniert mit Backtracking, um einen Pfad zurückzugeben.
Ich habe den Algorithmus mal Domino-Algorithmus genannt, da die Herangehensweise an ein Domino-Spiel erinnert.
Mit dem direktesten Pfad wechselt der Nutzer in eine AR Sicht. Es ist wichtig hierbei das Mobile Gerät gerade / senkrecht / vertikal 
UND an der vorgesehenen Stelle / Koordinate zu nutzen. Da die App noch auf keine echten Datensätze zugreift, ist der letztere Teil noch unwichtig.
Aber es ist wichtig zu nennen, das die App mit Datensätzen arbeitet, die alle relativ zu einer bestimmten Startposition sind. 
Wählt man den Haupteingang als Startposition aus, dann muss man auch das Mobilgerät an genau der richtigen Stelle, mit der richtigen Rotation 
und idealerweise nicht grotesker Höhe halte UND ZWAR in genau dem Moment indem zum letztem Mal auf Proceed gedrückt wird BIS die AR Szene vollständig geladen wurde (erkennbar daran dass der Pfeil nicht mehr stur gerade aus zeigt).
In der echten Welt lässt sich das leicht implementieren. Man hänge einfach ein Blatt Papier auf mit dem Namen der jeweiligen Startposition,
und sinngemäß hält man dann das Mobilgerät an das Papier wenn man die Suche startet. 
(Zur Klarstellung, das Mobilgerät kann bewegt werden wie man möchte während man die Umgebung etc auswählt)

Sobald die AR Szene geladen wurde, deutet ein dicker Pfeil in der oberen Hälfte des Screens auf die jeweils nächste Koordinate. 
Koordinaten oder Punkte werden auf dem Bildschirm mit einem großen Marker dargestellt. Man kann dennoch natürlich alleine mit dem Pfeil arbeiten.
Dieser funktioniert wie ein Kompass, woher auch der Name der Anwendung kommt: Compass + Domino = Comino. Namensgebung war noch nie meine Stärke
So läuft man von Punkt zum Punkt bis das Ziel erreicht wurde. 
Hierbei ist es wichtig zu wissen, dass das Mobilgerät die Umgebung wahrnehmen muss um die aktuelle Position zu bestimmen. 
Die Kamera ist also das Auge des Geräts und kann in der Hosentasche nichts sehen. 
Also bestenfalls mit der Kamera stets auf den Weg zeigen den man gerade geht.
Zusätzlich dazu funktioniert die Suche nicht in sehr dunklen Räumen, und wenn das Mobilgerät aggressiv geschüttelt wird.
Man muss aber keinesfalls monoton und ohne jemals zu ruckeln gehen. Nach einpaar Versuchen ist eine überdurchnittlich lässige Gangart absolut in Ordnung.
Nachdem das Ziel erreicht ist, passiert garnichts mehr. Sie werden wahrscheinlich etwas an dem Ort den Sie gerade erreicht haben etwas tun wollen und nicht direkt wieder woanders hin losziehen. Also die App einfach schliessen und bei Bedarf wieder öffnen, sind la nur unter 10 MB.

Pläne für die Zukunft:
- Ich weis nicht ganz ob ich aus dieser Anwendung eine "production ready" App machen will, aber eine Möglichkeit bleibt es.
- Online Zwang: Gerade besteht nur die Möglichkeit Datensätze aus der Cloud zu holen, da möchte ich noch irgendwann eine elegante Hybridlösung zu schaffen.
- Das optische ist noch... ausbaubar.
- Quality of life features kann man immer hinzuaddieren, wie zB. aus der Suche zurück ins Hauptmenü zu gehen.
- Build ist aktuell nur für Android möglich, da Apple nicht möchte, dass Nicht-Apple-Entwickler IOS Apps kriieren und ich keine Lust habe dafür ein Macbook zu kaufen. Wenn Sie mir eins kaufen möchten, dann stelle ich als Dank natürlich ein ios build zur Verfügung :)

Die komplette Anwendung habe ich selbst entwickelt (nur zur Info) 


Notiz für (Linux) Entwickler:
in den firebase ordner /Assets/Firebase/Plugins/x86_64
sind aut meinem lokalen rechner FirebaseCppApp-10_6_0.bundle und FirebaseCppApp-10_6_0.so
diese sind nur relevant (anscheinend) wenn man mit linux entwickelt
die beiden dateien sind groesser als github es erlaubt und werden deshalb ignored.
wenn du diese dateien haben willst, lade die offizielle firebase_unity_sdk_10.6.0 zip herunter
und entpacke das database plugin, und picke die dateien heraus.
