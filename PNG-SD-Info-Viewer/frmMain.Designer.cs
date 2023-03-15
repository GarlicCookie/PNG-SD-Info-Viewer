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
            this.txtParameters = new System.Windows.Forms.TextBox();
            this.lblFilesInFolder = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.lblParameters = new System.Windows.Forms.Label();
            this.lblFolderSelected = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createdDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifiedDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelHashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListWidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pxToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.pxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pxToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pxToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tagImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyTaggedImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wallpaperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centeredToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stretchedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearWallpaperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblFilename = new System.Windows.Forms.Label();
            this.btnCopyPrompt = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.chkTag = new System.Windows.Forms.CheckBox();
            this.panMain = new System.Windows.Forms.Panel();
            this.lblLoading = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lstbFilelist = new System.Windows.Forms.ListBox();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnCopyImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picbImageDisplay)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // picbImageDisplay
            // 
            this.picbImageDisplay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picbImageDisplay.Location = new System.Drawing.Point(311, 103);
            this.picbImageDisplay.Name = "picbImageDisplay";
            this.picbImageDisplay.Size = new System.Drawing.Size(261, 180);
            this.picbImageDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbImageDisplay.TabIndex = 0;
            this.picbImageDisplay.TabStop = false;
            this.picbImageDisplay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picbImageDisplay_Click);
            this.picbImageDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbImageDisplay_MouseDown);
            this.picbImageDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbImageDisplay_MouseMove);
            this.picbImageDisplay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbImageDisplay_MouseUp);
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
            // txtParameters
            // 
            this.txtParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParameters.Location = new System.Drawing.Point(4, 42);
            this.txtParameters.Multiline = true;
            this.txtParameters.Name = "txtParameters";
            this.txtParameters.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtParameters.Size = new System.Drawing.Size(898, 112);
            this.txtParameters.TabIndex = 3;
            // 
            // lblFilesInFolder
            // 
            this.lblFilesInFolder.AutoSize = true;
            this.lblFilesInFolder.Location = new System.Drawing.Point(3, 0);
            this.lblFilesInFolder.Name = "lblFilesInFolder";
            this.lblFilesInFolder.Size = new System.Drawing.Size(82, 15);
            this.lblFilesInFolder.TabIndex = 4;
            this.lblFilesInFolder.Text = "Files in Folder:";
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(3, 0);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(43, 15);
            this.lblImage.TabIndex = 5;
            this.lblImage.Text = "Image:";
            // 
            // lblParameters
            // 
            this.lblParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblParameters.AutoSize = true;
            this.lblParameters.Location = new System.Drawing.Point(3, 24);
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
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Location = new System.Drawing.Point(780, 11);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(122, 25);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.Text = "Copy All Text";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.menuToolStripMenuItem,
            this.sizeToolStripMenuItem,
            this.tagToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.wallpaperToolStripMenuItem});
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
            this.refreshToolStripMenuItem,
            this.saveSettingsToolStripMenuItem,
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
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.refreshToolStripMenuItem.Text = "&Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // saveSettingsToolStripMenuItem
            // 
            this.saveSettingsToolStripMenuItem.Name = "saveSettingsToolStripMenuItem";
            this.saveSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveSettingsToolStripMenuItem.Text = "&Save Settings";
            this.saveSettingsToolStripMenuItem.Click += new System.EventHandler(this.saveSettingsToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem1
            // 
            this.quitToolStripMenuItem1.Name = "quitToolStripMenuItem1";
            this.quitToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.quitToolStripMenuItem1.Text = "&Quit";
            this.quitToolStripMenuItem1.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileListToolStripMenuItem,
            this.imageListToolStripMenuItem,
            this.imageListColumnsToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.menuToolStripMenuItem.Text = "&List";
            // 
            // fileListToolStripMenuItem
            // 
            this.fileListToolStripMenuItem.Name = "fileListToolStripMenuItem";
            this.fileListToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.fileListToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.fileListToolStripMenuItem.Text = "&Simple List";
            this.fileListToolStripMenuItem.Click += new System.EventHandler(this.fileListToolStripMenuItem_Click);
            // 
            // imageListToolStripMenuItem
            // 
            this.imageListToolStripMenuItem.Name = "imageListToolStripMenuItem";
            this.imageListToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.imageListToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.imageListToolStripMenuItem.Text = "&Detailed List";
            this.imageListToolStripMenuItem.Click += new System.EventHandler(this.imageListToolStripMenuItem_Click);
            // 
            // imageListColumnsToolStripMenuItem
            // 
            this.imageListColumnsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageToolStripMenuItem,
            this.createdDateToolStripMenuItem,
            this.modifiedDateToolStripMenuItem,
            this.modelToolStripMenuItem,
            this.modelHashToolStripMenuItem,
            this.seedToolStripMenuItem});
            this.imageListColumnsToolStripMenuItem.Name = "imageListColumnsToolStripMenuItem";
            this.imageListColumnsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.imageListColumnsToolStripMenuItem.Text = "Image List Columns";
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.CheckOnClick = true;
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.imageToolStripMenuItem.Text = "Image Preview";
            this.imageToolStripMenuItem.CheckedChanged += new System.EventHandler(this.imageToolStripMenuItem_CheckedChanged);
            // 
            // createdDateToolStripMenuItem
            // 
            this.createdDateToolStripMenuItem.CheckOnClick = true;
            this.createdDateToolStripMenuItem.Name = "createdDateToolStripMenuItem";
            this.createdDateToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.createdDateToolStripMenuItem.Text = "Created Date";
            this.createdDateToolStripMenuItem.CheckedChanged += new System.EventHandler(this.createdDateToolStripMenuItem_CheckedChanged);
            // 
            // modifiedDateToolStripMenuItem
            // 
            this.modifiedDateToolStripMenuItem.CheckOnClick = true;
            this.modifiedDateToolStripMenuItem.Name = "modifiedDateToolStripMenuItem";
            this.modifiedDateToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.modifiedDateToolStripMenuItem.Text = "Modified Date";
            this.modifiedDateToolStripMenuItem.CheckedChanged += new System.EventHandler(this.modifiedDateToolStripMenuItem_CheckedChanged);
            // 
            // modelToolStripMenuItem
            // 
            this.modelToolStripMenuItem.CheckOnClick = true;
            this.modelToolStripMenuItem.Name = "modelToolStripMenuItem";
            this.modelToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.modelToolStripMenuItem.Text = "Model";
            this.modelToolStripMenuItem.CheckedChanged += new System.EventHandler(this.modelToolStripMenuItem_CheckedChanged);
            // 
            // modelHashToolStripMenuItem
            // 
            this.modelHashToolStripMenuItem.CheckOnClick = true;
            this.modelHashToolStripMenuItem.Name = "modelHashToolStripMenuItem";
            this.modelHashToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.modelHashToolStripMenuItem.Text = "Model Hash";
            this.modelHashToolStripMenuItem.CheckedChanged += new System.EventHandler(this.modelHashToolStripMenuItem_CheckedChanged);
            // 
            // seedToolStripMenuItem
            // 
            this.seedToolStripMenuItem.CheckOnClick = true;
            this.seedToolStripMenuItem.Name = "seedToolStripMenuItem";
            this.seedToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.seedToolStripMenuItem.Text = "Seed";
            this.seedToolStripMenuItem.CheckedChanged += new System.EventHandler(this.seedToolStripMenuItem_CheckedChanged);
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
            this.pxToolStripMenuItem3,
            this.pxToolStripMenuItem,
            this.pxToolStripMenuItem1,
            this.pxToolStripMenuItem2});
            this.imageListWidthToolStripMenuItem.Name = "imageListWidthToolStripMenuItem";
            this.imageListWidthToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.imageListWidthToolStripMenuItem.Text = "&Image List Width";
            // 
            // pxToolStripMenuItem3
            // 
            this.pxToolStripMenuItem3.Name = "pxToolStripMenuItem3";
            this.pxToolStripMenuItem3.Size = new System.Drawing.Size(105, 22);
            this.pxToolStripMenuItem3.Text = "&32px";
            this.pxToolStripMenuItem3.Click += new System.EventHandler(this.pxToolStripMenuItem3_Click);
            // 
            // pxToolStripMenuItem
            // 
            this.pxToolStripMenuItem.Name = "pxToolStripMenuItem";
            this.pxToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.pxToolStripMenuItem.Text = "&64px";
            this.pxToolStripMenuItem.Click += new System.EventHandler(this.pxToolStripMenuItem_Click);
            // 
            // pxToolStripMenuItem1
            // 
            this.pxToolStripMenuItem1.Name = "pxToolStripMenuItem1";
            this.pxToolStripMenuItem1.Size = new System.Drawing.Size(105, 22);
            this.pxToolStripMenuItem1.Text = "&128px";
            this.pxToolStripMenuItem1.Click += new System.EventHandler(this.pxToolStripMenuItem1_Click);
            // 
            // pxToolStripMenuItem2
            // 
            this.pxToolStripMenuItem2.Name = "pxToolStripMenuItem2";
            this.pxToolStripMenuItem2.Size = new System.Drawing.Size(105, 22);
            this.pxToolStripMenuItem2.Text = "&256px";
            this.pxToolStripMenuItem2.Click += new System.EventHandler(this.pxToolStripMenuItem2_Click);
            // 
            // tagToolStripMenuItem
            // 
            this.tagToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tagImageToolStripMenuItem,
            this.copyTaggedImagesToolStripMenuItem});
            this.tagToolStripMenuItem.Name = "tagToolStripMenuItem";
            this.tagToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.tagToolStripMenuItem.Text = "&Tag";
            // 
            // tagImageToolStripMenuItem
            // 
            this.tagImageToolStripMenuItem.Name = "tagImageToolStripMenuItem";
            this.tagImageToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.tagImageToolStripMenuItem.Text = "&Tag / Untag Image (Hotkey: ~)";
            // 
            // copyTaggedImagesToolStripMenuItem
            // 
            this.copyTaggedImagesToolStripMenuItem.Name = "copyTaggedImagesToolStripMenuItem";
            this.copyTaggedImagesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.copyTaggedImagesToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.copyTaggedImagesToolStripMenuItem.Text = "&Copy Tagged Images";
            this.copyTaggedImagesToolStripMenuItem.Click += new System.EventHandler(this.copyTaggedImagesToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lightModeToolStripMenuItem,
            this.darkModeToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // lightModeToolStripMenuItem
            // 
            this.lightModeToolStripMenuItem.Name = "lightModeToolStripMenuItem";
            this.lightModeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.lightModeToolStripMenuItem.Text = "&Light Mode";
            this.lightModeToolStripMenuItem.Click += new System.EventHandler(this.lightModeToolStripMenuItem_Click);
            // 
            // darkModeToolStripMenuItem
            // 
            this.darkModeToolStripMenuItem.Name = "darkModeToolStripMenuItem";
            this.darkModeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.darkModeToolStripMenuItem.Text = "&Dark Mode";
            this.darkModeToolStripMenuItem.Click += new System.EventHandler(this.darkModeToolStripMenuItem_Click);
            // 
            // wallpaperToolStripMenuItem
            // 
            this.wallpaperToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.centeredToolStripMenuItem,
            this.stretchedToolStripMenuItem,
            this.tiledToolStripMenuItem,
            this.fillToolStripMenuItem,
            this.fitToolStripMenuItem,
            this.spanToolStripMenuItem,
            this.clearWallpaperToolStripMenuItem});
            this.wallpaperToolStripMenuItem.Name = "wallpaperToolStripMenuItem";
            this.wallpaperToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.wallpaperToolStripMenuItem.Text = "&Wallpaper";
            // 
            // centeredToolStripMenuItem
            // 
            this.centeredToolStripMenuItem.Name = "centeredToolStripMenuItem";
            this.centeredToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.centeredToolStripMenuItem.Text = "&Centered";
            this.centeredToolStripMenuItem.Click += new System.EventHandler(this.centeredToolStripMenuItem_Click);
            // 
            // stretchedToolStripMenuItem
            // 
            this.stretchedToolStripMenuItem.Name = "stretchedToolStripMenuItem";
            this.stretchedToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.stretchedToolStripMenuItem.Text = "&Stretched";
            this.stretchedToolStripMenuItem.Click += new System.EventHandler(this.stretchedToolStripMenuItem_Click);
            // 
            // tiledToolStripMenuItem
            // 
            this.tiledToolStripMenuItem.Name = "tiledToolStripMenuItem";
            this.tiledToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.tiledToolStripMenuItem.Text = "&Tiled";
            this.tiledToolStripMenuItem.Click += new System.EventHandler(this.tiledToolStripMenuItem_Click);
            // 
            // fillToolStripMenuItem
            // 
            this.fillToolStripMenuItem.Name = "fillToolStripMenuItem";
            this.fillToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.fillToolStripMenuItem.Text = "&Fill";
            this.fillToolStripMenuItem.Click += new System.EventHandler(this.fillToolStripMenuItem_Click);
            // 
            // fitToolStripMenuItem
            // 
            this.fitToolStripMenuItem.Name = "fitToolStripMenuItem";
            this.fitToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.fitToolStripMenuItem.Text = "F&it";
            this.fitToolStripMenuItem.Click += new System.EventHandler(this.fitToolStripMenuItem_Click);
            // 
            // spanToolStripMenuItem
            // 
            this.spanToolStripMenuItem.Name = "spanToolStripMenuItem";
            this.spanToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.spanToolStripMenuItem.Text = "S&pan";
            this.spanToolStripMenuItem.Click += new System.EventHandler(this.spanToolStripMenuItem_Click);
            // 
            // clearWallpaperToolStripMenuItem
            // 
            this.clearWallpaperToolStripMenuItem.Name = "clearWallpaperToolStripMenuItem";
            this.clearWallpaperToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.clearWallpaperToolStripMenuItem.Text = "Clea&r Wallpaper";
            this.clearWallpaperToolStripMenuItem.Click += new System.EventHandler(this.clearWallpaperToolStripMenuItem_Click);
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(52, 0);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(68, 15);
            this.lblFilename.TabIndex = 12;
            this.lblFilename.Text = "lblFilename";
            // 
            // btnCopyPrompt
            // 
            this.btnCopyPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyPrompt.Location = new System.Drawing.Point(524, 11);
            this.btnCopyPrompt.Name = "btnCopyPrompt";
            this.btnCopyPrompt.Size = new System.Drawing.Size(122, 25);
            this.btnCopyPrompt.TabIndex = 13;
            this.btnCopyPrompt.Text = "Copy Prompt";
            this.btnCopyPrompt.UseVisualStyleBackColor = true;
            this.btnCopyPrompt.Click += new System.EventHandler(this.btnCopyPrompt_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(652, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 25);
            this.button1.TabIndex = 14;
            this.button1.Text = "Copy Prompt + Neg";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkTag
            // 
            this.chkTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTag.AutoSize = true;
            this.chkTag.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTag.Location = new System.Drawing.Point(1142, 30);
            this.chkTag.Name = "chkTag";
            this.chkTag.Size = new System.Drawing.Size(67, 19);
            this.chkTag.TabIndex = 15;
            this.chkTag.Text = "Tagged:";
            this.chkTag.UseVisualStyleBackColor = true;
            this.chkTag.Click += new System.EventHandler(this.chkTag_Click);
            // 
            // panMain
            // 
            this.panMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panMain.Controls.Add(this.lblLoading);
            this.panMain.Controls.Add(this.progressBar1);
            this.panMain.Controls.Add(this.picbImageDisplay);
            this.panMain.Location = new System.Drawing.Point(4, 18);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(898, 428);
            this.panMain.TabIndex = 16;
            this.panMain.Resize += new System.EventHandler(this.panMain_Resize);
            // 
            // lblLoading
            // 
            this.lblLoading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoading.AutoSize = true;
            this.lblLoading.Location = new System.Drawing.Point(244, 384);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(144, 15);
            this.lblLoading.TabIndex = 19;
            this.lblLoading.Text = "Loading Image Previews...";
            this.lblLoading.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(244, 400);
            this.progressBar1.MinimumSize = new System.Drawing.Size(100, 23);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(415, 23);
            this.progressBar1.TabIndex = 18;
            this.progressBar1.Visible = false;
            // 
            // lstbFilelist
            // 
            this.lstbFilelist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstbFilelist.FormattingEnabled = true;
            this.lstbFilelist.HorizontalScrollbar = true;
            this.lstbFilelist.ItemHeight = 15;
            this.lstbFilelist.Location = new System.Drawing.Point(3, 18);
            this.lstbFilelist.Name = "lstbFilelist";
            this.lstbFilelist.Size = new System.Drawing.Size(275, 589);
            this.lstbFilelist.TabIndex = 2;
            this.lstbFilelist.SelectedIndexChanged += new System.EventHandler(this.lstbFilelist_SelectedIndexChanged);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AllowUserToResizeRows = false;
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMain.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(3, 18);
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.RowTemplate.Height = 50;
            this.dgvMain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(275, 597);
            this.dgvMain.TabIndex = 11;
            this.dgvMain.Visible = false;
            this.dgvMain.SelectionChanged += new System.EventHandler(this.dgvMain_SelectionChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(12, 55);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.dgvMain);
            this.splitContainer1.Panel1.Controls.Add(this.lstbFilelist);
            this.splitContainer1.Panel1.Controls.Add(this.lblFilesInFolder);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1201, 620);
            this.splitContainer1.SplitterDistance = 281;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 17;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel1.Controls.Add(this.lblStatus);
            this.splitContainer2.Panel1.Controls.Add(this.lblImage);
            this.splitContainer2.Panel1.Controls.Add(this.lblFilename);
            this.splitContainer2.Panel1.Controls.Add(this.panMain);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel2.Controls.Add(this.btnCopyImage);
            this.splitContainer2.Panel2.Controls.Add(this.txtParameters);
            this.splitContainer2.Panel2.Controls.Add(this.button1);
            this.splitContainer2.Panel2.Controls.Add(this.btnCopy);
            this.splitContainer2.Panel2.Controls.Add(this.btnCopyPrompt);
            this.splitContainer2.Panel2.Controls.Add(this.lblParameters);
            this.splitContainer2.Size = new System.Drawing.Size(905, 614);
            this.splitContainer2.SplitterDistance = 449;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 17;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.Location = new System.Drawing.Point(526, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(376, 15);
            this.lblStatus.TabIndex = 18;
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnCopyImage
            // 
            this.btnCopyImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyImage.Location = new System.Drawing.Point(396, 11);
            this.btnCopyImage.Name = "btnCopyImage";
            this.btnCopyImage.Size = new System.Drawing.Size(122, 25);
            this.btnCopyImage.TabIndex = 15;
            this.btnCopyImage.Text = "Copy Image";
            this.btnCopyImage.UseVisualStyleBackColor = true;
            this.btnCopyImage.Click += new System.EventHandler(this.btnCopyImage_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 687);
            this.Controls.Add(this.lblFolderSelected);
            this.Controls.Add(this.chkTag);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "PNG-SD-Info-Viewer, for Stable Diffusion Generated Images";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picbImageDisplay)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panMain.ResumeLayout(false);
            this.panMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox picbImageDisplay;
        private Button btnSelectFolder;
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
        private ToolStripMenuItem sizeToolStripMenuItem;
        private ToolStripMenuItem imageListWidthToolStripMenuItem;
        private ToolStripMenuItem pxToolStripMenuItem;
        private ToolStripMenuItem pxToolStripMenuItem1;
        private ToolStripMenuItem pxToolStripMenuItem2;
        private Label lblFilename;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem1;
        private Button btnCopyPrompt;
        private Button button1;
        private ToolStripMenuItem pxToolStripMenuItem3;
        private CheckBox chkTag;
        private ToolStripMenuItem tagToolStripMenuItem;
        private ToolStripMenuItem tagImageToolStripMenuItem;
        private ToolStripMenuItem copyTaggedImagesToolStripMenuItem;
        private Panel panMain;
        private ListBox lstbFilelist;
        private DataGridView dgvMain;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private Label lblStatus;
        private Button btnCopyImage;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private ToolStripMenuItem imageListColumnsToolStripMenuItem;
        private ToolStripMenuItem createdDateToolStripMenuItem;
        private ToolStripMenuItem imageToolStripMenuItem;
        private ToolStripMenuItem modifiedDateToolStripMenuItem;
        private ToolStripMenuItem modelToolStripMenuItem;
        private ToolStripMenuItem modelHashToolStripMenuItem;
        private ToolStripMenuItem seedToolStripMenuItem;
        private ToolStripMenuItem saveSettingsToolStripMenuItem;
        private ProgressBar progressBar1;
        private Label lblLoading;
        private ToolStripMenuItem wallpaperToolStripMenuItem;
        private ToolStripMenuItem centeredToolStripMenuItem;
        private ToolStripMenuItem stretchedToolStripMenuItem;
        private ToolStripMenuItem tiledToolStripMenuItem;
        private ToolStripMenuItem clearWallpaperToolStripMenuItem;
        private ToolStripMenuItem fillToolStripMenuItem;
        private ToolStripMenuItem fitToolStripMenuItem;
        private ToolStripMenuItem spanToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem lightModeToolStripMenuItem;
        private ToolStripMenuItem darkModeToolStripMenuItem;
    }
}