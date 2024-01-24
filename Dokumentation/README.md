# Einführung

Für den Messeauftritt Ihres Unternehmens am 24.1.2024 soll eine WLAN-Infrastruktur und eine Software zur Erfassung von Kundendaten bereitgestellt werden.

# Anforderungsanalyse

## Situationsbeschreibung

Die Firma XYZ plant den Besuch einer Messe. Auf der Messe sollen neben den üblichen Tätigkeiten nach Möglichkeit auch Daten potenzieller Neukunden erhoben und gespeichert werden. Zu diesem Zweck kann der Messestand Gutscheine ausstellen, mit denen vergünstigte Angebote auf der Messe wahrgenommen werden können. Voraussetzung ist die Registrierung im Portal der Firma XYZ.

### Teilprojekt SAE: Datenerfassung Neukunden

Während des Messeauftritts sollen von Kunden im Self-Service Kundenkarten erstellt werden können, mit denen dann der Zugang zu weiteren Messeangeboten möglich wird. Dabei sollen Nachname, Vorname, Anschrift und ein Bild erfasst werden. Zusätzlich sollen ein oder mehrere Produktgruppen angegeben werden können, für die besonderes Interesse besteht. Bei Firmenvertretern soll zusätzlich ein Datensatz für die Firma angelegt werden.

Die Speicherung der Daten soll langfristig in einer Datenbank erfolgen. Da die Zuverlässigkeit der Netzwerkverbindung während des Messeauftritts nicht immer sichergestellt werden kann, muss das Erfassungssystem auch offline funktionieren und in der Lage sein, die Daten auf Wunsch an die Firmenzentrale zu übermitteln. Die Übermittlung soll mit Hilfe einer REST-API an den Firmenserver erfolgen.

Die gespeicherten Daten sollen von den MitarbeiterInnen auch abgerufen und durchsucht werden können. Da es sich um einen Self-Service handelt, muss sichergestellt werden, dass nicht jede Person das System frei nutzen kann. 

Für die Erfassung des Fotos soll eine Webcam angebunden werden. Für die Erfassung der Daten sollen 4 firmeneigene Laptops zur Verfügung gestellt werden, die über WLAN an das Internet angebunden sind (siehe unten)

```
Rahmenbedingungen: C#, REST API Asp.net, SQLite, Entity Framework Core, ER und Relationenmodell

Zu prüfen: Design Patterns? Interface, Dependency Injection
```

### Teilprojekt ITS: WLAN

Sie sollen für den Messeauftritt ein eigenes WLAN planen, da Sie nicht auf das dort verfügbare öffentliche WLAN zugreifen wollen. Zu diesem Zweck erhalten Sie vom Messeveranstalter einen internetfähigen Router mit der Auflage, nur Subnetze im Bereich 192.168.4.128/25 anzubieten.

Das Netzwerk muss so aufgebaut sein, dass die im Teilprojekt SAE erfassten Daten bei Bedarf an die Firmenzentrale übermittelt werden können. Die insgesamt 16 firmeneigenen Endgeräte sollen über das WLAN angebunden werden. Die 4 für Kunden gedachten Laptops sollen sich in einem anderen Netz als die Geräte der Mitarbeiter befinden.

```
Anforderungen: Subnetting, Konfiguration WLAN, AccessPoints

Informieren: WLAN Controller, RADIUS, AAA-Server
```

# Umsetzung Teilprojekt ITS

## Netzwerkinfrastruktur Stand

Auf der Messe existiert bereits ein vollständiges Netz. Dieses wird dabei in ein öffentliches und privates Netz aufgeteilt. Dadurch, dass das öffentliche Netz vermieden werden soll, stellt der Veranstalter der Messe einen internetfähigen Router zur Verfügung mit einer IP-Adresse, in welcher Subnetze erstellt werden können. Die zur Verfügung gestellte IP-Adresse lautet wie folgt: 192.168.4.128/25.

