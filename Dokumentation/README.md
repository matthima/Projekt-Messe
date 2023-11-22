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

### Netzwerkaufbau

### Anbindung Messenetzwerk

### Netzwerk Einrichtung und IP-Zuweisung

### Routing

## WLAN

### Zugang und Sicherheit

### Anbindung von Clients

## Inbetriebnahme

# Umsetzung Teilprojekt SAE

## Datenbank

### Datenbankmodell z.B. Relationen-Modell

## Aufbau und Funktionsweise

### Architektur

### USE Case und UML Diagramme

### Prerequisites: Bibliotheken und Komponenten

### Inbetriebnahme vor Ort

### Technische Beschreibung der WebCam-Anbindung

### Anleitung Bedienung durch den Kunden

### Anleitung Datenabruf und Übermittlung

### Testszenarien