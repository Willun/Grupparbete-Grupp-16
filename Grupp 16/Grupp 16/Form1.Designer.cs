namespace Grupp_16
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.buttonNew1 = new System.Windows.Forms.Button();
            this.buttonSave1 = new System.Windows.Forms.Button();
            this.buttonDelete1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.listBoxEpisodes = new System.Windows.Forms.ListBox();
            this.listBoxShowPodcast = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listBoxCategory = new System.Windows.Forms.ListBox();
            this.textBoxCategory = new System.Windows.Forms.TextBox();
            this.buttonNew2 = new System.Windows.Forms.Button();
            this.buttonSave2 = new System.Windows.Forms.Button();
            this.buttonDelete2 = new System.Windows.Forms.Button();
            this.comboBoxUpdateFrequency = new System.Windows.Forms.ComboBox();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listBoxEpisodeDescription = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 574);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(452, 574);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Uppdateringsfrekvens:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(666, 574);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kategori:";
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Location = new System.Drawing.Point(192, 599);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(258, 26);
            this.textBoxUrl.TabIndex = 3;
            // 
            // buttonNew1
            // 
            this.buttonNew1.Location = new System.Drawing.Point(483, 631);
            this.buttonNew1.Name = "buttonNew1";
            this.buttonNew1.Size = new System.Drawing.Size(138, 88);
            this.buttonNew1.TabIndex = 6;
            this.buttonNew1.Text = "Ny...";
            this.buttonNew1.UseVisualStyleBackColor = true;
            this.buttonNew1.Click += new System.EventHandler(this.buttonNew1_Click);
            // 
            // buttonSave1
            // 
            this.buttonSave1.Location = new System.Drawing.Point(627, 631);
            this.buttonSave1.Name = "buttonSave1";
            this.buttonSave1.Size = new System.Drawing.Size(138, 88);
            this.buttonSave1.TabIndex = 7;
            this.buttonSave1.Text = "Spara";
            this.buttonSave1.UseVisualStyleBackColor = true;
            this.buttonSave1.Click += new System.EventHandler(this.buttonSave1_Click);
            // 
            // buttonDelete1
            // 
            this.buttonDelete1.Location = new System.Drawing.Point(771, 631);
            this.buttonDelete1.Name = "buttonDelete1";
            this.buttonDelete1.Size = new System.Drawing.Size(138, 88);
            this.buttonDelete1.TabIndex = 8;
            this.buttonDelete1.Text = "Ta bort...";
            this.buttonDelete1.UseVisualStyleBackColor = true;
            this.buttonDelete1.Click += new System.EventHandler(this.buttonDelete1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(914, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Podcast Episodes:";
            // 
            // listBoxEpisodes
            // 
            this.listBoxEpisodes.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.listBoxEpisodes.FormattingEnabled = true;
            this.listBoxEpisodes.ItemHeight = 20;
            this.listBoxEpisodes.Location = new System.Drawing.Point(918, 58);
            this.listBoxEpisodes.Name = "listBoxEpisodes";
            this.listBoxEpisodes.Size = new System.Drawing.Size(848, 324);
            this.listBoxEpisodes.TabIndex = 10;
            this.listBoxEpisodes.SelectedIndexChanged += new System.EventHandler(this.listBoxEpisodes_SelectedIndexChanged);
            // 
            // listBoxShowPodcast
            // 
            this.listBoxShowPodcast.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.listBoxShowPodcast.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxShowPodcast.FormattingEnabled = true;
            this.listBoxShowPodcast.ItemHeight = 20;
            this.listBoxShowPodcast.Location = new System.Drawing.Point(12, 125);
            this.listBoxShowPodcast.Name = "listBoxShowPodcast";
            this.listBoxShowPodcast.Size = new System.Drawing.Size(900, 444);
            this.listBoxShowPodcast.TabIndex = 11;
            this.listBoxShowPodcast.SelectedIndexChanged += new System.EventHandler(this.listBoxShowPodcast_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(914, 402);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Categorys:";
            // 
            // listBoxCategory
            // 
            this.listBoxCategory.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.listBoxCategory.FormattingEnabled = true;
            this.listBoxCategory.ItemHeight = 20;
            this.listBoxCategory.Location = new System.Drawing.Point(918, 425);
            this.listBoxCategory.Name = "listBoxCategory";
            this.listBoxCategory.Size = new System.Drawing.Size(848, 144);
            this.listBoxCategory.TabIndex = 13;
            this.listBoxCategory.SelectedIndexChanged += new System.EventHandler(this.listBoxCategory_SelectedIndexChanged);
            // 
            // textBoxCategory
            // 
            this.textBoxCategory.Location = new System.Drawing.Point(918, 598);
            this.textBoxCategory.Name = "textBoxCategory";
            this.textBoxCategory.Size = new System.Drawing.Size(848, 26);
            this.textBoxCategory.TabIndex = 14;
            // 
            // buttonNew2
            // 
            this.buttonNew2.Location = new System.Drawing.Point(1340, 631);
            this.buttonNew2.Name = "buttonNew2";
            this.buttonNew2.Size = new System.Drawing.Size(138, 88);
            this.buttonNew2.TabIndex = 15;
            this.buttonNew2.Text = "Ny...";
            this.buttonNew2.UseVisualStyleBackColor = true;
            this.buttonNew2.Click += new System.EventHandler(this.buttonNew2_Click);
            // 
            // buttonSave2
            // 
            this.buttonSave2.Location = new System.Drawing.Point(1484, 631);
            this.buttonSave2.Name = "buttonSave2";
            this.buttonSave2.Size = new System.Drawing.Size(138, 88);
            this.buttonSave2.TabIndex = 16;
            this.buttonSave2.Text = "Spara";
            this.buttonSave2.UseVisualStyleBackColor = true;
            this.buttonSave2.Click += new System.EventHandler(this.buttonSave2_Click);
            // 
            // buttonDelete2
            // 
            this.buttonDelete2.Location = new System.Drawing.Point(1628, 630);
            this.buttonDelete2.Name = "buttonDelete2";
            this.buttonDelete2.Size = new System.Drawing.Size(138, 88);
            this.buttonDelete2.TabIndex = 17;
            this.buttonDelete2.Text = "Ta bort...";
            this.buttonDelete2.UseVisualStyleBackColor = true;
            this.buttonDelete2.Click += new System.EventHandler(this.buttonDelete2_Click);
            // 
            // comboBoxUpdateFrequency
            // 
            this.comboBoxUpdateFrequency.FormattingEnabled = true;
            this.comboBoxUpdateFrequency.Items.AddRange(new object[] {
            "1",
            "5",
            "20"});
            this.comboBoxUpdateFrequency.Location = new System.Drawing.Point(456, 597);
            this.comboBoxUpdateFrequency.Name = "comboBoxUpdateFrequency";
            this.comboBoxUpdateFrequency.Size = new System.Drawing.Size(208, 28);
            this.comboBoxUpdateFrequency.TabIndex = 19;
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(670, 597);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(240, 28);
            this.comboBoxCategory.TabIndex = 20;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(12, 598);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(174, 26);
            this.textBoxName.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 574);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "Namn";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(914, 574);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "Kategori:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 24;
            this.label8.Text = "Podcasts:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 711);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "Episode Description:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(789, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 34);
            this.button1.TabIndex = 26;
            this.button1.Text = "Avmarkera";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1643, 388);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 34);
            this.button2.TabIndex = 27;
            this.button2.Text = "Avmarkera";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1643, 21);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(123, 34);
            this.button3.TabIndex = 28;
            this.button3.Text = "Avmarkera";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBoxEpisodeDescription
            // 
            this.listBoxEpisodeDescription.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.listBoxEpisodeDescription.FormattingEnabled = true;
            this.listBoxEpisodeDescription.HorizontalScrollbar = true;
            this.listBoxEpisodeDescription.ItemHeight = 20;
            this.listBoxEpisodeDescription.Location = new System.Drawing.Point(13, 734);
            this.listBoxEpisodeDescription.Name = "listBoxEpisodeDescription";
            this.listBoxEpisodeDescription.Size = new System.Drawing.Size(1749, 144);
            this.listBoxEpisodeDescription.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.label10.Font = new System.Drawing.Font("Arial Rounded MT Bold", 34F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(754, 78);
            this.label10.TabIndex = 31;
            this.label10.Text = "RSS Reader Group 16";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1774, 889);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.listBoxEpisodeDescription);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.comboBoxUpdateFrequency);
            this.Controls.Add(this.buttonDelete2);
            this.Controls.Add(this.buttonSave2);
            this.Controls.Add(this.buttonNew2);
            this.Controls.Add(this.textBoxCategory);
            this.Controls.Add(this.listBoxCategory);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBoxShowPodcast);
            this.Controls.Add(this.listBoxEpisodes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonDelete1);
            this.Controls.Add(this.buttonSave1);
            this.Controls.Add(this.buttonNew1);
            this.Controls.Add(this.textBoxUrl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.Button buttonSave1;
        private System.Windows.Forms.Button buttonDelete1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxEpisodes;
        private System.Windows.Forms.ListBox listBoxShowPodcast;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBoxCategory;
        private System.Windows.Forms.TextBox textBoxCategory;
        private System.Windows.Forms.Button buttonNew2;
        private System.Windows.Forms.Button buttonSave2;
        private System.Windows.Forms.Button buttonDelete2;
        private System.Windows.Forms.ComboBox comboBoxUpdateFrequency;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Button buttonNew1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBoxEpisodeDescription;
        private System.Windows.Forms.Label label10;
    }
}

