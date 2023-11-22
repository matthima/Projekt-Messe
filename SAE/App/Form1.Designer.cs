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
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel4 = new FlowLayoutPanel();
            lbFirma = new Label();
            textBox5 = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lbName = new Label();
            textBox1 = new TextBox();
            lbVorname = new Label();
            textBox2 = new TextBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            lbStrasse = new Label();
            lbHausnummer = new Label();
            flowLayoutPanel3 = new FlowLayoutPanel();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            cbFirmenvertreter = new CheckBox();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(200, 100);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel4, 0, 3);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Size = new Size(1183, 660);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(lbFirma);
            flowLayoutPanel4.Controls.Add(textBox5);
            flowLayoutPanel4.Dock = DockStyle.Fill;
            flowLayoutPanel4.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel4.Location = new Point(3, 399);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            tableLayoutPanel1.SetRowSpan(flowLayoutPanel4, 2);
            flowLayoutPanel4.Size = new Size(585, 258);
            flowLayoutPanel4.TabIndex = 1;
            // 
            // lbFirma
            // 
            lbFirma.AutoSize = true;
            lbFirma.Font = new Font("Segoe UI", 10F);
            lbFirma.Location = new Point(3, 0);
            lbFirma.Margin = new Padding(3, 0, 3, 10);
            lbFirma.Name = "lbFirma";
            lbFirma.Size = new Size(43, 19);
            lbFirma.TabIndex = 4;
            lbFirma.Text = "Firma";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(3, 32);
            textBox5.Margin = new Padding(3, 3, 3, 20);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(199, 23);
            textBox5.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(lbName);
            flowLayoutPanel1.Controls.Add(textBox1);
            flowLayoutPanel1.Controls.Add(lbVorname);
            flowLayoutPanel1.Controls.Add(textBox2);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel2);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel3);
            flowLayoutPanel1.Controls.Add(cbFirmenvertreter);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            tableLayoutPanel1.SetRowSpan(flowLayoutPanel1, 3);
            flowLayoutPanel1.Size = new Size(585, 390);
            flowLayoutPanel1.TabIndex = 0;
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
            // textBox1
            // 
            textBox1.Location = new Point(3, 32);
            textBox1.Margin = new Padding(3, 3, 3, 20);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(199, 23);
            textBox1.TabIndex = 1;
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
            // textBox2
            // 
            textBox2.Location = new Point(3, 107);
            textBox2.Margin = new Padding(3, 3, 3, 20);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(199, 23);
            textBox2.TabIndex = 3;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(lbStrasse);
            flowLayoutPanel2.Controls.Add(lbHausnummer);
            flowLayoutPanel2.Dock = DockStyle.Left;
            flowLayoutPanel2.Location = new Point(0, 150);
            flowLayoutPanel2.Margin = new Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(585, 30);
            flowLayoutPanel2.TabIndex = 4;
            // 
            // lbStrasse
            // 
            lbStrasse.AutoSize = true;
            lbStrasse.Font = new Font("Segoe UI", 10F);
            lbStrasse.Location = new Point(3, 0);
            lbStrasse.Margin = new Padding(3, 0, 220, 0);
            lbStrasse.Name = "lbStrasse";
            lbStrasse.Size = new Size(48, 19);
            lbStrasse.TabIndex = 3;
            lbStrasse.Text = "Straße";
            // 
            // lbHausnummer
            // 
            lbHausnummer.AutoSize = true;
            lbHausnummer.Font = new Font("Segoe UI", 10F);
            lbHausnummer.Location = new Point(274, 0);
            lbHausnummer.Name = "lbHausnummer";
            lbHausnummer.Size = new Size(27, 19);
            lbHausnummer.TabIndex = 4;
            lbHausnummer.Text = "Nr.";
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(textBox3);
            flowLayoutPanel3.Controls.Add(textBox4);
            flowLayoutPanel3.Dock = DockStyle.Left;
            flowLayoutPanel3.Location = new Point(0, 180);
            flowLayoutPanel3.Margin = new Padding(0, 0, 0, 10);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(585, 35);
            flowLayoutPanel3.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(3, 3);
            textBox3.Margin = new Padding(3, 3, 45, 3);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(225, 23);
            textBox3.TabIndex = 0;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(276, 3);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(136, 23);
            textBox4.TabIndex = 1;
            // 
            // cbFirmenvertreter
            // 
            cbFirmenvertreter.AutoSize = true;
            cbFirmenvertreter.CheckAlign = ContentAlignment.MiddleRight;
            cbFirmenvertreter.Font = new Font("Segoe UI", 10F);
            cbFirmenvertreter.Location = new Point(3, 228);
            cbFirmenvertreter.Margin = new Padding(3, 3, 3, 20);
            cbFirmenvertreter.Name = "cbFirmenvertreter";
            cbFirmenvertreter.Size = new Size(135, 23);
            cbFirmenvertreter.TabIndex = 0;
            cbFirmenvertreter.Text = "Firmenvertretung";
            cbFirmenvertreter.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1183, 660);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lbName;
        private TextBox textBox1;
        private Label lbVorname;
        private TextBox textBox2;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label lbStrasse;
        private Label lbHausnummer;
        private FlowLayoutPanel flowLayoutPanel3;
        private TextBox textBox3;
        private TextBox textBox4;
        private FlowLayoutPanel flowLayoutPanel4;
        private CheckBox cbFirmenvertreter;
        private Label lbFirma;
        private TextBox textBox5;
    }
}