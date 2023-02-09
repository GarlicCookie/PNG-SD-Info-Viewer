namespace PNG_SD_Info_Viewer
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.picbImageDisplay = new System.Windows.Forms.PictureBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.lstbFilelist = new System.Windows.Forms.ListBox();
            this.txtParameters = new System.Windows.Forms.TextBox();
            this.lblFilesInFolder = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.lblParameters = new System.Windows.Forms.Label();
            this.lblFolderSelected = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picbImageDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // picbImageDisplay
            // 
            this.picbImageDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picbImageDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbImageDisplay.Location = new System.Drawing.Point(361, 70);
            this.picbImageDisplay.Name = "picbImageDisplay";
            this.picbImageDisplay.Size = new System.Drawing.Size(846, 383);
            this.picbImageDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbImageDisplay.TabIndex = 0;
            this.picbImageDisplay.TabStop = false;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(12, 12);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(147, 23);
            this.btnSelectFolder.TabIndex = 1;
            this.btnSelectFolder.Text = "Select Folder...";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // lstbFilelist
            // 
            this.lstbFilelist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstbFilelist.FormattingEnabled = true;
            this.lstbFilelist.HorizontalScrollbar = true;
            this.lstbFilelist.ItemHeight = 15;
            this.lstbFilelist.Location = new System.Drawing.Point(12, 70);
            this.lstbFilelist.Name = "lstbFilelist";
            this.lstbFilelist.Size = new System.Drawing.Size(343, 604);
            this.lstbFilelist.TabIndex = 2;
            this.lstbFilelist.SelectedIndexChanged += new System.EventHandler(this.lstbFilelist_SelectedIndexChanged);
            // 
            // txtParameters
            // 
            this.txtParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParameters.Location = new System.Drawing.Point(361, 484);
            this.txtParameters.Multiline = true;
            this.txtParameters.Name = "txtParameters";
            this.txtParameters.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtParameters.Size = new System.Drawing.Size(846, 191);
            this.txtParameters.TabIndex = 3;
            // 
            // lblFilesInFolder
            // 
            this.lblFilesInFolder.AutoSize = true;
            this.lblFilesInFolder.Location = new System.Drawing.Point(12, 52);
            this.lblFilesInFolder.Name = "lblFilesInFolder";
            this.lblFilesInFolder.Size = new System.Drawing.Size(82, 15);
            this.lblFilesInFolder.TabIndex = 4;
            this.lblFilesInFolder.Text = "Files in Folder:";
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(361, 52);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(43, 15);
            this.lblImage.TabIndex = 5;
            this.lblImage.Text = "Image:";
            // 
            // lblParameters
            // 
            this.lblParameters.AutoSize = true;
            this.lblParameters.Location = new System.Drawing.Point(361, 466);
            this.lblParameters.Name = "lblParameters";
            this.lblParameters.Size = new System.Drawing.Size(69, 15);
            this.lblParameters.TabIndex = 6;
            this.lblParameters.Text = "Parameters:";
            // 
            // lblFolderSelected
            // 
            this.lblFolderSelected.AutoSize = true;
            this.lblFolderSelected.Location = new System.Drawing.Point(165, 20);
            this.lblFolderSelected.Name = "lblFolderSelected";
            this.lblFolderSelected.Size = new System.Drawing.Size(0, 15);
            this.lblFolderSelected.TabIndex = 7;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(1132, 459);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 687);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.lblFolderSelected);
            this.Controls.Add(this.lblParameters);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.lblFilesInFolder);
            this.Controls.Add(this.txtParameters);
            this.Controls.Add(this.lstbFilelist);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.picbImageDisplay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "PNG-SD-Info-Viewer, for Stable Diffusion Generated Images - By Omnia";
            ((System.ComponentModel.ISupportInitialize)(this.picbImageDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox picbImageDisplay;
        private Button btnSelectFolder;
        private ListBox lstbFilelist;
        private TextBox txtParameters;
        private Label lblFilesInFolder;
        private Label lblImage;
        private Label lblParameters;
        private Label lblFolderSelected;
        private Button btnCopy;
    }
}