Mithilfe dieses internetfähigen Routers und der IP-Adresse wird das Netzwerk aufgebaut auf der Messe die Kundeninformationen aufnehmen zu können und zu der Firma schicken zu können.

### Netzwerkaufbau & Funktionsweise

Der Aufbau des Netzes auf der Messe soll in zwei verschiedene Netze unterteilt werden. In einem dieser Netze sollen sich die firmeneigenen Geräte befinden und in dem anderen Netz die Geräte für die Kunden.

Dabei soll das Firmennetz Platz für 16 Geräte besitzen und das Kundennetz für 4 Geräte. 

Vorerst war von dem Kunden verlangt, dass diese beiden Netze getrennt voneinander arbeiten sollten. Das bedeutet, dass sie keine Verbindung zueinander haben und die Geräte von dem einen Netz nicht in das andere gelangen können. Nach Rücksprache mit dem Kunden wurde allerdings vereinbart, dass diese Anforderung verfällt, um Kosten zu sparen, denn um diese Anforderung erfüllen zu können, müssten mehr Geräte sowie Kabel eingekauft werden.

Aufgrund der Einigung mit dem Kunden, dass die Netze nicht mehr streng voneinander getrennt sein müssen, wurde das Netzwerk wie folgt aufgebaut. An den von der Messe bereitgestellten internetfähigen Router wurden von uns zwei Accesspoints angeschlossen. Es wurden Accesspoints gewählt, da diese die Verbindung mit den Geräten vor Ort erleichtern, dadurch, dass diese über WLAN bewältigt wird und keine weiteren Kabel notwendig sind. 

Der eine Accesspoint dient für den Zugang der Kundengeräte. Der jeweils andere für den Zugang der Firmengeräte. Beide Accesspoints sind durch das Protokoll WPA2-PSK gesichert und einem selbstgewählten Kennwort.

Das Kennwort um sich mit dem Kundennetz zu verbinden lautet: KundenNetz.

Das Kennwort um sich mit dem Firmennetz zu verbinden lautet: FirmenNetz.

Dadurch, dass das Netz bereits aufgebaut wurde und eingerichtet ist, müssen keine speziellen Einrichtungen vorgenommen werden. Damit Sie die Netze verwenden können, muss sich das WLAN-fähige Gerät in dem jeweiligen Bereich des Accesspoints befinden. Sobald dies der Fall ist, muss eine neue WLAN-Verbindung eingerichtet werden. 

Die Namen der jeweiligen Netze werden dann angezeigt und durch das Verbinden und Eingeben des oben genannten Kennworts für das jeweilige Netz wird die Verbindung mit dem Netzwerk erstellt. Das Netzwerk für die Firmengeräte besitzt die SSID Firma und das Netz für die Kunden besitzt die SSID Kunden.

Zusätzlich ist zu erwähnen, dass zusätzlich ein lokaler Datenbankserver vor Ort bei der Messe eingerichtet wird. Durch die Einrichtung dieses Servers ist es möglich, die neu erfassten Daten bei den Laptops für die Kunden dort abzuspeichern. Um die Daten zum Server im Firmennetz hochzuladen, wird die API genutzt. Dabei werden die Daten auf dem Server im Firmennetz hochgeladen und danach die hochgeladenen Daten von der Datenbank auf der Messe gelöscht.

### Netzwerkeinrichtung und IP-Zuweisung

Die vom Messeveranstalter vergebene IP-Adresse, die im vorherigen Kapitel bereits erwähnt wurde, musste von uns aufgeteilt werden in zwei Subnetze, um die zwei Netzwerke erstellen zu können.

Die Subnetze wurden aufgeteilt, sodass die Anforderungen der Geräte, die sich in den jeweiligen Netzen befinden sollen, erfüllt werden. Die Netze wurden so aufgeteilt, dass in beide Netze jeweils 64 Geräte angeschlossen werden können, somit besteht auch genug Platz in beiden Netzen, sollten in Zukunft mehr Geräte mit den Netzen verbunden werden.

Die IP-Adressen der jeweiligen Netze lauten:

