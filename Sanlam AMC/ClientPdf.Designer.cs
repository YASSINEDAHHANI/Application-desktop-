namespace Sanlam_AMC
{
    partial class ClientPdf
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientPdf));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            search = new Button();
            Num = new TextBox();
            label18 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            date = new DateTimePicker();
            dateSoins = new DateTimePicker();
            frais = new TextBox();
            Conv = new TextBox();
            type = new TextBox();
            cinouppr = new TextBox();
            Exportpfd = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(339, 645);
            panel1.TabIndex = 40;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(339, 125);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // search
            // 
            search.Location = new Point(826, 148);
            search.Name = "search";
            search.Size = new Size(74, 23);
            search.TabIndex = 44;
            search.Text = "Rechercher";
            search.UseVisualStyleBackColor = true;
            search.Click += search_Click;
            // 
            // Num
            // 
            Num.Location = new Point(646, 147);
            Num.Name = "Num";
            Num.Size = new Size(174, 23);
            Num.TabIndex = 43;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 10F);
            label18.Location = new Point(574, 148);
            label18.Name = "label18";
            label18.Size = new Size(66, 19);
            label18.TabIndex = 42;
            label18.Text = "Number :";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(661, 40);
            label1.Name = "label1";
            label1.Size = new Size(187, 50);
            label1.TabIndex = 41;
            label1.Text = "Accusé de réception \r\n             AMC";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(386, 322);
            label2.Name = "label2";
            label2.Size = new Size(179, 19);
            label2.TabIndex = 45;
            label2.Text = "Montant des frais engagés :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(386, 261);
            label3.Name = "label3";
            label3.Size = new Size(45, 19);
            label3.TabIndex = 46;
            label3.Text = "Date :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(386, 378);
            label4.Name = "label4";
            label4.Size = new Size(87, 19);
            label4.TabIndex = 47;
            label4.Text = "Convention :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(386, 441);
            label5.Name = "label5";
            label5.Size = new Size(110, 19);
            label5.TabIndex = 48;
            label5.Text = "Type de dossier :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(386, 507);
            label6.Name = "label6";
            label6.Size = new Size(99, 19);
            label6.TabIndex = 49;
            label6.Text = "Date de soins :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(386, 572);
            label7.Name = "label7";
            label7.Size = new Size(102, 19);
            label7.TabIndex = 50;
            label7.Text = "N°CIN ou PPR :";
            // 
            // date
            // 
            date.Format = DateTimePickerFormat.Short;
            date.Location = new Point(440, 261);
            date.Name = "date";
            date.Size = new Size(295, 23);
            date.TabIndex = 51;
            // 
            // dateSoins
            // 
            dateSoins.Format = DateTimePickerFormat.Short;
            dateSoins.Location = new Point(491, 503);
            dateSoins.Name = "dateSoins";
            dateSoins.Size = new Size(244, 23);
            dateSoins.TabIndex = 52;
            // 
            // frais
            // 
            frais.Location = new Point(571, 322);
            frais.Name = "frais";
            frais.Size = new Size(164, 23);
            frais.TabIndex = 53;
            // 
            // Conv
            // 
            Conv.Location = new Point(479, 374);
            Conv.Name = "Conv";
            Conv.Size = new Size(256, 23);
            Conv.TabIndex = 54;
            // 
            // type
            // 
            type.Location = new Point(502, 441);
            type.Name = "type";
            type.Size = new Size(233, 23);
            type.TabIndex = 55;
            // 
            // cinouppr
            // 
            cinouppr.Location = new Point(494, 571);
            cinouppr.Name = "cinouppr";
            cinouppr.Size = new Size(241, 23);
            cinouppr.TabIndex = 56;
            // 
            // Exportpfd
            // 
            Exportpfd.Location = new Point(900, 396);
            Exportpfd.Name = "Exportpfd";
            Exportpfd.Size = new Size(130, 52);
            Exportpfd.TabIndex = 57;
            Exportpfd.Text = "Export Pdf";
            Exportpfd.UseVisualStyleBackColor = true;
            Exportpfd.Click += button1_Click;
            // 
            // ClientPdf
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1121, 645);
            Controls.Add(Exportpfd);
            Controls.Add(cinouppr);
            Controls.Add(type);
            Controls.Add(Conv);
            Controls.Add(frais);
            Controls.Add(dateSoins);
            Controls.Add(date);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(search);
            Controls.Add(Num);
            Controls.Add(label18);
            Controls.Add(label1);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ClientPdf";
            Text = "ClientPdf";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Button search;
        private TextBox Num;
        private Label label18;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private DateTimePicker date;
        private DateTimePicker dateSoins;
        private TextBox frais;
        private TextBox Conv;
        private TextBox type;
        private TextBox cinouppr;
        private Button Exportpfd;
    }
}