
using Database;
using MesseContextNamespace;
using System.Text.RegularExpressions;

namespace App {
    public partial class GUI : Form {
        public GUI() {
            InitializeComponent();
            this.webcamFeed = new WebcamFeed(pbWebcamOutput);
            this.db = new MesseContext();
        }

        private WebcamFeed webcamFeed;
        private MesseContext db;

        private void GUI_Load(object sender, EventArgs e) {
            string[] produktgruppen1 = db.GetProduktgruppenOrderedByName().Select(p => p.Name).ToArray();
            if (produktgruppen1.Length == 0) {
                produktgruppen1 = new string[] { "Datenbank nicht erreichbar, bitte wenden Sie sich an einen Kundenbetreuer" };
            }
            cbProduktgruppen1.DataSource = produktgruppen1;

            string[] produktgruppen2 = db.GetProduktgruppenOrderedByName().Select(p => p.Name).ToArray();
            if (produktgruppen2.Length == 0) {
                produktgruppen2 = new string[] { "Datenbank nicht erreichbar, bitte wenden Sie sich an einen Kundenbetreuer" };
            }
            cbProduktgruppen2.DataSource = produktgruppen2;

            string[] produktgruppen3 = db.GetProduktgruppenOrderedByName().Select(p => p.Name).ToArray();
            if (produktgruppen3.Length == 0) {
                produktgruppen3 = new string[] { "Datenbank nicht erreichbar, bitte wenden Sie sich an einen Kundenbetreuer" };
            }
            cbProduktgruppen3.DataSource = produktgruppen3;
        }

        private void tbPLZ_TextChanged(object sender, EventArgs e) {
            tbPLZ.Text = Regex.Replace(tbPLZ.Text, @"[^\d]", "");
            if (tbPLZ.Text.Length > 5) {
                tbPLZ.Text = tbPLZ.Text.Substring(0, 5);
            }
            tbPLZ.SelectionStart = tbPLZ.Text.Length;
            tbPLZ.SelectionLength = 0;
        }

        private void cbFirmenvertreter_CheckedChanged(object sender, EventArgs e) {
            bool check = cbFirmenvertreter.Checked;
            lbFirma.Visible = check;
            tbFirma.Visible = check;
            CheckFinishConditions();
        }

        private void bWebcamStarten_Click(object sender, EventArgs e) {
            webcamFeed.Start();
            bBildAufnehmen.Visible = true;
            bWebcamStarten.Enabled = false;
            CheckFinishConditions();
        }

        private void bBildAufnehmen_Click(object sender, EventArgs e) {
            webcamFeed.StopFeed();
            bBildAufnehmen.Enabled = false;
            bNeuesBildAufnehmen.Visible = true;
            bNeuesBildAufnehmen.Enabled = true;
            CheckFinishConditions();
        }

        private void bNeuesBildAufnehmen_Click(object sender, EventArgs e) {
            webcamFeed.Start();
            bNeuesBildAufnehmen.Enabled = false;
            bBildAufnehmen.Enabled = true;
            CheckFinishConditions();
        }

        private void bAusweisErstellen_Click(object sender, EventArgs e) {
            Firma? firma = null;
            if (cbFirmenvertreter.Checked) {
                firma = db.UpsertFirma(new Firma { Name = tbFirma.Text });
            }
            // TODO: Standard Foto entfernen
            Kunde kunde = new Kunde {
                Vorname = tbVorname.Text,
                Nachname = tbName.Text,
                PLZ = int.Parse(tbPLZ.Text),
                Ort = tbOrt.Text,
                Strasse = tbStrasse.Text,
                Hausnummer = tbNr.Text,
                Foto = "", // FotoToBase64(pbWebcamOutput.Image),
                Firmenvertreter = cbFirmenvertreter.Checked
            };
            if (firma != null) {
                kunde.FirmaId = firma.FirmaId;
            }
            kunde = db.UpsertKunde(kunde);

            Produktgruppe[] ausgewaehlteProduktgruppen = GewaehlteProduktgruppenUmwandeln();
            db.UpsertRelationKundeProduktgruppe(kunde, ausgewaehlteProduktgruppen);
            MessageBox.Show("Ihr Kundenausweis wurde erfolreich erstellt");
            ResetForm();
        }

        private Produktgruppe[] GewaehlteProduktgruppenUmwandeln() {
            string[] gewaehlteProduktgruppenStrings = new string[] { cbProduktgruppen1.Text, cbProduktgruppen2.Text, cbProduktgruppen3.Text };
            Produktgruppe[] gewaehlteProduktgruppen = gewaehlteProduktgruppenStrings.Select(produktgruppe => db.GetProduktgruppeByName(produktgruppe)).ToArray();
            return gewaehlteProduktgruppen;
        }

        private void ResetForm() {
            webcamFeed.StopFeed();
            tbName.Text = "";
            tbVorname.Text = "";
            tbPLZ.Text = "";
            tbOrt.Text = "";
            tbStrasse.Text = "";
            tbNr.Text = "";
            tbFirma.Text = "";
            cbFirmenvertreter.Checked = false;
            pbWebcamOutput.Image = null;
            bNeuesBildAufnehmen.Visible = false;
            bBildAufnehmen.Visible = false;
            bWebcamStarten.Enabled = true;
        }

        private void GUI_FormClosed(object sender, FormClosedEventArgs e) {
            webcamFeed.StopFeed();
        }

        private string FotoToBase64(Image foto) {
            ImageConverter converter = new ImageConverter();
            byte[] fotoByteArray = (byte[])converter.ConvertTo(foto, typeof(byte[]));
            return Convert.ToBase64String(fotoByteArray);
        }

        private void CheckFinishConditions() {
            bool[] conditions = {
                tbName.Text != "",
                tbVorname.Text != "",
                tbPLZ.Text != "",
                tbOrt.Text != "",
                (cbFirmenvertreter.Checked && tbFirma.Text != "") || !cbFirmenvertreter.Checked,
                // TODO: wieder keinkommentieren im Release
                //pbWebcamOutput.Image != null,
            };
            bAusweisErstellen.Enabled = conditions.All(cond => cond);
        }
    }
}