KundenNetz: 192.168.4.128 / 26

FirmenNetz: 192.168.4.192 /26

Subnetzmaske 255.255.255.192

Die IP-Zuweisung erfolgt automatisch per DHCP. Das bedeutet, sobald ein Gerät sich mit dem Netzwerk verbindet, erhält dieses Gerät automatisch eine IP-Adresse in dem jeweiligen Netz.

# Umsetzung Teilprojekt SAE

## Datenbank

### Modelle

#### Entity-Relationship-Modell

Siehe PDF: ER-Modell.pdf

#### Relationen-Modell

Legende: 

*name* -> Primary key

-name- -> Foreign key

Kunde (*KundenId*,Vorname,Nachname,PLZ,Ort,Straße,Hausnummer,Foto,Firmenvertreter,-FirmaId-)

Firma (*FirmaId*,Name)

Produktgruppe (*ProduktgruppeId*,Name)

ProduktgruppeKunde (*ProduktgruppeKundeId*,-ProduktgruppeId-,-KundeId-)

User (*UserId*,Name,Passwort) 

### Technische Dokumentation

Für die Umsetzung der Datenbank wurde das vorgegebene Entity Framework verwendet. Um die Datenbank aufzusetzen, musste zunächst das Microsoft.EntityFrameworkCore.Sqlite Framework in NuGet installiert werden.

Nachdem das Framework installiert wurde, beginnt die Erstellung der Datenbank mithilfe der Tables.cs Datei. Diese Datei dient zunächst dazu, die Struktur der Datenbank darzustellen. Das bedeutet, dass hier die Attribute definiert werden, sowie die Verbindungen zueinander, wie es im Relationen-Modell und im ER-Modell abgebildet ist. Die verschiedenen Entitäten werden als Klassen dargestellt und die Attribute als Methoden.

Bei den Attributen, die zwingend benötigt werden, wird hinter dem public noch **required** hinzugefügt.

Die Datenbank und ihre Struktur sind somit festgelegt. Um zwischen der Offline-Datenbank und der API-Datenbank zu unterscheiden, werden zwei getrennte Datenbanken erstellt. In der MesseModel.cs sowie in der APIModel.cs wird der Name der Datenbank festgelegt, sowie der Speicherort. Bevor allerdings Datensätze in der Datenbank gespeichert werden können, muss diese erstmal erstellt werden. Dabei ist es wichtig zu erwähnen, dass die MesseModel.cs die Offline-Datenbank darstellt und die APIModel.cs die Datenbank für die API.

Damit die Datenbank erstellt werden kann, ist es notwendig, folgende Befehle in der **Package Manager Console** auszuführen:

```
Install-Package Microsoft.EntityFrameworkCore.Tools

Add-Migration Messe -Context MesseContext -OutputDir Migrations/Messe
Add-Migration API -Context APIContext -OutputDir Migrations/API

Update-Database -Context MesseContext
Update-Database -Context APIContext
```

`Add-Migration` ist dafür zuständig, die Datenbank zu erstellen und in dem vorgegebenen Pfad abzuspeichern. 

`Update-Database` bringt die Datenbank auf den neuesten Stand. Dadurch, dass zwei Datenbanken erstellt werden, ist es notwendig, die Befehle doppelt auszuführen, allerdings mit anderen Namen, um auch beide Datenbanken zu erstellen. Sollte nur eine der beiden Datenbanken gewünscht sein, so wird nur der Befehl mit dem Namen der jeweiligen gewünschten Datenbank ausgeführt.


## Aufbau und Funktionsweise

### Architektur

Das Programm besteht aus verschiedenen Modulen, die miteinander interagieren.

Im **Database** Modul werden mit Hilfe des *Entity Frameworks* der Aufbau und Zugriff auf die zwei Datenbanken (lokaler Speicher und API-Datenbank) definiert. Alle folgenden Module implementieren einen Datenbankzugriff und sind dementsprechend auf dieses Modul angewiesen.

