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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListWidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pxToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pxToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.lblFilename = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picbImageDisplay)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
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
            this.btnSelectFolder.Location = new System.Drawing.Point(12, 26);
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
            this.lblFolderSelected.Location = new System.Drawing.Point(165, 30);
            this.lblFolderSelected.Name = "lblFolderSelected";
            this.lblFolderSelected.Size = new System.Drawing.Size(97, 15);
            this.lblFolderSelected.TabIndex = 7;
            this.lblFolderSelected.Text = "lblFolderSelected";
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
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.menuToolStripMenuItem,
            this.sizeToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1225, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "txt";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.quitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem1
            // 
            this.quitToolStripMenuItem1.Name = "quitToolStripMenuItem1";
            this.quitToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.quitToolStripMenuItem1.Text = "&Quit";
            this.quitToolStripMenuItem1.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileListToolStripMenuItem,
            this.imageListToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.menuToolStripMenuItem.Text = "&List";
            // 
            // fileListToolStripMenuItem
            // 
            this.fileListToolStripMenuItem.Name = "fileListToolStripMenuItem";
            this.fileListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fileListToolStripMenuItem.Text = "&File List";
            this.fileListToolStripMenuItem.Click += new System.EventHandler(this.fileListToolStripMenuItem_Click);
            // 
            // imageListToolStripMenuItem
            // 
            this.imageListToolStripMenuItem.Name = "imageListToolStripMenuItem";
            this.imageListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.imageListToolStripMenuItem.Text = "&Image List";
            this.imageListToolStripMenuItem.Click += new System.EventHandler(this.imageListToolStripMenuItem_Click);
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageListWidthToolStripMenuItem});
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.sizeToolStripMenuItem.Text = "&Size";
            // 
            // imageListWidthToolStripMenuItem
            // 
            this.imageListWidthToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pxToolStripMenuItem,
            this.pxToolStripMenuItem1,
            this.pxToolStripMenuItem2});
            this.imageListWidthToolStripMenuItem.Name = "imageListWidthToolStripMenuItem";
            this.imageListWidthToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.imageListWidthToolStripMenuItem.Text = "&Image List Width";
            // 
            // pxToolStripMenuItem
            // 
            this.pxToolStripMenuItem.Name = "pxToolStripMenuItem";
            this.pxToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pxToolStripMenuItem.Text = "&64px";
            this.pxToolStripMenuItem.Click += new System.EventHandler(this.pxToolStripMenuItem_Click);
            // 
            // pxToolStripMenuItem1
            // 
            this.pxToolStripMenuItem1.Name = "pxToolStripMenuItem1";
            this.pxToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.pxToolStripMenuItem1.Text = "&128px";
            this.pxToolStripMenuItem1.Click += new System.EventHandler(this.pxToolStripMenuItem1_Click);
            // 
            // pxToolStripMenuItem2
            // 
            this.pxToolStripMenuItem2.Name = "pxToolStripMenuItem2";
            this.pxToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.pxToolStripMenuItem2.Text = "&256px";
            this.pxToolStripMenuItem2.Click += new System.EventHandler(this.pxToolStripMenuItem2_Click);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AllowUserToResizeColumns = false;
            this.dgvMain.AllowUserToResizeRows = false;
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(12, 70);
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.RowTemplate.Height = 50;
            this.dgvMain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(343, 604);
            this.dgvMain.TabIndex = 11;
            this.dgvMain.Visible = false;
            this.dgvMain.SelectionChanged += new System.EventHandler(this.dgvMain_SelectionChanged);
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(410, 52);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(68, 15);
            this.lblFilename.TabIndex = 12;
            this.lblFilename.Text = "lblFilename";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 687);
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.lblFolderSelected);
            this.Controls.Add(this.lblParameters);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.lblFilesInFolder);
            this.Controls.Add(this.txtParameters);
            this.Controls.Add(this.lstbFilelist);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.picbImageDisplay);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "PNG-SD-Info-Viewer, for Stable Diffusion Generated Images";
            ((System.ComponentModel.ISupportInitialize)(this.picbImageDisplay)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
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
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem fileListToolStripMenuItem;
        private ToolStripMenuItem imageListToolStripMenuItem;
        private DataGridView dgvMain;
        private ToolStripMenuItem sizeToolStripMenuItem;
        private ToolStripMenuItem imageListWidthToolStripMenuItem;
        private ToolStripMenuItem pxToolStripMenuItem;
        private ToolStripMenuItem pxToolStripMenuItem1;
        private ToolStripMenuItem pxToolStripMenuItem2;
        private Label lblFilename;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem1;
    }
}