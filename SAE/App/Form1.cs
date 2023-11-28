namespace App {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            this.feed = new WebcamFeed(pbWebcamOutput);
        }

        private WebcamFeed feed;

        private void Form1_Load(object sender, EventArgs e) {
            // TODO: Produkttypen aus Datenbank lesen und in die Dropdowns einfügen
            cbProduktgruppen1.DataSource = new String[] { "Datenbank nicht erreichbar" };
            cbProduktgruppen2.DataSource = new String[] { "Datenbank nicht erreichbar" };
            cbProduktgruppen3.DataSource = new String[] { "Datenbank nicht erreichbar" };
        }

        private void cbFirmenvertreter_CheckedChanged(object sender, EventArgs e) {
            bool check = cbFirmenvertreter.Checked;
            lbFirma.Visible = check;
            tbFirma.Visible = check;
            CheckFinishConditions();
        }

        private void bWebcamStarten_Click(object sender, EventArgs e) {
            feed.Start();
            bBildAufnehmen.Visible = true;
            bWebcamStarten.Enabled = false;
            CheckFinishConditions();
        }

        private void bBildAufnehmen_Click(object sender, EventArgs e) {
            feed.StopFeed();
            bBildAufnehmen.Enabled = false;
            bNeuesBildAufnehmen.Visible = true;
            bNeuesBildAufnehmen.Enabled = true;
            CheckFinishConditions();
        }

        private void bNeuesBildAufnehmen_Click(object sender, EventArgs e) {
            feed.Start();
            bNeuesBildAufnehmen.Enabled = false;
            bBildAufnehmen.Enabled = true;
            CheckFinishConditions();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            feed.StopFeed();
        }

        private void CheckFinishConditions() {
            bool[] conditions = {
                tbName.Text != "",
                tbVorname.Text != "",
                tbStrasse.Text != "",
                tbNummer.Text != "",
            };
            bAusweisErstellen.Enabled = conditions.All(cond => cond);
        }
    }
}