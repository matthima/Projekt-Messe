namespace App {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            tlpMainFrame = new TableLayoutPanel();
            flpWebcamPanel = new FlowLayoutPanel();
            bWebcamStarten = new Button();
            pbWebcamOutput = new PictureBox();
            flpFotoButtons = new FlowLayoutPanel();
            bBildAufnehmen = new Button();
            bNeuesBildAufnehmen = new Button();
            flpProduktgruppen = new FlowLayoutPanel();
            lbProduktgruppen = new Label();
            flpProduktgruppenDropdowns = new FlowLayoutPanel();
            cbProduktgruppen1 = new ComboBox();
            cbProduktgruppen2 = new ComboBox();
            cbProduktgruppen3 = new ComboBox();
            button1 = new Button();
            flpFirma = new FlowLayoutPanel();
            cbFirmenvertreter = new CheckBox();
            lbFirma = new Label();
            tbFirma = new TextBox();
            flpStammdaten = new FlowLayoutPanel();
            lbName = new Label();
            tbName = new TextBox();
            lbVorname = new Label();
            tbVorname = new TextBox();
            flpStrasseNrLabels = new FlowLayoutPanel();
            lbStrasse = new Label();
            lbHausnummer = new Label();
            flptStrasseNrTextbox = new FlowLayoutPanel();
            tbStrasse = new TextBox();
            tbNummer = new TextBox();
            label1 = new Label();
            ttFirmenvertreter = new ToolTip(components);
            tlpMainFrame.SuspendLayout();
            flpWebcamPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbWebcamOutput).BeginInit();
            flpFotoButtons.SuspendLayout();
            flpProduktgruppen.SuspendLayout();
            flpProduktgruppenDropdowns.SuspendLayout();
            flpFirma.SuspendLayout();
            flpStammdaten.SuspendLayout();
            flpStrasseNrLabels.SuspendLayout();
            flptStrasseNrTextbox.SuspendLayout();
            SuspendLayout();
            // 
            // tlpMainFrame
            // 
            tlpMainFrame.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlpMainFrame.ColumnCount = 2;
            tlpMainFrame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpMainFrame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpMainFrame.Controls.Add(flpWebcamPanel, 1, 0);
            tlpMainFrame.Controls.Add(flpProduktgruppen, 0, 4);
            tlpMainFrame.Controls.Add(flpFirma, 0, 2);
            tlpMainFrame.Controls.Add(flpStammdaten, 0, 0);
            tlpMainFrame.Location = new Point(0, 50);
            tlpMainFrame.Name = "tlpMainFrame";
            tlpMainFrame.RowCount = 5;
            tlpMainFrame.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpMainFrame.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpMainFrame.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpMainFrame.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpMainFrame.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpMainFrame.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpMainFrame.Size = new Size(1183, 660);
            tlpMainFrame.TabIndex = 0;
            // 
            // flpWebcamPanel
            // 
            flpWebcamPanel.Controls.Add(bWebcamStarten);
            flpWebcamPanel.Controls.Add(pbWebcamOutput);
            flpWebcamPanel.Controls.Add(flpFotoButtons);
            flpWebcamPanel.Dock = DockStyle.Fill;
            flpWebcamPanel.FlowDirection = FlowDirection.TopDown;
            flpWebcamPanel.Location = new Point(592, 4);
            flpWebcamPanel.Margin = new Padding(0, 3, 3, 3);
            flpWebcamPanel.Name = "flpWebcamPanel";
            tlpMainFrame.SetRowSpan(flpWebcamPanel, 4);
            flpWebcamPanel.Size = new Size(587, 517);
            flpWebcamPanel.TabIndex = 3;
            // 
            // bWebcamStarten
            // 
            bWebcamStarten.Location = new Point(3, 3);
            bWebcamStarten.Name = "bWebcamStarten";
            bWebcamStarten.Size = new Size(124, 23);
            bWebcamStarten.TabIndex = 0;
            bWebcamStarten.Text = "Webcam starten";
            bWebcamStarten.UseVisualStyleBackColor = true;
            // 
            // pbWebcamOutput
            // 
            pbWebcamOutput.BorderStyle = BorderStyle.FixedSingle;
            pbWebcamOutput.Location = new Point(3, 32);
            pbWebcamOutput.Name = "pbWebcamOutput";
            pbWebcamOutput.Size = new Size(574, 448);
            pbWebcamOutput.TabIndex = 1;
            pbWebcamOutput.TabStop = false;
            // 
            // flpFotoButtons
            // 
            flpFotoButtons.Controls.Add(bBildAufnehmen);
            flpFotoButtons.Controls.Add(bNeuesBildAufnehmen);
            flpFotoButtons.Location = new Point(3, 486);
            flpFotoButtons.Name = "flpFotoButtons";
            flpFotoButtons.Size = new Size(574, 27);
            flpFotoButtons.TabIndex = 2;
            // 
            // bBildAufnehmen
            // 
            bBildAufnehmen.Location = new Point(3, 3);
            bBildAufnehmen.Margin = new Padding(3, 3, 295, 3);
            bBildAufnehmen.Name = "bBildAufnehmen";
            bBildAufnehmen.Size = new Size(120, 23);
            bBildAufnehmen.TabIndex = 0;
            bBildAufnehmen.Text = "Bild aufnehmen";
            bBildAufnehmen.UseVisualStyleBackColor = true;
            // 
            // bNeuesBildAufnehmen
            // 
            bNeuesBildAufnehmen.Location = new Point(421, 3);
            bNeuesBildAufnehmen.Name = "bNeuesBildAufnehmen";
            bNeuesBildAufnehmen.Size = new Size(150, 23);
            bNeuesBildAufnehmen.TabIndex = 1;
            bNeuesBildAufnehmen.Text = "Neues Bild aufnehmen";
            bNeuesBildAufnehmen.UseVisualStyleBackColor = true;
            // 
            // flpProduktgruppen
            // 
            tlpMainFrame.SetColumnSpan(flpProduktgruppen, 2);
            flpProduktgruppen.Controls.Add(lbProduktgruppen);
            flpProduktgruppen.Controls.Add(flpProduktgruppenDropdowns);
            flpProduktgruppen.Controls.Add(button1);
            flpProduktgruppen.Dock = DockStyle.Fill;
            flpProduktgruppen.FlowDirection = FlowDirection.TopDown;
            flpProduktgruppen.Location = new Point(4, 525);
            flpProduktgruppen.Margin = new Padding(3, 0, 3, 3);
            flpProduktgruppen.Name = "flpProduktgruppen";
            flpProduktgruppen.Size = new Size(1175, 131);
            flpProduktgruppen.TabIndex = 2;
            // 
            // lbProduktgruppen
            // 
            lbProduktgruppen.AutoSize = true;
            lbProduktgruppen.Font = new Font("Segoe UI", 10F);
            lbProduktgruppen.Location = new Point(3, 0);
            lbProduktgruppen.Margin = new Padding(3, 0, 3, 10);
            lbProduktgruppen.Name = "lbProduktgruppen";
            lbProduktgruppen.Size = new Size(558, 19);
            lbProduktgruppen.TabIndex = 5;
            lbProduktgruppen.Text = "Wählen Sie bis zu 3 unserer Produktgruppen aus, an denen Sie besonders interessiert sind";
            // 
            // flpProduktgruppenDropdowns
            // 
            flpProduktgruppenDropdowns.Controls.Add(cbProduktgruppen1);
            flpProduktgruppenDropdowns.Controls.Add(cbProduktgruppen2);
            flpProduktgruppenDropdowns.Controls.Add(cbProduktgruppen3);
            flpProduktgruppenDropdowns.Location = new Point(3, 32);
            flpProduktgruppenDropdowns.Name = "flpProduktgruppenDropdowns";
            flpProduktgruppenDropdowns.Size = new Size(1165, 40);
            flpProduktgruppenDropdowns.TabIndex = 6;
            // 
            // cbProduktgruppen1
            // 
            cbProduktgruppen1.FormattingEnabled = true;
            cbProduktgruppen1.Location = new Point(3, 10);
            cbProduktgruppen1.Margin = new Padding(3, 10, 10, 10);
            cbProduktgruppen1.Name = "cbProduktgruppen1";
            cbProduktgruppen1.Size = new Size(225, 23);
            cbProduktgruppen1.TabIndex = 0;
            // 
            // cbProduktgruppen2
            // 
            cbProduktgruppen2.FormattingEnabled = true;
            cbProduktgruppen2.Location = new Point(248, 10);
            cbProduktgruppen2.Margin = new Padding(10);
            cbProduktgruppen2.Name = "cbProduktgruppen2";
            cbProduktgruppen2.Size = new Size(225, 23);
            cbProduktgruppen2.TabIndex = 1;
            // 
            // cbProduktgruppen3
            // 
            cbProduktgruppen3.FormattingEnabled = true;
            cbProduktgruppen3.Location = new Point(493, 10);
            cbProduktgruppen3.Margin = new Padding(10);
            cbProduktgruppen3.Name = "cbProduktgruppen3";
            cbProduktgruppen3.Size = new Size(225, 23);
            cbProduktgruppen3.TabIndex = 2;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button1.Location = new Point(985, 90);
            button1.Margin = new Padding(985, 15, 3, 3);
            button1.Name = "button1";
            button1.Size = new Size(180, 30);
            button1.TabIndex = 7;
            button1.Text = "Kundenausweis erstellen";
            button1.UseVisualStyleBackColor = true;
            // 
            // flpFirma
            // 
            flpFirma.Controls.Add(cbFirmenvertreter);
            flpFirma.Controls.Add(lbFirma);
            flpFirma.Controls.Add(tbFirma);
            flpFirma.Dock = DockStyle.Fill;
            flpFirma.FlowDirection = FlowDirection.TopDown;
            flpFirma.Location = new Point(4, 266);
            flpFirma.Name = "flpFirma";
            tlpMainFrame.SetRowSpan(flpFirma, 2);
            flpFirma.Size = new Size(584, 255);
            flpFirma.TabIndex = 1;
            // 
            // cbFirmenvertreter
            // 
            cbFirmenvertreter.AutoSize = true;
            cbFirmenvertreter.CheckAlign = ContentAlignment.MiddleRight;
            cbFirmenvertreter.Font = new Font("Segoe UI", 10F);
            cbFirmenvertreter.Location = new Point(3, 3);
            cbFirmenvertreter.Margin = new Padding(3, 3, 3, 20);
            cbFirmenvertreter.Name = "cbFirmenvertreter";
            cbFirmenvertreter.Size = new Size(135, 23);
            cbFirmenvertreter.TabIndex = 0;
            cbFirmenvertreter.Text = "Firmenvertretung";
            ttFirmenvertreter.SetToolTip(cbFirmenvertreter, "Vertreten Sie eine Firma? Tragen Sie den Haken ein, um den Namen Ihrer Firma auf Ihrem Ausweis zu vermerken.");
            cbFirmenvertreter.UseVisualStyleBackColor = true;
            // 
            // lbFirma
            // 
            lbFirma.AutoSize = true;
            lbFirma.Font = new Font("Segoe UI", 10F);
            lbFirma.Location = new Point(3, 46);
            lbFirma.Margin = new Padding(3, 0, 3, 10);
            lbFirma.Name = "lbFirma";
            lbFirma.Size = new Size(43, 19);
            lbFirma.TabIndex = 4;
            lbFirma.Text = "Firma";
            // 
            // tbFirma
            // 
            tbFirma.Location = new Point(3, 78);
            tbFirma.Margin = new Padding(3, 3, 3, 20);
            tbFirma.Name = "tbFirma";
            tbFirma.Size = new Size(225, 23);
            tbFirma.TabIndex = 5;
            // 
            // flpStammdaten
            // 
            flpStammdaten.Controls.Add(lbName);
            flpStammdaten.Controls.Add(tbName);
            flpStammdaten.Controls.Add(lbVorname);
            flpStammdaten.Controls.Add(tbVorname);
            flpStammdaten.Controls.Add(flpStrasseNrLabels);
            flpStammdaten.Controls.Add(flptStrasseNrTextbox);
            flpStammdaten.Dock = DockStyle.Fill;
            flpStammdaten.FlowDirection = FlowDirection.TopDown;
            flpStammdaten.Location = new Point(1, 4);
            flpStammdaten.Margin = new Padding(0, 3, 0, 3);
            flpStammdaten.Name = "flpStammdaten";
            tlpMainFrame.SetRowSpan(flpStammdaten, 2);
            flpStammdaten.Size = new Size(590, 255);
            flpStammdaten.TabIndex = 0;
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Font = new Font("Segoe UI", 10F);
            lbName.Location = new Point(3, 0);
            lbName.Margin = new Padding(3, 0, 3, 10);
            lbName.Name = "lbName";
            lbName.Size = new Size(45, 19);
            lbName.TabIndex = 0;
            lbName.Text = "Name";
            // 
            // tbName
            // 
            tbName.Location = new Point(3, 32);
            tbName.Margin = new Padding(3, 3, 3, 20);
            tbName.Name = "tbName";
            tbName.Size = new Size(228, 23);
            tbName.TabIndex = 1;
            // 
            // lbVorname
            // 
            lbVorname.AutoSize = true;
            lbVorname.Font = new Font("Segoe UI", 10F);
            lbVorname.Location = new Point(3, 75);
            lbVorname.Margin = new Padding(3, 0, 3, 10);
            lbVorname.Name = "lbVorname";
            lbVorname.Size = new Size(64, 19);
            lbVorname.TabIndex = 2;
            lbVorname.Text = "Vorname";
            // 
            // tbVorname
            // 
            tbVorname.Location = new Point(3, 107);
            tbVorname.Margin = new Padding(3, 3, 3, 20);
            tbVorname.Name = "tbVorname";
            tbVorname.Size = new Size(228, 23);
            tbVorname.TabIndex = 3;
            // 
            // flpStrasseNrLabels
            // 
            flpStrasseNrLabels.Controls.Add(lbStrasse);
            flpStrasseNrLabels.Controls.Add(lbHausnummer);
            flpStrasseNrLabels.Dock = DockStyle.Left;
            flpStrasseNrLabels.Location = new Point(0, 150);
            flpStrasseNrLabels.Margin = new Padding(0);
            flpStrasseNrLabels.Name = "flpStrasseNrLabels";
            flpStrasseNrLabels.Size = new Size(585, 30);
            flpStrasseNrLabels.TabIndex = 4;
            // 
            // lbStrasse
            // 
            lbStrasse.AutoSize = true;
            lbStrasse.Font = new Font("Segoe UI", 10F);
            lbStrasse.Location = new Point(3, 0);
            lbStrasse.Margin = new Padding(3, 0, 200, 0);
            lbStrasse.Name = "lbStrasse";
            lbStrasse.Size = new Size(48, 19);
            lbStrasse.TabIndex = 3;
            lbStrasse.Text = "Straße";
            // 
            // lbHausnummer
            // 
            lbHausnummer.AutoSize = true;
            lbHausnummer.Font = new Font("Segoe UI", 10F);
            lbHausnummer.Location = new Point(254, 0);
            lbHausnummer.Name = "lbHausnummer";
            lbHausnummer.Size = new Size(27, 19);
            lbHausnummer.TabIndex = 4;
            lbHausnummer.Text = "Nr.";
            // 
            // flptStrasseNrTextbox
            // 
            flptStrasseNrTextbox.Controls.Add(tbStrasse);
            flptStrasseNrTextbox.Controls.Add(tbNummer);
            flptStrasseNrTextbox.Dock = DockStyle.Left;
            flptStrasseNrTextbox.Location = new Point(3, 180);
            flptStrasseNrTextbox.Margin = new Padding(3, 0, 0, 10);
            flptStrasseNrTextbox.Name = "flptStrasseNrTextbox";
            flptStrasseNrTextbox.Size = new Size(585, 35);
            flptStrasseNrTextbox.TabIndex = 5;
            // 
            // tbStrasse
            // 
            tbStrasse.Location = new Point(3, 3);
            tbStrasse.Margin = new Padding(3, 3, 25, 3);
            tbStrasse.Name = "tbStrasse";
            tbStrasse.Size = new Size(225, 23);
            tbStrasse.TabIndex = 0;
            // 
            // tbNummer
            // 
            tbNummer.Location = new Point(256, 3);
            tbNummer.Name = "tbNummer";
            tbNummer.Size = new Size(136, 23);
            tbNummer.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            label1.Location = new Point(0, 3);
            label1.Name = "label1";
            label1.Size = new Size(388, 41);
            label1.TabIndex = 1;
            label1.Text = "Kundenausweis-Generator";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 711);
            Controls.Add(label1);
            Controls.Add(tlpMainFrame);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            ImeMode = ImeMode.Off;
            MaximumSize = new Size(1200, 750);
            MinimumSize = new Size(1200, 750);
            Name = "Form1";
            Text = "Kundenausweis-Generator";
            tlpMainFrame.ResumeLayout(false);
            flpWebcamPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbWebcamOutput).EndInit();
            flpFotoButtons.ResumeLayout(false);
            flpProduktgruppen.ResumeLayout(false);
            flpProduktgruppen.PerformLayout();
            flpProduktgruppenDropdowns.ResumeLayout(false);
            flpFirma.ResumeLayout(false);
            flpFirma.PerformLayout();
            flpStammdaten.ResumeLayout(false);
            flpStammdaten.PerformLayout();
            flpStrasseNrLabels.ResumeLayout(false);
            flpStrasseNrLabels.PerformLayout();
            flptStrasseNrTextbox.ResumeLayout(false);
            flptStrasseNrTextbox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TableLayoutPanel tlpMainFrame;
        private FlowLayoutPanel flpWebcamPanel;
        private Button bWebcamStarten;
        private PictureBox pbWebcamOutput;
        private FlowLayoutPanel flpFotoButtons;
        private Button bBildAufnehmen;
        private Button bNeuesBildAufnehmen;
        private FlowLayoutPanel flpProduktgruppen;
        private Label lbProduktgruppen;
        private FlowLayoutPanel flpProduktgruppenDropdowns;
        private ComboBox cbProduktgruppen1;
        private ComboBox cbProduktgruppen2;
        private ComboBox cbProduktgruppen3;
        private FlowLayoutPanel flpStammdaten;
        private Label lbName;
        private TextBox tbName;
        private Label lbVorname;
        private TextBox tbVorname;
        private FlowLayoutPanel flpStrasseNrLabels;
        private Label lbStrasse;
        private Label lbHausnummer;
        private FlowLayoutPanel flptStrasseNrTextbox;
        private TextBox tbStrasse;
        private TextBox tbNummer;
        private CheckBox cbFirmenvertreter;
        private TextBox tbFirma;
        private Label lbFirma;
        private FlowLayoutPanel flpFirma;
        private Button button1;
        private Label label1;
        private ToolTip ttFirmenvertreter;
    }
}