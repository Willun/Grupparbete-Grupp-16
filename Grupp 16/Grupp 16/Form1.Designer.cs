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
            this.listBoxViewer = new System.Windows.Forms.ListBox();
            this.comboBoxUpdateFrequency = new System.Windows.Forms.ComboBox();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 655);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(494, 655);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Uppdateringsfrekvens:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(708, 655);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kategori:";
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Location = new System.Drawing.Point(234, 678);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(258, 26);
            this.textBoxUrl.TabIndex = 3;
            this.textBoxUrl.TextChanged += new System.EventHandler(this.textBoxUrl_TextChanged);
            // 
            // buttonNew1
            // 
            this.buttonNew1.Location = new System.Drawing.Point(498, 768);
            this.buttonNew1.Name = "buttonNew1";
            this.buttonNew1.Size = new System.Drawing.Size(156, 88);
            this.buttonNew1.TabIndex = 6;
            this.buttonNew1.Text = "Ny...";
            this.buttonNew1.UseVisualStyleBackColor = true;
            this.buttonNew1.Click += new System.EventHandler(this.buttonNew1_Click);
            // 
            // buttonSave1
            // 
            this.buttonSave1.Location = new System.Drawing.Point(660, 768);
            this.buttonSave1.Name = "buttonSave1";
            this.buttonSave1.Size = new System.Drawing.Size(138, 88);
            this.buttonSave1.TabIndex = 7;
            this.buttonSave1.Text = "Spara";
            this.buttonSave1.UseVisualStyleBackColor = true;
            this.buttonSave1.Click += new System.EventHandler(this.buttonSave1_Click);
            // 
            // buttonDelete1
            // 
            this.buttonDelete1.Location = new System.Drawing.Point(804, 768);
            this.buttonDelete1.Name = "buttonDelete1";
            this.buttonDelete1.Size = new System.Drawing.Size(142, 88);
            this.buttonDelete1.TabIndex = 8;
            this.buttonDelete1.Text = "Ta bort...";
            this.buttonDelete1.UseVisualStyleBackColor = true;
            this.buttonDelete1.Click += new System.EventHandler(this.buttonDelete1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 886);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Podcast";
            // 
            // listBoxEpisodes
            // 
            this.listBoxEpisodes.FormattingEnabled = true;
            this.listBoxEpisodes.ItemHeight = 20;
            this.listBoxEpisodes.Location = new System.Drawing.Point(48, 909);
            this.listBoxEpisodes.Name = "listBoxEpisodes";
            this.listBoxEpisodes.Size = new System.Drawing.Size(900, 304);
            this.listBoxEpisodes.TabIndex = 10;
            this.listBoxEpisodes.SelectedIndexChanged += new System.EventHandler(this.listBoxEpisodes_SelectedIndexChanged);
            // 
            // listBoxShowPodcast
            // 
            this.listBoxShowPodcast.FormattingEnabled = true;
            this.listBoxShowPodcast.ItemHeight = 20;
            this.listBoxShowPodcast.Location = new System.Drawing.Point(48, 32);
            this.listBoxShowPodcast.Name = "listBoxShowPodcast";
            this.listBoxShowPodcast.Size = new System.Drawing.Size(900, 544);
            this.listBoxShowPodcast.TabIndex = 11;
            this.listBoxShowPodcast.SelectedIndexChanged += new System.EventHandler(this.listBoxShowPodcast_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1005, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Kategorier:";
            // 
            // listBoxCategory
            // 
            this.listBoxCategory.FormattingEnabled = true;
            this.listBoxCategory.ItemHeight = 20;
            this.listBoxCategory.Location = new System.Drawing.Point(1010, 55);
            this.listBoxCategory.Name = "listBoxCategory";
            this.listBoxCategory.Size = new System.Drawing.Size(798, 324);
            this.listBoxCategory.TabIndex = 13;
            // 
            // textBoxCategory
            // 
            this.textBoxCategory.Location = new System.Drawing.Point(1010, 412);
            this.textBoxCategory.Name = "textBoxCategory";
            this.textBoxCategory.Size = new System.Drawing.Size(798, 26);
            this.textBoxCategory.TabIndex = 14;
            // 
            // buttonNew2
            // 
            this.buttonNew2.Location = new System.Drawing.Point(1400, 469);
            this.buttonNew2.Name = "buttonNew2";
            this.buttonNew2.Size = new System.Drawing.Size(129, 88);
            this.buttonNew2.TabIndex = 15;
            this.buttonNew2.Text = "Ny...";
            this.buttonNew2.UseVisualStyleBackColor = true;
            this.buttonNew2.Click += new System.EventHandler(this.buttonNew2_Click);
            // 
            // buttonSave2
            // 
            this.buttonSave2.Location = new System.Drawing.Point(1534, 469);
            this.buttonSave2.Name = "buttonSave2";
            this.buttonSave2.Size = new System.Drawing.Size(136, 88);
            this.buttonSave2.TabIndex = 16;
            this.buttonSave2.Text = "Spara";
            this.buttonSave2.UseVisualStyleBackColor = true;
            this.buttonSave2.Click += new System.EventHandler(this.buttonSave2_Click);
            // 
            // buttonDelete2
            // 
            this.buttonDelete2.Location = new System.Drawing.Point(1677, 469);
            this.buttonDelete2.Name = "buttonDelete2";
            this.buttonDelete2.Size = new System.Drawing.Size(129, 88);
            this.buttonDelete2.TabIndex = 17;
            this.buttonDelete2.Text = "Ta bort...";
            this.buttonDelete2.UseVisualStyleBackColor = true;
            // 
            // listBoxViewer
            // 
            this.listBoxViewer.FormattingEnabled = true;
            this.listBoxViewer.ItemHeight = 20;
            this.listBoxViewer.Location = new System.Drawing.Point(1010, 585);
            this.listBoxViewer.Name = "listBoxViewer";
            this.listBoxViewer.Size = new System.Drawing.Size(798, 624);
            this.listBoxViewer.TabIndex = 18;
            // 
            // comboBoxUpdateFrequency
            // 
            this.comboBoxUpdateFrequency.FormattingEnabled = true;
            this.comboBoxUpdateFrequency.Items.AddRange(new object[] {
            "1",
            "3",
            "5",
            "10",
            "15",
            "20"});
            this.comboBoxUpdateFrequency.Location = new System.Drawing.Point(498, 678);
            this.comboBoxUpdateFrequency.Name = "comboBoxUpdateFrequency";
            this.comboBoxUpdateFrequency.Size = new System.Drawing.Size(208, 28);
            this.comboBoxUpdateFrequency.TabIndex = 19;
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Items.AddRange(new object[] {
            "hej"});
            this.comboBoxCategory.Location = new System.Drawing.Point(712, 678);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(235, 28);
            this.comboBoxCategory.TabIndex = 20;
            this.comboBoxCategory.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategory_SelectedIndexChanged);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(48, 679);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(180, 26);
            this.textBoxName.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 655);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "Namn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1852, 1062);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.comboBoxUpdateFrequency);
            this.Controls.Add(this.listBoxViewer);
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
        private System.Windows.Forms.ListBox listBoxViewer;
        private System.Windows.Forms.ComboBox comboBoxUpdateFrequency;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Button buttonNew1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label6;
    }
}

