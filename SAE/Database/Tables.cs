namespace Database {
    public class Kunde {
        public int KundeId { get; set; }

        public required string Vorname { get; set; }
        public required string Nachname { get; set; }
        public required int PLZ { get; set; }
        public required string Ort { get; set; }
        public required string Strasse { get; set; }
        public required string Hausnummer { get; set; }
        public required string Foto { get; set; } // base 64 encoded
        public required bool Firmenvertreter { get; set; }

        public int? FirmaId { get; set; }
    }

    public class Firma {
        public int FirmaId { get; set; }
        public required string Name { get; set; }
    }

    public class Produktgruppe {
        public int ProduktgruppeId { get; set; }
        public required string Name { get; set; }
    }

    public class ProduktgruppeKunde {
        public int ProduktgruppeKundeId { get; set; }
        public required int ProduktgruppeId { get; set; }
        public required int KundeId { get; set; }
    }
    public class User {
        public int UserId { get; set; }
        public required string Name { get; set; }
        public required string Passwort { get; set; }
    }
}
