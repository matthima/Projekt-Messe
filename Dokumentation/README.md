
# Inhalt

1. [Einführung](#einführung)
2. [Anforderungsanalyse](#anforderungsanalyse)
    1. [Situationsbeschreibung](#situationsbeschreibung)
        1. [Teilprojekt SAE](#teilprojekt-sae-datenerfassung-neukunden)
        2. [Teilprojekt ITS](#teilprojekt-its-wlan)
3. [Umsetzung Teilprojekt ITS](#umsetzung-teilprojekt-its)
    1. [Netzwerkinfrastruktur](#netzwerkinfrastruktur-stand)
        1. [Netzwerkaufbau](#netzwerkaufbau)
        2. [Anbindung Messenetzwerk](#anbindung-messenetzwerk)
        3. [Netzwerk Einrichtung und IP-Zuweisung](#netzwerk-einrichtung-und-ip-zuweisung)
        4. [Routing](#routing)
    2. [WLAN](#wlan)
        1. [Zugang und Sicherheit](#zugang-und-sicherheit)
        2. [Anbindung von Clients](#anbindung-von-clients)
    3. [Inbetriebnahme](#inbetriebnahme)
4. [Umsetzung Teilprojekt SAE](#umsetzung-teilprojekt-sae)
    1. [Datenbank](#datenbank)
        1. [Datenbankmodell](#datenbankmodell-zb-relationen-modell)
    2. [Aufbau und Funktionsweise](#aufbau-und-funktionsweise)
        1. [Architektur](#architektur)
        2. [Use Case und UML](#use-case-und-uml-diagramme)
        3. [Prerequisites](#prerequisites-bibliotheken-und-komponenten)
        4. [Inbetriebnahme vor Ort](#inbetriebnahme-vor-ort)
        5. [Technische Beschreibung der WebCam Anbindung](#technische-beschreibung-der-webcam-anbindung)
        6. [Anleitung Bedienung Kunde](#anleitung-bedienung-durch-den-kunden)
        7. [Anleitung Datenabruf und Übermittlung](#anleitung-datenabruf-und-übermittlung)
        8. [Testszenarien](#testszenarien)

# Einführung

Für den Messeauftritt Ihres Unternehmens am 24.1.2024 soll eine WLAN-Infrastruktur und eine Software zur Erfassung von Kundendaten bereitgestellt werden.

# Anforderungsanalyse

## Situationsbeschreibung

Die Firma XYZ plant den Besuch einer Messe. Auf der Messe sollen neben den üblichen Tätigkeiten nach Möglichkeit auch Daten potenzieller Neukunden erhoben und gespeichert werden. Zu diesem Zweck kann der Messestand Gutscheine ausstellen, mit denen vergünstigte Angebote auf der Messe wahrgenommen werden können. Voraussetzung ist die Registrierung im Portal der Firma XYZ.

### Teilprojekt SAE: Datenerfassung Neukunden

Während des Messeauftritts sollen von Kunden im Self-Service Kundenkarten erstellt werden können, mit denen dann der Zugang zu weiteren Messeangeboten möglich wird. Dabei sollen Nachname, Vorname, Anschrift und ein Bild erfasst werden. Zusätzlich sollen ein oder mehrere Produktgruppen angegeben werden können, für die besonderes Interesse besteht. Bei Firmenvertretern soll zusätzlich ein Datensatz für die Firma angelegt werden.

Die Speicherung der Daten soll langfristig in einer Datenbank erfolgen. Da die Zuverlässigkeit der Netzwerkverbindung während des Messeauftritts nicht immer sichergestellt werden kann, muss das Erfassungssystem auch offline funktionieren und in der Lage sein, die Daten auf Wunsch an die Firmenzentrale zu übermitteln. Die Übermittlung soll mit Hilfe einer REST-API an den Firmenserver erfolgen. 

Die gespeicherten Daten sollen von den MitarbeiterInnen auch abgerufen und durchsucht werden können. Da es sich um einen Self-Service handelt muss sichergestellt werden, dass nicht jede Person das System frei nutzen kann. 

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

Auf der Messse existiert bereits ein vollständiges Netz. Dieses wird dabei in ein öffentliches und privates Netz aufgeteilt. Dadurch, dass das öffentliche Netz vermieden werden soll stellt der Veranstalter der Messe einen Internetfähigen Router zur Verfügung mit einer IP-Adresse in welcher Subnetze erstellt werden können. Die zur Verfügung gestellte IP-Adresse lautet wie folgt: 192.168.4.128/25.

Mithilfe dieses Internetfähigen Routers und der IP-Adresse wird das Netzwerk aufgebaut auf der Messe die Kundeninformationen aufnehmen zu können und zu der Firma schicken zu können.

### Netzwerkaufbau & Funktionsweise

Der Aufbau des Netzes auf der Messe soll unterteilt werden in zwei verschiedene Netze. In einem dieser Netze sollen sich die Firmeneigenen Geräte befinden und in dem anderen Netz die Geräte für die Kunden.
Dabei soll das Firmennetz platz für 16 Geräte besitzen und das Kundennetz für 4 Geräte. 

Vorerst war von dem Kunden verlangt, dass diese beiden Netze getrennt voneinander arbeiten sollten, dass bedeutet, dass sie keine Verbidnung zueinadner haben und die Geräte von dem einen Netz nicht in das andere gelangen können. Nach Rücksprache mit dem Kunden wurde allerdings verinbart, dass diese Anforderung verfällt um Kosten zu sparen, denn um diese Anforderung erfüllen zu können müssten mehr Geräte, sowie Kabel eingekauft werden.

Aufgrund der Einigung mit dem Kunden, dass die Netze nicht mehr streng von einander getrennt sein müssen wurde das Netzwerk wie folgt aufgebaut. An den von der Messe bereitgestellten Internetfähigen Router wurden von uns zwei AccessPoints angeschlossen. Es wurden AccessPoints gewählt, da diese die Verbindung mit den Geräten vor Ort erleichtern, dadurch, dass diese über WLAN beweltigt wird und keine weiteren Kabeln von nöten sind. 

Der eine AccesPoint dient für den Zugang der Kundengeräte. Der jeweils andere für den Zugang der Firmengeräte. Beide AccessPoints sind durch das Protokoll WPA2-PSK gesichert und einem selbstgewähltem Kennwort.

Das Kennwort um sich mit dem Kundennetz zu verbinden lautet: KundenNetz.
Das Kennwort um sich mit dem Firmennetz zu verbinden lautet: FirmenNetz.

Dasdurch, dass das Netz bereits aufgebaut wurde und eingerichtet ist müssen keine speziellen Einrichtungen vorgenommen werden. Damit Sie die Netze verwenden können muss sich das WLAN fähige Gerät in dem jeweiligen Bereich des AccesPoints befinden. Sobald dies der Fall ist muss eine neue WLAN-Verbindung eingerichtet werden. 

Die Namen der jeweiligen Netze wird dann angezeigt und durch das Verbinden und eingeben, des oben genannten Kennworts für das jeweilige Netz, wird die Verbidnung mit dem Netzwerk erstellt. Das Netzwerk für die Firmengeräte besitzt die SSID Firma und das Netz für die Kunden besitzt die SSID Kunden.

### Netzwerk Einrichtung und IP-Zuweisung

Die vom Messeveranstalter vergebene IP-Adresse, die im vorherigen Kapitel bereits erwähnt wurde musste von uns aufgeteilt werden in zwei Subnetze, um die zwei Netzwerke erstellen zu können.

Die Subnetze wurden aufgetielt so dass die Anforderungen der Geräte die sich in den jeweiligen Netzen befinden sollen erfüllt wird. Die Netze wurden so aufgetielt, dass in beide Netze jeweils 64 Geräte angeschlossen werden können, somit besteht auch genug Platz in beiden Netzen sollten in Zukunft mehr Geräte mit den Netzen verbunden werden.

Die IP-Adresse der jeweiligen Netze lauten:

Kunden Netz:192.168.4.128 / 26
Firmen Netz: 192.168.4.192 /26
Subnetzmaske 255.255.255.192

Die IP-Zuweisung erfolgt automatisch per DHCP. Das bedeutet sobald ein Gerät sich mit dem Netzwerk verbindet erhält dieses Gerät automatisch eine IP-Adresse in dem jeweiligen Netz.

# Umsetzung Teilprojekt SAE

## Datenbank

### Datenbankmodelle

#### Datenbankmodell

Siehe PDF namens ER-Modell

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

Für die Umsetzung der Datenbank wurde das vogegebene Entity Framework verwendet. Um die Datenbank aufzusetzen musste zunächst das Microsoft.EntityFrameworkCore.Sqlite Framework in NuGet installiert werden.

Nachdem das Framework installiert wurde beginnt die Erstellung der Datenbank mithilfe der Tables.cs Datei. Diese Datei dient zunächst dazu die Struktur der Datenbank darzustellen. Das bedeutet, dass hier die Attribute definiert werden, sowie die Verbindungen zueinander, wie es im Realtionen-Modell und im ER-Modell abgebildet ist. Die verschiedenen Entitys werden als Klassen dargestellt und die Attribute als Methoden.
Bei den Attributen die zwingend benötigt werden wird hinter dem public noch **required** hinzugefügt.

Die Datenbank und ihre Struktur sind somit festgelget. Um zwischen der Offline Datenbank und der API Datenbank zu unterscheiden werden zwei getrennte Datenbanken erstellt. In der MesseModel.cs sowie in der APIModel.cs wird der Name der Datenbank festgelegt, sowie der Speicherort. Bevor allerdings Datensätze in der Datenbank gespeichert werden können muss diese erstmal erstellt werden. Dabei ist es wichtig zu erwähnen, dass die MesseModel.cs die Offline Datenbank darstellt und die APIModel.cs die Datenbnak für die API.

Damit die Datenbank erstellt werden kann ist es notwendig folgende Befehle in der **Package Manager Console** auszuführen:

Install-Package Microsoft.EntityFrameworkCore.Tools
Add-Migration Messe -Context MesseContext -OutputDir Migrations/Messe
Add-Migration API -Context APIContext -OutputDir Migrations/API
Update-Database -Context MesseContext
Update-Database -Context APIContext

Der zweite und dritte Befehl ist dafür zuständig die Datenbank zu erstellen und in dem vorgegebenen Pfad abzuspeichern. Die letzten zwei Befehele bringen die Datenbank auf den neuesten Stand. Dadurch, dass zwei Datenbanken erstellt werden ist es notwendig die Befehele doppelt auszuführen allerdings mit anderen Namen, um auch beide Datenbanken zu erstellen. Sollte nur eine der beiden Datenbank gewünscht sein so wird nur der Befehel mit dem Namen der jeweiligen gewünschten Datenbank ausgeführt.


## Aufbau und Funktionsweise

### Architektur

### USE Case und UML Diagramme

### Prerequisites: Bibliotheken und Komponenten

### Inbetriebnahme vor Ort

### Technische Beschreibung der WebCam-Anbindung

### Anleitung Bedienung durch den Kunden

### Anleitung Datenabruf und Übermittlung

### Testszenarien
