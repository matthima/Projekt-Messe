
using Database;
using MesseContextNamespace;
using System.Text.RegularExpressions;

namespace App {
    public partial class GUI : Form {
        private WebcamFeed webcamFeed;
        private MesseContext db;

        public GUI() {
            this.InitializeComponent();
            this.webcamFeed = new WebcamFeed(this.pbWebcamOutput);
            this.db = new MesseContext();
        }


        // Fetches _Produktgruppe_n from local DB and populates the dropdowns in the GUI
        private void GUI_Load(object sender, EventArgs e) {
            string[] produktgruppen1 = this.db.GetProduktgruppenOrderedByName().Select(p => p.Name).ToArray();
            if (produktgruppen1.Length == 0) {
                produktgruppen1 = new string[] { "Datenbank nicht erreichbar, bitte wenden Sie sich an einen Kundenbetreuer" };
            }
            this.cbProduktgruppen1.DataSource = produktgruppen1;

            string[] produktgruppen2 = this.db.GetProduktgruppenOrderedByName().Select(p => p.Name).ToArray();
            if (produktgruppen2.Length == 0) {
                produktgruppen2 = new string[] { "Datenbank nicht erreichbar, bitte wenden Sie sich an einen Kundenbetreuer" };
            }
            this.cbProduktgruppen2.DataSource = produktgruppen2;

            string[] produktgruppen3 = this.db.GetProduktgruppenOrderedByName().Select(p => p.Name).ToArray();
            if (produktgruppen3.Length == 0) {
                produktgruppen3 = new string[] { "Datenbank nicht erreichbar, bitte wenden Sie sich an einen Kundenbetreuer" };
            }
            this.cbProduktgruppen3.DataSource = produktgruppen3;
        }

        // Restricts _tbPLZ_'s value to numbers and max length 5
        private void tbPLZ_TextChanged(object sender, EventArgs e) {
            this.tbPLZ.Text = Regex.Replace(this.tbPLZ.Text, @"[^\d]", "");
            if (this.tbPLZ.Text.Length > 5) {
                this.tbPLZ.Text = this.tbPLZ.Text[..5];
            }
            this.tbPLZ.SelectionStart = this.tbPLZ.Text.Length;
            this.tbPLZ.SelectionLength = 0;
        }

        // Shows/hides the elements needed for _Firmenvertreter_
        private void cbFirmenvertreter_CheckedChanged(object sender, EventArgs e) {
            bool check = this.cbFirmenvertreter.Checked;
            this.lbFirma.Visible = check;
            this.tbFirma.Visible = check;
            this.CheckFinishConditions();
        }

        // Starts the _WebcamFeed_
        private void bWebcamStarten_Click(object sender, EventArgs e) {
            this.webcamFeed.Start();
            this.bBildAufnehmen.Visible = true;
            this.bWebcamStarten.Enabled = false;
            this.CheckFinishConditions();
        }

        // Stops the feed and keeps the last frame in the preview
        private void bBildAufnehmen_Click(object sender, EventArgs e) {
            this.webcamFeed.StopFeed();
            this.bBildAufnehmen.Enabled = false;
            this.bNeuesBildAufnehmen.Visible = true;
            this.bNeuesBildAufnehmen.Enabled = true;
            this.CheckFinishConditions();
        }

        // Starts the _WebcamFeed_, allowing the user to retake their picture
        private void bNeuesBildAufnehmen_Click(object sender, EventArgs e) {
            this.webcamFeed.Start();
            this.bNeuesBildAufnehmen.Enabled = false;
            this.bBildAufnehmen.Enabled = true;
            this.CheckFinishConditions();
        }

        // Generates the DB objects based on the user's input and pushes them.
        private void bAusweisErstellen_Click(object sender, EventArgs e) {
            Firma? firma = null;
            if (this.cbFirmenvertreter.Checked) {
                firma = this.db.UpsertFirma(new Firma { Name = this.tbFirma.Text });
            }
            Kunde kunde = new Kunde {
                Vorname = this.tbVorname.Text,
                Nachname = this.tbName.Text,
                PLZ = int.Parse(this.tbPLZ.Text),
                Ort = this.tbOrt.Text,
                Strasse = this.tbStrasse.Text,
                Hausnummer = this.tbNr.Text,
                Foto = FotoToBase64(this.pbWebcamOutput.Image),
                Firmenvertreter = this.cbFirmenvertreter.Checked
            };
            if (firma != null) {
                kunde.FirmaId = firma.FirmaId;
            }
            kunde = this.db.UpsertKunde(kunde);

            Produktgruppe[] ausgewaehlteProduktgruppen = this.GewaehlteProduktgruppenUmwandeln();
            this.db.UpsertRelationKundeProduktgruppe(kunde, ausgewaehlteProduktgruppen);
            MessageBox.Show("Ihr Kundenausweis wurde erfolgreich erstellt");
            this.ResetForm();
        }

        // Converts the string representations of _Produktgruppe_n to their corresponding object in the DB
        private Produktgruppe[] GewaehlteProduktgruppenUmwandeln() {
            string[] gewaehlteProduktgruppenStrings = new string[] { this.cbProduktgruppen1.Text, this.cbProduktgruppen2.Text, this.cbProduktgruppen3.Text };
            Produktgruppe[] gewaehlteProduktgruppen = gewaehlteProduktgruppenStrings.Select(produktgruppe => this.db.GetProduktgruppeByName(produktgruppe)).ToArray();
            return gewaehlteProduktgruppen;
        }

        private void ResetForm() {
            this.webcamFeed.StopFeed();
            this.tbName.Text = "";
            this.tbVorname.Text = "";
            this.tbPLZ.Text = "";
            this.tbOrt.Text = "";
            this.tbStrasse.Text = "";
            this.tbNr.Text = "";
            this.tbFirma.Text = "";
            this.cbFirmenvertreter.Checked = false;
            this.pbWebcamOutput.Image = null;
            this.bNeuesBildAufnehmen.Visible = false;
            this.bBildAufnehmen.Visible = false;
            this.bWebcamStarten.Enabled = true;
        }

        private void GUI_FormClosed(object sender, FormClosedEventArgs e) {
            this.webcamFeed.StopFeed();
        }

        // Converts the image to a base64 string, allowing it to be saved as a field in the DB
        private static string FotoToBase64(Image foto) {
            ImageConverter converter = new ImageConverter();
            byte[] fotoByteArray = (byte[])converter.ConvertTo(foto, typeof(byte[]));
            return Convert.ToBase64String(fotoByteArray);
        }

        // Checks if all conditions for finishing are completed and enables/disables the "finish" button
        private void CheckFinishConditions() {
            bool[] conditions = {
                this.tbName.Text != "",
                this.tbVorname.Text != "",
                this.tbPLZ.Text != "",
                this.tbOrt.Text != "",
                (this.cbFirmenvertreter.Checked && this.tbFirma.Text != "") || !this.cbFirmenvertreter.Checked,
                this.pbWebcamOutput.Image != null,
            };
            this.bAusweisErstellen.Enabled = conditions.All(cond => cond);
        }
    }
}