Das **App**-Modul ist für die Benutzeroberfläche und das temporäre Speichern in der lokalen Datenbank verantwortlich. Zusätzlich wird eine Anbindung an die Webcam implementiert, um Kundenausweise mit Bildern auszustatten. Es ist die Schnittstelle zwischen dem Kunden und unserem Backend.

Für firmeninterne Abfragen stellt das **API**-Modul eine REST-API bereit. Um die Sicherheit der Kundendaten zu gewährleisten, erfordern alle Abfragen einen eingeloggten, verifizierten Entwickleraccount.

Aufgrund der unbeständigen Verbindung zwischen der Messe und unserem Firmenserver werden zuerst alle Daten auf einem lokalen Server gespeichert. Das **DatabaseSync** Modul implementiert ein Skript, welches versucht eine Verbindung aufzubauen und die Daten auf unseren Firmenserver zu übertragen.


### Use-Case- und UML-Diagramme

Siehe Dateien Use-Case.png und UML.png

### Prerequisites: Bibliotheken und Komponenten

- Webcam
    - AForge
    - AForge.Video.DirectShow
- Datenbank
    - Microsoft.EntityFrameworkCore
    - Microsoft.EntityFrameworkCore.InMemory
    - Microsoft.EntityFrameworkCore.Sqlite
    - Microsoft.EntityFrameworkCore.Tools
- REST-API
    - Swashbuckle.AspNetCore
- Authentifizierung
    - Microsoft.IdentityModel.Tokens
    - Microsoft.AspNetCore.Authentication.JwtBearer

### Inbetriebnahme vor Ort

Für Kunden sollen vier Notebooks ausgestellt werden, an denen Kundenausweise generiert werden können. Um Asynchronität zu vermeiden, wird die lokale Datenbank auf einem separaten Server gestartet. Dies vereinfacht ebenfalls den Sync zwischen lokalem Speicher und unserer Firmendatenbank.

Zusätzlich soll immer ein Vertreter unserer Firma bereitstehen, um auf Kundenfragen zum Programm eingehen zu können, oder auftretende Probleme schnell zu lösen.

### Technische Beschreibung der Webcam-Anbindung

Die Webcam-Anbindung **WebcamFeed** basiert auf der **VideoCaptureDevice** Klasse des **AForge**-Packages. 

Um einen WebcamFeed zu starten, muss eine **PictureBox**, hier die entsprechende Fläche in der Benutzeroberfläche, als Ziel angegeben werden. 

Mit Hilfe der von AForge bereitgestellten Methoden können wir den starten und stoppen.

Ist der Feed gestartet, triggert jeder aufgezeichnete Frame den **FrameEventHandler**, welcher wiederum die **PictureBox** aktualisiert, um den Frame anzuzeigen.

### Anleitung Bedienung durch den Kunden

Die Bedienung durch den Kunden beschränkt sich lediglich auf das Ausfüllen des Formulars in der Benutzeroberfläche.

Das Programm ist darauf konzipiert, kontinuierlich verwendbar zu sein, indem die einzelnen Elemente des Formulars nach erfolgreicher Angabe zurückgesetzt werden. 

So muss es nur initial gestartet werden und kann von beliebig vielen Kunden verwendet werden.

### Anleitung Datenabruf und Übermittlung

Der Datenabruf und die -übermittlung erfolgen jeweils durch die API und das Übertragungsskript im Modul **DatabaseSync**. Die Dokumentation der API liegt in der Datei **API-Doku.md** bei.

Das Übertragungsskript vergleicht den Stand beider Datenbanken und führt auf die "variablen" Daten (Kunden, Firmen, ausgewählte Produktgruppen) einen sogenannten "Upsert" (Update/Insert) aus; es werden also nur Daten in die Firmendatenbank eingefügt, die nicht bereits existieren. Schließlich wird der lokale Speicher geleert.

Zuletzt überträgt die Firmendatenbank die definierten Produktgruppen wieder an den auf der Messe stehenden lokalen Speicher.
