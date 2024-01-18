namespace App {
    partial class GUI {
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
            this.components = new System.ComponentModel.Container();
            this.tlpMainFrame = new TableLayoutPanel();
            this.flpWebcamPanel = new FlowLayoutPanel();
            this.bWebcamStarten = new Button();
            this.pbWebcamOutput = new PictureBox();
            this.flpFotoButtons = new FlowLayoutPanel();
            this.bBildAufnehmen = new Button();
            this.bNeuesBildAufnehmen = new Button();
            this.flpProduktgruppen = new FlowLayoutPanel();
            this.lbProduktgruppen = new Label();
            this.flpProduktgruppenDropdowns = new FlowLayoutPanel();
            this.cbProduktgruppen1 = new ComboBox();
            this.cbProduktgruppen2 = new ComboBox();
            this.cbProduktgruppen3 = new ComboBox();
            this.bAusweisErstellen = new Button();
            this.flpFirma = new FlowLayoutPanel();
            this.cbFirmenvertreter = new CheckBox();
            this.lbFirma = new Label();
            this.tbFirma = new TextBox();
            this.flpStammdaten = new FlowLayoutPanel();
            this.lbName = new Label();
            this.tbName = new TextBox();
            this.lbVorname = new Label();
            this.tbVorname = new TextBox();
            this.flpStrasseNrLabels = new FlowLayoutPanel();
            this.lbPLZ = new Label();
            this.lbOrt = new Label();
            this.flptStrasseNrTextbox = new FlowLayoutPanel();
            this.tbPLZ = new TextBox();
            this.tbOrt = new TextBox();
            this.flowLayoutPanel1 = new FlowLayoutPanel();
            this.lbStrasse = new Label();
            this.lbNr = new Label();
            this.flowLayoutPanel2 = new FlowLayoutPanel();
            this.tbStrasse = new TextBox();
            this.tbNr = new TextBox();
            this.label1 = new Label();
            this.ttFirmenvertreter = new ToolTip(this.components);
            this.tlpMainFrame.SuspendLayout();
            this.flpWebcamPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.pbWebcamOutput).BeginInit();
            this.flpFotoButtons.SuspendLayout();
            this.flpProduktgruppen.SuspendLayout();
            this.flpProduktgruppenDropdowns.SuspendLayout();
            this.flpFirma.SuspendLayout();
            this.flpStammdaten.SuspendLayout();
            this.flpStrasseNrLabels.SuspendLayout();
            this.flptStrasseNrTextbox.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMainFrame
            // 
            this.tlpMainFrame.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            this.tlpMainFrame.ColumnCount = 2;
            this.tlpMainFrame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tlpMainFrame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tlpMainFrame.Controls.Add(this.flpWebcamPanel, 1, 0);
            this.tlpMainFrame.Controls.Add(this.flpProduktgruppen, 0, 4);
            this.tlpMainFrame.Controls.Add(this.flpFirma, 0, 3);
            this.tlpMainFrame.Controls.Add(this.flpStammdaten, 0, 0);
            this.tlpMainFrame.Location = new Point(0, 50);
            this.tlpMainFrame.Name = "tlpMainFrame";
            this.tlpMainFrame.RowCount = 5;
            this.tlpMainFrame.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            this.tlpMainFrame.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            this.tlpMainFrame.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            this.tlpMainFrame.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            this.tlpMainFrame.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            this.tlpMainFrame.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            this.tlpMainFrame.Size = new Size(1183, 660);
            this.tlpMainFrame.TabIndex = 0;
            // 
            // flpWebcamPanel
            // 
            this.flpWebcamPanel.Controls.Add(this.bWebcamStarten);
            this.flpWebcamPanel.Controls.Add(this.pbWebcamOutput);
            this.flpWebcamPanel.Controls.Add(this.flpFotoButtons);
            this.flpWebcamPanel.Dock = DockStyle.Fill;
            this.flpWebcamPanel.FlowDirection = FlowDirection.TopDown;
            this.flpWebcamPanel.Location = new Point(592, 4);
            this.flpWebcamPanel.Margin = new Padding(0, 3, 3, 3);
            this.flpWebcamPanel.Name = "flpWebcamPanel";
            this.tlpMainFrame.SetRowSpan(this.flpWebcamPanel, 4);
            this.flpWebcamPanel.Size = new Size(587, 517);
            this.flpWebcamPanel.TabIndex = 3;
            // 
            // bWebcamStarten
            // 
            this.bWebcamStarten.Location = new Point(3, 3);
            this.bWebcamStarten.Name = "bWebcamStarten";
            this.bWebcamStarten.Size = new Size(124, 23);
            this.bWebcamStarten.TabIndex = 0;
            this.bWebcamStarten.Text = "Webcam starten";
            this.bWebcamStarten.UseVisualStyleBackColor = true;
            this.bWebcamStarten.Click += this.bWebcamStarten_Click;
            // 
            // pbWebcamOutput
            // 
            this.pbWebcamOutput.BorderStyle = BorderStyle.FixedSingle;
            this.pbWebcamOutput.Location = new Point(3, 32);
            this.pbWebcamOutput.Name = "pbWebcamOutput";
            this.pbWebcamOutput.Size = new Size(574, 448);
            this.pbWebcamOutput.SizeMode = PictureBoxSizeMode.Zoom;
            this.pbWebcamOutput.TabIndex = 1;
            this.pbWebcamOutput.TabStop = false;
            // 
            // flpFotoButtons
            // 
            this.flpFotoButtons.Controls.Add(this.bBildAufnehmen);
            this.flpFotoButtons.Controls.Add(this.bNeuesBildAufnehmen);
            this.flpFotoButtons.Location = new Point(3, 486);
            this.flpFotoButtons.Name = "flpFotoButtons";
            this.flpFotoButtons.Size = new Size(574, 27);
            this.flpFotoButtons.TabIndex = 2;
            // 
            // bBildAufnehmen
            // 
            this.bBildAufnehmen.Location = new Point(3, 3);
            this.bBildAufnehmen.Margin = new Padding(3, 3, 295, 3);
            this.bBildAufnehmen.Name = "bBildAufnehmen";
            this.bBildAufnehmen.Size = new Size(120, 23);
            this.bBildAufnehmen.TabIndex = 0;
            this.bBildAufnehmen.Text = "Bild aufnehmen";
            this.bBildAufnehmen.UseVisualStyleBackColor = true;
            this.bBildAufnehmen.Visible = false;
            this.bBildAufnehmen.Click += this.bBildAufnehmen_Click;
            // 
            // bNeuesBildAufnehmen
            // 
            this.bNeuesBildAufnehmen.Location = new Point(421, 3);
            this.bNeuesBildAufnehmen.Name = "bNeuesBildAufnehmen";
            this.bNeuesBildAufnehmen.Size = new Size(150, 23);
            this.bNeuesBildAufnehmen.TabIndex = 1;
            this.bNeuesBildAufnehmen.Text = "Neues Bild aufnehmen";
            this.bNeuesBildAufnehmen.UseVisualStyleBackColor = true;
            this.bNeuesBildAufnehmen.Visible = false;
            this.bNeuesBildAufnehmen.Click += this.bNeuesBildAufnehmen_Click;
            // 
            // flpProduktgruppen
            // 
            this.tlpMainFrame.SetColumnSpan(this.flpProduktgruppen, 2);
            this.flpProduktgruppen.Controls.Add(this.lbProduktgruppen);
            this.flpProduktgruppen.Controls.Add(this.flpProduktgruppenDropdowns);
            this.flpProduktgruppen.Controls.Add(this.bAusweisErstellen);
            this.flpProduktgruppen.Dock = DockStyle.Fill;
            this.flpProduktgruppen.FlowDirection = FlowDirection.TopDown;
            this.flpProduktgruppen.Location = new Point(4, 525);
            this.flpProduktgruppen.Margin = new Padding(3, 0, 3, 3);
            this.flpProduktgruppen.Name = "flpProduktgruppen";
            this.flpProduktgruppen.Size = new Size(1175, 131);
            this.flpProduktgruppen.TabIndex = 2;
            // 
            // lbProduktgruppen
            // 
            this.lbProduktgruppen.AutoSize = true;
            this.lbProduktgruppen.Font = new Font("Segoe UI", 10F);
            this.lbProduktgruppen.Location = new Point(3, 0);
            this.lbProduktgruppen.Margin = new Padding(3, 0, 3, 10);
            this.lbProduktgruppen.Name = "lbProduktgruppen";
            this.lbProduktgruppen.Size = new Size(558, 19);
            this.lbProduktgruppen.TabIndex = 5;
            this.lbProduktgruppen.Text = "Wählen Sie bis zu 3 unserer Produktgruppen aus, an denen Sie besonders interessiert sind";
            // 
            // flpProduktgruppenDropdowns
            // 
            this.flpProduktgruppenDropdowns.Controls.Add(this.cbProduktgruppen1);
            this.flpProduktgruppenDropdowns.Controls.Add(this.cbProduktgruppen2);
            this.flpProduktgruppenDropdowns.Controls.Add(this.cbProduktgruppen3);
            this.flpProduktgruppenDropdowns.Location = new Point(3, 32);
            this.flpProduktgruppenDropdowns.Name = "flpProduktgruppenDropdowns";
            this.flpProduktgruppenDropdowns.Size = new Size(1165, 40);
            this.flpProduktgruppenDropdowns.TabIndex = 6;
            // 
            // cbProduktgruppen1
            // 
            this.cbProduktgruppen1.FormattingEnabled = true;
            this.cbProduktgruppen1.Location = new Point(3, 10);
            this.cbProduktgruppen1.Margin = new Padding(3, 10, 10, 10);
            this.cbProduktgruppen1.Name = "cbProduktgruppen1";
            this.cbProduktgruppen1.Size = new Size(225, 23);
            this.cbProduktgruppen1.TabIndex = 0;
            // 
            // cbProduktgruppen2
            // 
            this.cbProduktgruppen2.FormattingEnabled = true;
            this.cbProduktgruppen2.Location = new Point(248, 10);
            this.cbProduktgruppen2.Margin = new Padding(10);
            this.cbProduktgruppen2.Name = "cbProduktgruppen2";
            this.cbProduktgruppen2.Size = new Size(225, 23);
            this.cbProduktgruppen2.TabIndex = 1;
            // 
            // cbProduktgruppen3
            // 
            this.cbProduktgruppen3.FormattingEnabled = true;
            this.cbProduktgruppen3.Location = new Point(493, 10);
            this.cbProduktgruppen3.Margin = new Padding(10);
            this.cbProduktgruppen3.Name = "cbProduktgruppen3";
            this.cbProduktgruppen3.Size = new Size(225, 23);
            this.cbProduktgruppen3.TabIndex = 2;
            // 
            // bAusweisErstellen
            // 
            this.bAusweisErstellen.Enabled = false;
            this.bAusweisErstellen.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.bAusweisErstellen.Location = new Point(985, 90);
            this.bAusweisErstellen.Margin = new Padding(985, 15, 3, 3);
            this.bAusweisErstellen.Name = "bAusweisErstellen";
            this.bAusweisErstellen.Size = new Size(180, 30);
            this.bAusweisErstellen.TabIndex = 7;
            this.bAusweisErstellen.Text = "Kundenausweis erstellen";
            this.bAusweisErstellen.UseVisualStyleBackColor = true;
            this.bAusweisErstellen.Click += this.bAusweisErstellen_Click;
            // 
            // flpFirma
            // 
            this.flpFirma.Controls.Add(this.cbFirmenvertreter);
            this.flpFirma.Controls.Add(this.lbFirma);
            this.flpFirma.Controls.Add(this.tbFirma);
            this.flpFirma.Dock = DockStyle.Fill;
            this.flpFirma.FlowDirection = FlowDirection.TopDown;
            this.flpFirma.Location = new Point(4, 397);
            this.flpFirma.Name = "flpFirma";
            this.flpFirma.Size = new Size(584, 124);
            this.flpFirma.TabIndex = 1;
            // 
            // cbFirmenvertreter
            // 
            this.cbFirmenvertreter.AutoSize = true;
            this.cbFirmenvertreter.CheckAlign = ContentAlignment.MiddleRight;
            this.cbFirmenvertreter.Font = new Font("Segoe UI", 10F);
            this.cbFirmenvertreter.Location = new Point(3, 3);
            this.cbFirmenvertreter.Margin = new Padding(3, 3, 3, 20);
            this.cbFirmenvertreter.Name = "cbFirmenvertreter";
            this.cbFirmenvertreter.Size = new Size(135, 23);
            this.cbFirmenvertreter.TabIndex = 0;
            this.cbFirmenvertreter.Text = "Firmenvertretung";
            this.ttFirmenvertreter.SetToolTip(this.cbFirmenvertreter, "Vertreten Sie eine Firma? Tragen Sie den Haken ein, um den Namen Ihrer Firma auf Ihrem Ausweis zu vermerken.");
            this.cbFirmenvertreter.UseVisualStyleBackColor = true;
            this.cbFirmenvertreter.CheckedChanged += this.cbFirmenvertreter_CheckedChanged;
            // 
            // lbFirma
            // 
            this.lbFirma.AutoSize = true;
            this.lbFirma.Font = new Font("Segoe UI", 10F);
            this.lbFirma.Location = new Point(3, 46);
            this.lbFirma.Margin = new Padding(3, 0, 3, 10);
            this.lbFirma.Name = "lbFirma";
            this.lbFirma.Size = new Size(43, 19);
            this.lbFirma.TabIndex = 4;
            this.lbFirma.Text = "Firma";
            this.lbFirma.Visible = false;
            // 
            // tbFirma
            // 
            this.tbFirma.Location = new Point(3, 78);
            this.tbFirma.Margin = new Padding(3, 3, 3, 20);
            this.tbFirma.Name = "tbFirma";
            this.tbFirma.Size = new Size(225, 23);
            this.tbFirma.TabIndex = 5;
            this.tbFirma.Visible = false;
            // 
            // flpStammdaten
            // 
            this.flpStammdaten.Controls.Add(this.lbName);
            this.flpStammdaten.Controls.Add(this.tbName);
            this.flpStammdaten.Controls.Add(this.lbVorname);
            this.flpStammdaten.Controls.Add(this.tbVorname);
            this.flpStammdaten.Controls.Add(this.flpStrasseNrLabels);
            this.flpStammdaten.Controls.Add(this.flptStrasseNrTextbox);
            this.flpStammdaten.Controls.Add(this.flowLayoutPanel1);
            this.flpStammdaten.Controls.Add(this.flowLayoutPanel2);
            this.flpStammdaten.Dock = DockStyle.Fill;
            this.flpStammdaten.FlowDirection = FlowDirection.TopDown;
            this.flpStammdaten.Location = new Point(1, 4);
            this.flpStammdaten.Margin = new Padding(0, 3, 0, 3);
            this.flpStammdaten.Name = "flpStammdaten";
            this.tlpMainFrame.SetRowSpan(this.flpStammdaten, 3);
            this.flpStammdaten.Size = new Size(590, 386);
            this.flpStammdaten.TabIndex = 0;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new Font("Segoe UI", 10F);
            this.lbName.Location = new Point(3, 0);
            this.lbName.Margin = new Padding(3, 0, 3, 10);
            this.lbName.Name = "lbName";
            this.lbName.Size = new Size(45, 19);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Location = new Point(3, 32);
            this.tbName.Margin = new Padding(3, 3, 3, 20);
            this.tbName.Name = "tbName";
            this.tbName.Size = new Size(228, 23);
            this.tbName.TabIndex = 1;
            // 
            // lbVorname
            // 
            this.lbVorname.AutoSize = true;
            this.lbVorname.Font = new Font("Segoe UI", 10F);
            this.lbVorname.Location = new Point(3, 75);
            this.lbVorname.Margin = new Padding(3, 0, 3, 10);
            this.lbVorname.Name = "lbVorname";
            this.lbVorname.Size = new Size(64, 19);
            this.lbVorname.TabIndex = 2;
            this.lbVorname.Text = "Vorname";
            // 
            // tbVorname
            // 
            this.tbVorname.Location = new Point(3, 107);
            this.tbVorname.Margin = new Padding(3, 3, 3, 20);
            this.tbVorname.Name = "tbVorname";
            this.tbVorname.Size = new Size(228, 23);
            this.tbVorname.TabIndex = 3;
            // 
            // flpStrasseNrLabels
            // 
            this.flpStrasseNrLabels.Controls.Add(this.lbPLZ);
            this.flpStrasseNrLabels.Controls.Add(this.lbOrt);
            this.flpStrasseNrLabels.Dock = DockStyle.Left;
            this.flpStrasseNrLabels.Location = new Point(0, 150);
            this.flpStrasseNrLabels.Margin = new Padding(0);
            this.flpStrasseNrLabels.Name = "flpStrasseNrLabels";
            this.flpStrasseNrLabels.Size = new Size(585, 30);
            this.flpStrasseNrLabels.TabIndex = 4;
            // 
            // lbPLZ
            // 
            this.lbPLZ.AutoSize = true;
            this.lbPLZ.Font = new Font("Segoe UI", 10F);
            this.lbPLZ.Location = new Point(3, 0);
            this.lbPLZ.Margin = new Padding(3, 0, 216, 0);
            this.lbPLZ.Name = "lbPLZ";
            this.lbPLZ.Size = new Size(32, 19);
            this.lbPLZ.TabIndex = 3;
            this.lbPLZ.Text = "PLZ";
            // 
            // lbOrt
            // 
            this.lbOrt.AutoSize = true;
            this.lbOrt.Font = new Font("Segoe UI", 10F);
            this.lbOrt.Location = new Point(254, 0);
            this.lbOrt.Name = "lbOrt";
            this.lbOrt.Size = new Size(30, 19);
            this.lbOrt.TabIndex = 4;
            this.lbOrt.Text = "Ort";
            // 
            // flptStrasseNrTextbox
            // 
            this.flptStrasseNrTextbox.Controls.Add(this.tbPLZ);
            this.flptStrasseNrTextbox.Controls.Add(this.tbOrt);
            this.flptStrasseNrTextbox.Dock = DockStyle.Left;
            this.flptStrasseNrTextbox.Location = new Point(3, 180);
            this.flptStrasseNrTextbox.Margin = new Padding(3, 0, 0, 10);
            this.flptStrasseNrTextbox.Name = "flptStrasseNrTextbox";
            this.flptStrasseNrTextbox.Size = new Size(585, 35);
            this.flptStrasseNrTextbox.TabIndex = 5;
            // 
            // tbPLZ
            // 
            this.tbPLZ.Location = new Point(3, 3);
            this.tbPLZ.Margin = new Padding(3, 3, 25, 3);
            this.tbPLZ.Name = "tbPLZ";
            this.tbPLZ.Size = new Size(225, 23);
            this.tbPLZ.TabIndex = 0;
            this.tbPLZ.TextChanged += this.tbPLZ_TextChanged;
            // 
            // tbOrt
            // 
            this.tbOrt.Location = new Point(256, 3);
            this.tbOrt.Name = "tbOrt";
            this.tbOrt.Size = new Size(225, 23);
            this.tbOrt.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lbStrasse);
            this.flowLayoutPanel1.Controls.Add(this.lbNr);
            this.flowLayoutPanel1.Dock = DockStyle.Left;
            this.flowLayoutPanel1.Location = new Point(0, 225);
            this.flowLayoutPanel1.Margin = new Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new Size(585, 30);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // lbStrasse
            // 
            this.lbStrasse.AutoSize = true;
            this.lbStrasse.Font = new Font("Segoe UI", 10F);
            this.lbStrasse.Location = new Point(3, 0);
            this.lbStrasse.Margin = new Padding(3, 0, 200, 0);
            this.lbStrasse.Name = "lbStrasse";
            this.lbStrasse.Size = new Size(48, 19);
            this.lbStrasse.TabIndex = 3;
            this.lbStrasse.Text = "Straße";
            // 
            // lbNr
            // 
            this.lbNr.AutoSize = true;
            this.lbNr.Font = new Font("Segoe UI", 10F);
            this.lbNr.Location = new Point(254, 0);
            this.lbNr.Name = "lbNr";
            this.lbNr.Size = new Size(27, 19);
            this.lbNr.TabIndex = 4;
            this.lbNr.Text = "Nr.";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.tbStrasse);
            this.flowLayoutPanel2.Controls.Add(this.tbNr);
            this.flowLayoutPanel2.Dock = DockStyle.Left;
            this.flowLayoutPanel2.Location = new Point(3, 255);
            this.flowLayoutPanel2.Margin = new Padding(3, 0, 0, 10);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new Size(585, 35);
            this.flowLayoutPanel2.TabIndex = 9;
            // 
            // tbStrasse
            // 
            this.tbStrasse.Location = new Point(3, 3);
            this.tbStrasse.Margin = new Padding(3, 3, 25, 3);
            this.tbStrasse.Name = "tbStrasse";
            this.tbStrasse.Size = new Size(225, 23);
            this.tbStrasse.TabIndex = 0;
            // 
            // tbNr
            // 
            this.tbNr.Location = new Point(256, 3);
            this.tbNr.Name = "tbNr";
            this.tbNr.Size = new Size(225, 23);
            this.tbNr.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            this.label1.Location = new Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new Size(388, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kundenausweis-Generator";
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1184, 711);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tlpMainFrame);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ImeMode = ImeMode.Off;
            this.MaximumSize = new Size(1200, 750);
            this.MinimumSize = new Size(1200, 750);
            this.Name = "GUI";
            this.Text = "Kundenausweis-Generator";
            this.FormClosed += this.GUI_FormClosed;
            this.Load += this.GUI_Load;
            this.tlpMainFrame.ResumeLayout(false);
            this.flpWebcamPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.pbWebcamOutput).EndInit();
            this.flpFotoButtons.ResumeLayout(false);
            this.flpProduktgruppen.ResumeLayout(false);
            this.flpProduktgruppen.PerformLayout();
            this.flpProduktgruppenDropdowns.ResumeLayout(false);
            this.flpFirma.ResumeLayout(false);
            this.flpFirma.PerformLayout();
            this.flpStammdaten.ResumeLayout(false);
            this.flpStammdaten.PerformLayout();
            this.flpStrasseNrLabels.ResumeLayout(false);
            this.flpStrasseNrLabels.PerformLayout();
            this.flptStrasseNrTextbox.ResumeLayout(false);
            this.flptStrasseNrTextbox.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
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
        private Label lbPLZ;
        private Label lbOrt;
        private FlowLayoutPanel flptStrasseNrTextbox;
        private TextBox tbPLZ;
        private TextBox tbOrt;
        private CheckBox cbFirmenvertreter;
        private TextBox tbFirma;
        private Label lbFirma;
        private FlowLayoutPanel flpFirma;
        private Button bAusweisErstellen;
        private Label label1;
        private ToolTip ttFirmenvertreter;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lbStrasse;
        private Label lbNr;
        private FlowLayoutPanel flowLayoutPanel2;
        private TextBox tbStrasse;
        private TextBox tbNr;
    }
}