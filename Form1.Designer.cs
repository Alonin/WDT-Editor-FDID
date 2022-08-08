namespace WDT_Editor_FDID
{
    partial class wdtEditor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wdtEditor));
            this.fileListBox = new System.Windows.Forms.ListBox();
            this.wdtLabel = new System.Windows.Forms.Label();
            this.loadWDTButton = new System.Windows.Forms.Button();
            this.searchBox1 = new System.Windows.Forms.TextBox();
            this.selectADTLabel = new System.Windows.Forms.Label();
            this.addADTButton = new System.Windows.Forms.Button();
            this.adtLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fileListBox
            // 
            this.fileListBox.FormattingEnabled = true;
            this.fileListBox.ItemHeight = 15;
            this.fileListBox.Location = new System.Drawing.Point(12, 49);
            this.fileListBox.Name = "fileListBox";
            this.fileListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.fileListBox.Size = new System.Drawing.Size(592, 454);
            this.fileListBox.TabIndex = 0;
            this.fileListBox.SelectedIndexChanged += new System.EventHandler(this.fileListBox_SelectedIndexChanged);
            // 
            // wdtLabel
            // 
            this.wdtLabel.AutoSize = true;
            this.wdtLabel.Location = new System.Drawing.Point(12, 567);
            this.wdtLabel.Name = "wdtLabel";
            this.wdtLabel.Size = new System.Drawing.Size(76, 15);
            this.wdtLabel.TabIndex = 1;
            this.wdtLabel.Text = "WDT Loaded:";
            this.wdtLabel.Visible = false;
            // 
            // loadWDTButton
            // 
            this.loadWDTButton.Location = new System.Drawing.Point(12, 538);
            this.loadWDTButton.Name = "loadWDTButton";
            this.loadWDTButton.Size = new System.Drawing.Size(75, 23);
            this.loadWDTButton.TabIndex = 2;
            this.loadWDTButton.Text = "Select WDT";
            this.loadWDTButton.UseVisualStyleBackColor = true;
            // 
            // searchBox1
            // 
            this.searchBox1.Location = new System.Drawing.Point(12, 509);
            this.searchBox1.Name = "searchBox1";
            this.searchBox1.Size = new System.Drawing.Size(592, 23);
            this.searchBox1.TabIndex = 3;
            // 
            // selectADTLabel
            // 
            this.selectADTLabel.AutoSize = true;
            this.selectADTLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectADTLabel.Location = new System.Drawing.Point(152, 9);
            this.selectADTLabel.Name = "selectADTLabel";
            this.selectADTLabel.Size = new System.Drawing.Size(262, 32);
            this.selectADTLabel.TabIndex = 4;
            this.selectADTLabel.Text = "Select ADT from Listfile";
            // 
            // addADTButton
            // 
            this.addADTButton.Location = new System.Drawing.Point(529, 538);
            this.addADTButton.Name = "addADTButton";
            this.addADTButton.Size = new System.Drawing.Size(75, 23);
            this.addADTButton.TabIndex = 5;
            this.addADTButton.Text = "Add ADT";
            this.addADTButton.UseVisualStyleBackColor = true;
            // 
            // adtLabel
            // 
            this.adtLabel.AutoSize = true;
            this.adtLabel.Location = new System.Drawing.Point(338, 567);
            this.adtLabel.Name = "adtLabel";
            this.adtLabel.Size = new System.Drawing.Size(72, 15);
            this.adtLabel.TabIndex = 6;
            this.adtLabel.Text = "Added ADT: ";
            this.adtLabel.Visible = false;
            // 
            // wdtEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(614, 591);
            this.Controls.Add(this.adtLabel);
            this.Controls.Add(this.addADTButton);
            this.Controls.Add(this.selectADTLabel);
            this.Controls.Add(this.searchBox1);
            this.Controls.Add(this.loadWDTButton);
            this.Controls.Add(this.wdtLabel);
            this.Controls.Add(this.fileListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "wdtEditor";
            this.Text = "WDT Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox fileListBox;
        private Label wdtLabel;
        private Button loadWDTButton;
        private TextBox searchBox1;
        private Label selectADTLabel;
        private Button addADTButton;
        private Label adtLabel;
    }
}