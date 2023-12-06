using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Firmen",
                columns: table => new
                {
                    FirmaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firmen", x => x.FirmaId);
                });

            migrationBuilder.CreateTable(
                name: "Kunden",
                columns: table => new
                {
                    KundeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Vorname = table.Column<string>(type: "TEXT", nullable: false),
                    Nachname = table.Column<string>(type: "TEXT", nullable: false),
                    PLZ = table.Column<int>(type: "INTEGER", nullable: false),
                    Ort = table.Column<string>(type: "TEXT", nullable: false),
                    Strasse = table.Column<string>(type: "TEXT", nullable: false),
                    Hausnummer = table.Column<string>(type: "TEXT", nullable: false),
                    Foto = table.Column<string>(type: "TEXT", nullable: false),
                    Firmenvertreter = table.Column<string>(type: "TEXT", nullable: false),
                    FirmaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunden", x => x.KundeId);
                });

            migrationBuilder.CreateTable(
                name: "Produktgruppe",
                columns: table => new
                {
                    ProduktgruppeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produktgruppe", x => x.ProduktgruppeId);
                });

            migrationBuilder.CreateTable(
                name: "ProduktgruppeKunden",
                columns: table => new
                {
                    ProduktgruppeKundeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProduktgruppeId = table.Column<int>(type: "INTEGER", nullable: false),
                    KundeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduktgruppeKunden", x => x.ProduktgruppeKundeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Passwort = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Firmen");

            migrationBuilder.DropTable(
                name: "Kunden");

            migrationBuilder.DropTable(
                name: "Produktgruppe");

            migrationBuilder.DropTable(
                name: "ProduktgruppeKunden");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
