namespace FileManagement
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ScanPfad = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_drivename = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grp_Scan = new System.Windows.Forms.GroupBox();
            this.btn_scan = new System.Windows.Forms.Button();
            this.grp_search = new System.Windows.Forms.GroupBox();
            this.grid_DataView = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_keyword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_about = new System.Windows.Forms.Button();
            this.btn_dataPfad = new System.Windows.Forms.Button();
            this.txt_output = new System.Windows.Forms.TextBox();
            this.grp_Scan.SuspendLayout();
            this.grp_search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_DataView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Step 1: Select the Folder or Path, you want to scan ...";
            // 
            // btn_ScanPfad
            // 
            this.btn_ScanPfad.Location = new System.Drawing.Point(356, 18);
            this.btn_ScanPfad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ScanPfad.Name = "btn_ScanPfad";
            this.btn_ScanPfad.Size = new System.Drawing.Size(100, 28);
            this.btn_ScanPfad.TabIndex = 1;
            this.btn_ScanPfad.Text = "Browse ...";
            this.btn_ScanPfad.UseVisualStyleBackColor = true;
            this.btn_ScanPfad.Click += new System.EventHandler(this.btn_pfad_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Step 2: Insert the name of your drive ...";
            // 
            // txt_drivename
            // 
            this.txt_drivename.Location = new System.Drawing.Point(267, 57);
            this.txt_drivename.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_drivename.Name = "txt_drivename";
            this.txt_drivename.Size = new System.Drawing.Size(276, 22);
            this.txt_drivename.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Step 3: Click Scan";
            // 
            // grp_Scan
            // 
            this.grp_Scan.Controls.Add(this.btn_scan);
            this.grp_Scan.Controls.Add(this.label1);
            this.grp_Scan.Controls.Add(this.label3);
            this.grp_Scan.Controls.Add(this.txt_drivename);
            this.grp_Scan.Controls.Add(this.btn_ScanPfad);
            this.grp_Scan.Controls.Add(this.label2);
            this.grp_Scan.Location = new System.Drawing.Point(12, 12);
            this.grp_Scan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grp_Scan.Name = "grp_Scan";
            this.grp_Scan.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grp_Scan.Size = new System.Drawing.Size(573, 129);
            this.grp_Scan.TabIndex = 8;
            this.grp_Scan.TabStop = false;
            this.grp_Scan.Text = "Scan";
            // 
            // btn_scan
            // 
            this.btn_scan.Location = new System.Drawing.Point(133, 87);
            this.btn_scan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_scan.Name = "btn_scan";
            this.btn_scan.Size = new System.Drawing.Size(100, 28);
            this.btn_scan.TabIndex = 8;
            this.btn_scan.Text = "Scan";
            this.btn_scan.UseVisualStyleBackColor = true;
            this.btn_scan.Click += new System.EventHandler(this.btn_scan_Click);
            // 
            // grp_search
            // 
            this.grp_search.Controls.Add(this.grid_DataView);
            this.grp_search.Controls.Add(this.label5);
            this.grp_search.Controls.Add(this.btn_search);
            this.grp_search.Controls.Add(this.txt_keyword);
            this.grp_search.Controls.Add(this.label4);
            this.grp_search.Location = new System.Drawing.Point(12, 148);
            this.grp_search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grp_search.Name = "grp_search";
            this.grp_search.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grp_search.Size = new System.Drawing.Size(573, 511);
            this.grp_search.TabIndex = 9;
            this.grp_search.TabStop = false;
            this.grp_search.Text = "Search";
            this.grp_search.Enter += new System.EventHandler(this.grp_search_Enter);
            // 
            // grid_DataView
            // 
            this.grid_DataView.AllowUserToAddRows = false;
            this.grid_DataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_DataView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grid_DataView.Location = new System.Drawing.Point(0, 87);
            this.grid_DataView.Name = "grid_DataView";
            this.grid_DataView.ReadOnly = true;
            this.grid_DataView.RowTemplate.Height = 24;
            this.grid_DataView.Size = new System.Drawing.Size(573, 424);
            this.grid_DataView.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Step 2: Click Search...";
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(184, 54);
            this.btn_search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(100, 28);
            this.btn_search.TabIndex = 9;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_keyword
            // 
            this.txt_keyword.Location = new System.Drawing.Point(184, 23);
            this.txt_keyword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_keyword.Name = "txt_keyword";
            this.txt_keyword.Size = new System.Drawing.Size(359, 22);
            this.txt_keyword.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Step 1: Give a Keyword ...";
            // 
            // btn_about
            // 
            this.btn_about.Location = new System.Drawing.Point(485, 690);
            this.btn_about.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_about.Name = "btn_about";
            this.btn_about.Size = new System.Drawing.Size(100, 28);
            this.btn_about.TabIndex = 16;
            this.btn_about.Text = "About";
            this.btn_about.UseVisualStyleBackColor = true;
            this.btn_about.Click += new System.EventHandler(this.btn_about_Click);
            // 
            // btn_dataPfad
            // 
            this.btn_dataPfad.Location = new System.Drawing.Point(12, 690);
            this.btn_dataPfad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_dataPfad.Name = "btn_dataPfad";
            this.btn_dataPfad.Size = new System.Drawing.Size(117, 28);
            this.btn_dataPfad.TabIndex = 17;
            this.btn_dataPfad.Text = "Database Path";
            this.btn_dataPfad.UseVisualStyleBackColor = true;
            this.btn_dataPfad.Click += new System.EventHandler(this.btn_dataPfad_Click);
            // 
            // txt_output
            // 
            this.txt_output.Location = new System.Drawing.Point(12, 664);
            this.txt_output.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_output.Name = "txt_output";
            this.txt_output.ReadOnly = true;
            this.txt_output.Size = new System.Drawing.Size(573, 22);
            this.txt_output.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(596, 724);
            this.Controls.Add(this.txt_output);
            this.Controls.Add(this.btn_dataPfad);
            this.Controls.Add(this.btn_about);
            this.Controls.Add(this.grp_search);
            this.Controls.Add(this.grp_Scan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "FileManager";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grp_Scan.ResumeLayout(false);
            this.grp_Scan.PerformLayout();
            this.grp_search.ResumeLayout(false);
            this.grp_search.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_DataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ScanPfad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_drivename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grp_Scan;
        private System.Windows.Forms.Button btn_scan;
        private System.Windows.Forms.GroupBox grp_search;
        private System.Windows.Forms.TextBox txt_keyword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_about;
        private System.Windows.Forms.Button btn_dataPfad;
        private System.Windows.Forms.TextBox txt_output;
        private System.Windows.Forms.DataGridView grid_DataView;
        private System.Windows.Forms.Label label5;
    }
}

