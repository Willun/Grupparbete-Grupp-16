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
            this.listBoxChapters = new System.Windows.Forms.ListBox();
            this.listloda = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listBoxCategory = new System.Windows.Forms.ListBox();
            this.textBoxCategory = new System.Windows.Forms.TextBox();
            this.buttonNew2 = new System.Windows.Forms.Button();
            this.buttonSave2 = new System.Windows.Forms.Button();
            this.buttonDelete2 = new System.Windows.Forms.Button();
            this.listBoxViewer = new System.Windows.Forms.ListBox();
            this.comboBoxUpdateFrequency = new System.Windows.Forms.ComboBox();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 426);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 426);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Uppdateringsfrekvens:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(472, 426);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kategori:";
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Location = new System.Drawing.Point(51, 441);
            this.textBoxUrl.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(279, 20);
            this.textBoxUrl.TabIndex = 3;
            this.textBoxUrl.TextChanged += new System.EventHandler(this.textBoxUrl_TextChanged);
            // 
            // buttonNew1
            // 
            this.buttonNew1.Location = new System.Drawing.Point(332, 499);
            this.buttonNew1.Margin = new System.Windows.Forms.Padding(2);
            this.buttonNew1.Name = "buttonNew1";
            this.buttonNew1.Size = new System.Drawing.Size(104, 57);
            this.buttonNew1.TabIndex = 6;
            this.buttonNew1.Text = "Ny...";
            this.buttonNew1.UseVisualStyleBackColor = true;
            this.buttonNew1.Click += new System.EventHandler(this.buttonNew1_Click);
            // 
            // buttonSave1
            // 
            this.buttonSave1.Location = new System.Drawing.Point(440, 499);
            this.buttonSave1.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSave1.Name = "buttonSave1";
            this.buttonSave1.Size = new System.Drawing.Size(92, 57);
            this.buttonSave1.TabIndex = 7;
            this.buttonSave1.Text = "Spara";
            this.buttonSave1.UseVisualStyleBackColor = true;
            // 
            // buttonDelete1
            // 
            this.buttonDelete1.Location = new System.Drawing.Point(536, 499);
            this.buttonDelete1.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDelete1.Name = "buttonDelete1";
            this.buttonDelete1.Size = new System.Drawing.Size(95, 57);
            this.buttonDelete1.TabIndex = 8;
            this.buttonDelete1.Text = "Ta bort...";
            this.buttonDelete1.UseVisualStyleBackColor = true;
            this.buttonDelete1.Click += new System.EventHandler(this.buttonDelete1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 576);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Podcast";
            // 
            // listBoxChapters
            // 
            this.listBoxChapters.FormattingEnabled = true;
            this.listBoxChapters.Location = new System.Drawing.Point(32, 591);
            this.listBoxChapters.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxChapters.Name = "listBoxChapters";
            this.listBoxChapters.Size = new System.Drawing.Size(601, 199);
            this.listBoxChapters.TabIndex = 10;
            // 
            // listloda
            // 
            this.listloda.FormattingEnabled = true;
            this.listloda.Location = new System.Drawing.Point(32, 21);
            this.listloda.Margin = new System.Windows.Forms.Padding(2);
            this.listloda.Name = "listloda";
            this.listloda.Size = new System.Drawing.Size(601, 355);
            this.listloda.TabIndex = 11;
            this.listloda.SelectedIndexChanged += new System.EventHandler(this.listBoxMediaViewer_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(670, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Kategorier:";
            // 
            // listBoxCategory
            // 
            this.listBoxCategory.FormattingEnabled = true;
            this.listBoxCategory.Location = new System.Drawing.Point(673, 36);
            this.listBoxCategory.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxCategory.Name = "listBoxCategory";
            this.listBoxCategory.Size = new System.Drawing.Size(533, 212);
            this.listBoxCategory.TabIndex = 13;
            // 
            // textBoxCategory
            // 
            this.textBoxCategory.Location = new System.Drawing.Point(673, 268);
            this.textBoxCategory.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCategory.Name = "textBoxCategory";
            this.textBoxCategory.Size = new System.Drawing.Size(533, 20);
            this.textBoxCategory.TabIndex = 14;
            // 
            // buttonNew2
            // 
            this.buttonNew2.Location = new System.Drawing.Point(933, 305);
            this.buttonNew2.Margin = new System.Windows.Forms.Padding(2);
            this.buttonNew2.Name = "buttonNew2";
            this.buttonNew2.Size = new System.Drawing.Size(86, 57);
            this.buttonNew2.TabIndex = 15;
            this.buttonNew2.Text = "Ny...";
            this.buttonNew2.UseVisualStyleBackColor = true;
            // 
            // buttonSave2
            // 
            this.buttonSave2.Location = new System.Drawing.Point(1023, 305);
            this.buttonSave2.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSave2.Name = "buttonSave2";
            this.buttonSave2.Size = new System.Drawing.Size(91, 57);
            this.buttonSave2.TabIndex = 16;
            this.buttonSave2.Text = "Spara";
            this.buttonSave2.UseVisualStyleBackColor = true;
            // 
            // buttonDelete2
            // 
            this.buttonDelete2.Location = new System.Drawing.Point(1118, 305);
            this.buttonDelete2.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDelete2.Name = "buttonDelete2";
            this.buttonDelete2.Size = new System.Drawing.Size(86, 57);
            this.buttonDelete2.TabIndex = 17;
            this.buttonDelete2.Text = "Ta bort...";
            this.buttonDelete2.UseVisualStyleBackColor = true;
            // 
            // listBoxViewer
            // 
            this.listBoxViewer.FormattingEnabled = true;
            this.listBoxViewer.Location = new System.Drawing.Point(673, 380);
            this.listBoxViewer.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxViewer.Name = "listBoxViewer";
            this.listBoxViewer.Size = new System.Drawing.Size(533, 407);
            this.listBoxViewer.TabIndex = 18;
            // 
            // comboBoxUpdateFrequency
            // 
            this.comboBoxUpdateFrequency.FormattingEnabled = true;
            this.comboBoxUpdateFrequency.Location = new System.Drawing.Point(332, 441);
            this.comboBoxUpdateFrequency.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxUpdateFrequency.Name = "comboBoxUpdateFrequency";
            this.comboBoxUpdateFrequency.Size = new System.Drawing.Size(140, 21);
            this.comboBoxUpdateFrequency.TabIndex = 19;
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(475, 441);
            this.comboBoxCategory.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(158, 21);
            this.comboBoxCategory.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 690);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.comboBoxUpdateFrequency);
            this.Controls.Add(this.listBoxViewer);
            this.Controls.Add(this.buttonDelete2);
            this.Controls.Add(this.buttonSave2);
            this.Controls.Add(this.buttonNew2);
            this.Controls.Add(this.textBoxCategory);
            this.Controls.Add(this.listBoxCategory);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listloda);
            this.Controls.Add(this.listBoxChapters);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonDelete1);
            this.Controls.Add(this.buttonSave1);
            this.Controls.Add(this.buttonNew1);
            this.Controls.Add(this.textBoxUrl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.Button buttonNew1;
        private System.Windows.Forms.Button buttonSave1;
        private System.Windows.Forms.Button buttonDelete1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxChapters;
        private System.Windows.Forms.ListBox listloda;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBoxCategory;
        private System.Windows.Forms.TextBox textBoxCategory;
        private System.Windows.Forms.Button buttonNew2;
        private System.Windows.Forms.Button buttonSave2;
        private System.Windows.Forms.Button buttonDelete2;
        private System.Windows.Forms.ListBox listBoxViewer;
        private System.Windows.Forms.ComboBox comboBoxUpdateFrequency;
        private System.Windows.Forms.ComboBox comboBoxCategory;
    }
}

