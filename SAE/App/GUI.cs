
using Database;
using MesseContextNamespace;
using System.Text.RegularExpressions;

namespace App {
    public partial class GUI : Form {
        public GUI() {
            this.InitializeComponent();
            this.webcamFeed = new WebcamFeed(this.pbWebcamOutput);
            this.db = new MesseContext();
        }

        private WebcamFeed webcamFeed;
        private MesseContext db;

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

        private void tbPLZ_TextChanged(object sender, EventArgs e) {
            this.tbPLZ.Text = Regex.Replace(this.tbPLZ.Text, @"[^\d]", "");
            if (this.tbPLZ.Text.Length > 5) {
                this.tbPLZ.Text = this.tbPLZ.Text.Substring(0, 5);
            }
            this.tbPLZ.SelectionStart = this.tbPLZ.Text.Length;
            this.tbPLZ.SelectionLength = 0;
        }

        private void cbFirmenvertreter_CheckedChanged(object sender, EventArgs e) {
            bool check = this.cbFirmenvertreter.Checked;
            this.lbFirma.Visible = check;
            this.tbFirma.Visible = check;
            this.CheckFinishConditions();
        }

        private void bWebcamStarten_Click(object sender, EventArgs e) {
            this.webcamFeed.Start();
            this.bBildAufnehmen.Visible = true;
            this.bWebcamStarten.Enabled = false;
            this.CheckFinishConditions();
        }

        private void bBildAufnehmen_Click(object sender, EventArgs e) {
            this.webcamFeed.StopFeed();
            this.bBildAufnehmen.Enabled = false;
            this.bNeuesBildAufnehmen.Visible = true;
            this.bNeuesBildAufnehmen.Enabled = true;
            this.CheckFinishConditions();
        }

        private void bNeuesBildAufnehmen_Click(object sender, EventArgs e) {
            this.webcamFeed.Start();
            this.bNeuesBildAufnehmen.Enabled = false;
            this.bBildAufnehmen.Enabled = true;
            this.CheckFinishConditions();
        }

        private void bAusweisErstellen_Click(object sender, EventArgs e) {
            Firma? firma = null;
            if (this.cbFirmenvertreter.Checked) {
                firma = this.db.UpsertFirma(new Firma { Name = this.tbFirma.Text });
            }
            // TODO: Standard Foto entfernen
            Kunde kunde = new Kunde {
                Vorname = this.tbVorname.Text,
                Nachname = this.tbName.Text,
                PLZ = int.Parse(this.tbPLZ.Text),
                Ort = this.tbOrt.Text,
                Strasse = this.tbStrasse.Text,
                Hausnummer = this.tbNr.Text,
                Foto = "", // FotoToBase64(pbWebcamOutput.Image),
                Firmenvertreter = this.cbFirmenvertreter.Checked
            };
            if (firma != null) {
                kunde.FirmaId = firma.FirmaId;
            }
            kunde = this.db.UpsertKunde(kunde);

            Produktgruppe[] ausgewaehlteProduktgruppen = this.GewaehlteProduktgruppenUmwandeln();
            this.db.UpsertRelationKundeProduktgruppe(kunde, ausgewaehlteProduktgruppen);
            MessageBox.Show("Ihr Kundenausweis wurde erfolreich erstellt");
            this.ResetForm();
        }

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

        private string FotoToBase64(Image foto) {
            ImageConverter converter = new ImageConverter();
            byte[] fotoByteArray = (byte[])converter.ConvertTo(foto, typeof(byte[]));
            return Convert.ToBase64String(fotoByteArray);
        }

        private void CheckFinishConditions() {
            bool[] conditions = {
                this.tbName.Text != "",
                this.tbVorname.Text != "",
                this.tbPLZ.Text != "",
                this.tbOrt.Text != "",
                (this.cbFirmenvertreter.Checked && this.tbFirma.Text != "") || !this.cbFirmenvertreter.Checked,
                // TODO: wieder keinkommentieren im Release
                //pbWebcamOutput.Image != null,
            };
            this.bAusweisErstellen.Enabled = conditions.All(cond => cond);
        }
    }
}