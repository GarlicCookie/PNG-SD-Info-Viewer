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
            picbImageDisplay = new PictureBox();
            btnSelectFolder = new Button();
            txtParameters = new TextBox();
            lblFilesInFolder = new Label();
            lblImage = new Label();
            lblParameters = new Label();
            lblFolderSelected = new Label();
            btnCopy = new Button();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            folderToolStripMenuItem = new ToolStripMenuItem();
            refreshToolStripMenuItem = new ToolStripMenuItem();
            saveSettingsToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem1 = new ToolStripMenuItem();
            menuToolStripMenuItem = new ToolStripMenuItem();
            fileListToolStripMenuItem = new ToolStripMenuItem();
            imageListToolStripMenuItem = new ToolStripMenuItem();
            imageListColumnsToolStripMenuItem = new ToolStripMenuItem();
            imageToolStripMenuItem = new ToolStripMenuItem();
            createdDateToolStripMenuItem = new ToolStripMenuItem();
            modifiedDateToolStripMenuItem = new ToolStripMenuItem();
            modelToolStripMenuItem = new ToolStripMenuItem();
            modelHashToolStripMenuItem = new ToolStripMenuItem();
            seedToolStripMenuItem = new ToolStripMenuItem();
            sizeToolStripMenuItem = new ToolStripMenuItem();
            imageListWidthToolStripMenuItem = new ToolStripMenuItem();
            pxToolStripMenuItem3 = new ToolStripMenuItem();
            pxToolStripMenuItem = new ToolStripMenuItem();
            pxToolStripMenuItem1 = new ToolStripMenuItem();
            pxToolStripMenuItem2 = new ToolStripMenuItem();
            tagToolStripMenuItem = new ToolStripMenuItem();
            tagImageToolStripMenuItem = new ToolStripMenuItem();
            copyTaggedImagesToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            lightModeToolStripMenuItem = new ToolStripMenuItem();
            darkModeToolStripMenuItem = new ToolStripMenuItem();
            wallpaperToolStripMenuItem = new ToolStripMenuItem();
            centeredToolStripMenuItem = new ToolStripMenuItem();
            stretchedToolStripMenuItem = new ToolStripMenuItem();
            tiledToolStripMenuItem = new ToolStripMenuItem();
            fillToolStripMenuItem = new ToolStripMenuItem();
            fitToolStripMenuItem = new ToolStripMenuItem();
            spanToolStripMenuItem = new ToolStripMenuItem();
            clearWallpaperToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem1 = new ToolStripMenuItem();
            lblFilename = new Label();
            btnCopyPrompt = new Button();
            button1 = new Button();
            chkTag = new CheckBox();
            panMain = new Panel();
            lblLoading = new Label();
            progressBar1 = new ProgressBar();
            lstbFilelist = new ListBox();
            dgvMain = new DataGridView();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            lblStatus = new Label();
            btnCopyImage = new Button();
            ((System.ComponentModel.ISupportInitialize)picbImageDisplay).BeginInit();
            menuStrip1.SuspendLayout();
            panMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // picbImageDisplay
            // 
            picbImageDisplay.Anchor = AnchorStyles.None;
            picbImageDisplay.Location = new Point(297, 51);
            picbImageDisplay.Name = "picbImageDisplay";
            picbImageDisplay.Size = new Size(261, 180);
            picbImageDisplay.SizeMode = PictureBoxSizeMode.Zoom;
            picbImageDisplay.TabIndex = 0;
            picbImageDisplay.TabStop = false;
            picbImageDisplay.MouseClick += picbImageDisplay_Click;
            picbImageDisplay.MouseDown += picbImageDisplay_MouseDown;
            picbImageDisplay.MouseMove += picbImageDisplay_MouseMove;
            picbImageDisplay.MouseUp += picbImageDisplay_MouseUp;
            // 
            // btnSelectFolder
            // 
            btnSelectFolder.Location = new Point(12, 26);
            btnSelectFolder.Name = "btnSelectFolder";
            btnSelectFolder.Size = new Size(147, 23);
            btnSelectFolder.TabIndex = 1;
            btnSelectFolder.Text = "Select Folder...";
            btnSelectFolder.UseVisualStyleBackColor = true;
            btnSelectFolder.Click += btnSelectFolder_Click;
            // 
            // txtParameters
            // 
            txtParameters.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtParameters.Location = new Point(4, 42);
            txtParameters.Multiline = true;
            txtParameters.Name = "txtParameters";
            txtParameters.ScrollBars = ScrollBars.Vertical;
            txtParameters.Size = new Size(870, 112);
            txtParameters.TabIndex = 3;
            // 
            // lblFilesInFolder
            // 
            lblFilesInFolder.AllowDrop = true;
            lblFilesInFolder.AutoSize = true;
            lblFilesInFolder.Location = new Point(3, 0);
            lblFilesInFolder.Name = "lblFilesInFolder";
            lblFilesInFolder.Size = new Size(82, 15);
            lblFilesInFolder.TabIndex = 4;
            lblFilesInFolder.Text = "Files in Folder:";
            // 
            // lblImage
            // 
            lblImage.AllowDrop = true;
            lblImage.AutoSize = true;
            lblImage.Location = new Point(3, 0);
            lblImage.Name = "lblImage";
            lblImage.Size = new Size(43, 15);
            lblImage.TabIndex = 5;
            lblImage.Text = "Image:";
            // 
            // lblParameters
            // 
            lblParameters.AllowDrop = true;
            lblParameters.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lblParameters.AutoSize = true;
            lblParameters.Location = new Point(3, 24);
            lblParameters.Name = "lblParameters";
            lblParameters.Size = new Size(69, 15);
            lblParameters.TabIndex = 6;
            lblParameters.Text = "Parameters:";
            // 
            // lblFolderSelected
            // 
            lblFolderSelected.AllowDrop = true;
            lblFolderSelected.AutoSize = true;
            lblFolderSelected.Location = new Point(165, 30);
            lblFolderSelected.Name = "lblFolderSelected";
            lblFolderSelected.Size = new Size(97, 15);
            lblFolderSelected.TabIndex = 7;
            lblFolderSelected.Text = "lblFolderSelected";
            // 
            // btnCopy
            // 
            btnCopy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCopy.Location = new Point(752, 11);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(122, 25);
            btnCopy.TabIndex = 8;
            btnCopy.Text = "Copy All Text";
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ControlLight;
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, menuToolStripMenuItem, sizeToolStripMenuItem, tagToolStripMenuItem, viewToolStripMenuItem, wallpaperToolStripMenuItem, aboutToolStripMenuItem1 });
            menuStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1225, 24);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "txt";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { folderToolStripMenuItem, refreshToolStripMenuItem, saveSettingsToolStripMenuItem, quitToolStripMenuItem1 });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // folderToolStripMenuItem
            // 
            folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            folderToolStripMenuItem.Size = new Size(143, 22);
            folderToolStripMenuItem.Text = "Folder";
            folderToolStripMenuItem.Click += folderToolStripMenuItem_Click;
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.ShortcutKeys = Keys.F5;
            refreshToolStripMenuItem.Size = new Size(143, 22);
            refreshToolStripMenuItem.Text = "&Refresh";
            refreshToolStripMenuItem.Click += refreshToolStripMenuItem_Click;
            // 
            // saveSettingsToolStripMenuItem
            // 
            saveSettingsToolStripMenuItem.Name = "saveSettingsToolStripMenuItem";
            saveSettingsToolStripMenuItem.Size = new Size(143, 22);
            saveSettingsToolStripMenuItem.Text = "&Save Settings";
            saveSettingsToolStripMenuItem.Click += saveSettingsToolStripMenuItem_Click;
            // 
            // quitToolStripMenuItem1
            // 
            quitToolStripMenuItem1.Name = "quitToolStripMenuItem1";
            quitToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.Q;
            quitToolStripMenuItem1.Size = new Size(143, 22);
            quitToolStripMenuItem1.Text = "&Quit";
            quitToolStripMenuItem1.Click += quitToolStripMenuItem_Click;
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { fileListToolStripMenuItem, imageListToolStripMenuItem, imageListColumnsToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(37, 20);
            menuToolStripMenuItem.Text = "&List";
            // 
            // fileListToolStripMenuItem
            // 
            fileListToolStripMenuItem.Name = "fileListToolStripMenuItem";
            fileListToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D1;
            fileListToolStripMenuItem.Size = new Size(179, 22);
            fileListToolStripMenuItem.Text = "&Simple List";
            fileListToolStripMenuItem.Click += fileListToolStripMenuItem_Click;
            // 
            // imageListToolStripMenuItem
            // 
            imageListToolStripMenuItem.Name = "imageListToolStripMenuItem";
            imageListToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D2;
            imageListToolStripMenuItem.Size = new Size(179, 22);
            imageListToolStripMenuItem.Text = "&Detailed List";
            imageListToolStripMenuItem.Click += imageListToolStripMenuItem_Click;
            // 
            // imageListColumnsToolStripMenuItem
            // 
            imageListColumnsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { imageToolStripMenuItem, createdDateToolStripMenuItem, modifiedDateToolStripMenuItem, modelToolStripMenuItem, modelHashToolStripMenuItem, seedToolStripMenuItem });
            imageListColumnsToolStripMenuItem.Name = "imageListColumnsToolStripMenuItem";
            imageListColumnsToolStripMenuItem.Size = new Size(179, 22);
            imageListColumnsToolStripMenuItem.Text = "Image List Columns";
            // 
            // imageToolStripMenuItem
            // 
            imageToolStripMenuItem.CheckOnClick = true;
            imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            imageToolStripMenuItem.Size = new Size(151, 22);
            imageToolStripMenuItem.Text = "Image Preview";
            imageToolStripMenuItem.CheckedChanged += imageToolStripMenuItem_CheckedChanged;
            // 
            // createdDateToolStripMenuItem
            // 
            createdDateToolStripMenuItem.CheckOnClick = true;
            createdDateToolStripMenuItem.Name = "createdDateToolStripMenuItem";
            createdDateToolStripMenuItem.Size = new Size(151, 22);
            createdDateToolStripMenuItem.Text = "Created Date";
            createdDateToolStripMenuItem.CheckedChanged += createdDateToolStripMenuItem_CheckedChanged;
            // 
            // modifiedDateToolStripMenuItem
            // 
            modifiedDateToolStripMenuItem.CheckOnClick = true;
            modifiedDateToolStripMenuItem.Name = "modifiedDateToolStripMenuItem";
            modifiedDateToolStripMenuItem.Size = new Size(151, 22);
            modifiedDateToolStripMenuItem.Text = "Modified Date";
            modifiedDateToolStripMenuItem.CheckedChanged += modifiedDateToolStripMenuItem_CheckedChanged;
            // 
            // modelToolStripMenuItem
            // 
            modelToolStripMenuItem.CheckOnClick = true;
            modelToolStripMenuItem.Name = "modelToolStripMenuItem";
            modelToolStripMenuItem.Size = new Size(151, 22);
            modelToolStripMenuItem.Text = "Model";
            modelToolStripMenuItem.CheckedChanged += modelToolStripMenuItem_CheckedChanged;
            // 
            // modelHashToolStripMenuItem
            // 
            modelHashToolStripMenuItem.CheckOnClick = true;
            modelHashToolStripMenuItem.Name = "modelHashToolStripMenuItem";
            modelHashToolStripMenuItem.Size = new Size(151, 22);
            modelHashToolStripMenuItem.Text = "Model Hash";
            modelHashToolStripMenuItem.CheckedChanged += modelHashToolStripMenuItem_CheckedChanged;
            // 
            // seedToolStripMenuItem
            // 
            seedToolStripMenuItem.CheckOnClick = true;
            seedToolStripMenuItem.Name = "seedToolStripMenuItem";
            seedToolStripMenuItem.Size = new Size(151, 22);
            seedToolStripMenuItem.Text = "Seed";
            seedToolStripMenuItem.CheckedChanged += seedToolStripMenuItem_CheckedChanged;
            // 
            // sizeToolStripMenuItem
            // 
            sizeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { imageListWidthToolStripMenuItem });
            sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            sizeToolStripMenuItem.Size = new Size(39, 20);
            sizeToolStripMenuItem.Text = "&Size";
            // 
            // imageListWidthToolStripMenuItem
            // 
            imageListWidthToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pxToolStripMenuItem3, pxToolStripMenuItem, pxToolStripMenuItem1, pxToolStripMenuItem2 });
            imageListWidthToolStripMenuItem.Name = "imageListWidthToolStripMenuItem";
            imageListWidthToolStripMenuItem.Size = new Size(163, 22);
            imageListWidthToolStripMenuItem.Text = "&Image List Width";
            // 
            // pxToolStripMenuItem3
            // 
            pxToolStripMenuItem3.Name = "pxToolStripMenuItem3";
            pxToolStripMenuItem3.Size = new Size(105, 22);
            pxToolStripMenuItem3.Text = "&32px";
            pxToolStripMenuItem3.Click += pxToolStripMenuItem3_Click;
            // 
            // pxToolStripMenuItem
            // 
            pxToolStripMenuItem.Name = "pxToolStripMenuItem";
            pxToolStripMenuItem.Size = new Size(105, 22);
            pxToolStripMenuItem.Text = "&64px";
            pxToolStripMenuItem.Click += pxToolStripMenuItem_Click;
            // 
            // pxToolStripMenuItem1
            // 
            pxToolStripMenuItem1.Name = "pxToolStripMenuItem1";
            pxToolStripMenuItem1.Size = new Size(105, 22);
            pxToolStripMenuItem1.Text = "&128px";
            pxToolStripMenuItem1.Click += pxToolStripMenuItem1_Click;
            // 
            // pxToolStripMenuItem2
            // 
            pxToolStripMenuItem2.Name = "pxToolStripMenuItem2";
            pxToolStripMenuItem2.Size = new Size(105, 22);
            pxToolStripMenuItem2.Text = "&256px";
            pxToolStripMenuItem2.Click += pxToolStripMenuItem2_Click;
            // 
            // tagToolStripMenuItem
            // 
            tagToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tagImageToolStripMenuItem, copyTaggedImagesToolStripMenuItem });
            tagToolStripMenuItem.Name = "tagToolStripMenuItem";
            tagToolStripMenuItem.Size = new Size(37, 20);
            tagToolStripMenuItem.Text = "&Tag";
            // 
            // tagImageToolStripMenuItem
            // 
            tagImageToolStripMenuItem.Name = "tagImageToolStripMenuItem";
            tagImageToolStripMenuItem.Size = new Size(234, 22);
            tagImageToolStripMenuItem.Text = "&Tag / Untag Image (Hotkey: ~)";
            // 
            // copyTaggedImagesToolStripMenuItem
            // 
            copyTaggedImagesToolStripMenuItem.Name = "copyTaggedImagesToolStripMenuItem";
            copyTaggedImagesToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.T;
            copyTaggedImagesToolStripMenuItem.Size = new Size(234, 22);
            copyTaggedImagesToolStripMenuItem.Text = "&Copy Tagged Images";
            copyTaggedImagesToolStripMenuItem.Click += copyTaggedImagesToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { lightModeToolStripMenuItem, darkModeToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 20);
            viewToolStripMenuItem.Text = "&View";
            // 
            // lightModeToolStripMenuItem
            // 
            lightModeToolStripMenuItem.Name = "lightModeToolStripMenuItem";
            lightModeToolStripMenuItem.Size = new Size(135, 22);
            lightModeToolStripMenuItem.Text = "&Light Mode";
            lightModeToolStripMenuItem.Click += lightModeToolStripMenuItem_Click;
            // 
            // darkModeToolStripMenuItem
            // 
            darkModeToolStripMenuItem.Name = "darkModeToolStripMenuItem";
            darkModeToolStripMenuItem.Size = new Size(135, 22);
            darkModeToolStripMenuItem.Text = "&Dark Mode";
            darkModeToolStripMenuItem.Click += darkModeToolStripMenuItem_Click;
            // 
            // wallpaperToolStripMenuItem
            // 
            wallpaperToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { centeredToolStripMenuItem, stretchedToolStripMenuItem, tiledToolStripMenuItem, fillToolStripMenuItem, fitToolStripMenuItem, spanToolStripMenuItem, clearWallpaperToolStripMenuItem });
            wallpaperToolStripMenuItem.Name = "wallpaperToolStripMenuItem";
            wallpaperToolStripMenuItem.Size = new Size(72, 20);
            wallpaperToolStripMenuItem.Text = "&Wallpaper";
            // 
            // centeredToolStripMenuItem
            // 
            centeredToolStripMenuItem.Name = "centeredToolStripMenuItem";
            centeredToolStripMenuItem.Size = new Size(157, 22);
            centeredToolStripMenuItem.Text = "&Centered";
            centeredToolStripMenuItem.Click += centeredToolStripMenuItem_Click;
            // 
            // stretchedToolStripMenuItem
            // 
            stretchedToolStripMenuItem.Name = "stretchedToolStripMenuItem";
            stretchedToolStripMenuItem.Size = new Size(157, 22);
            stretchedToolStripMenuItem.Text = "&Stretched";
            stretchedToolStripMenuItem.Click += stretchedToolStripMenuItem_Click;
            // 
            // tiledToolStripMenuItem
            // 
            tiledToolStripMenuItem.Name = "tiledToolStripMenuItem";
            tiledToolStripMenuItem.Size = new Size(157, 22);
            tiledToolStripMenuItem.Text = "&Tiled";
            tiledToolStripMenuItem.Click += tiledToolStripMenuItem_Click;
            // 
            // fillToolStripMenuItem
            // 
            fillToolStripMenuItem.Name = "fillToolStripMenuItem";
            fillToolStripMenuItem.Size = new Size(157, 22);
            fillToolStripMenuItem.Text = "&Fill";
            fillToolStripMenuItem.Click += fillToolStripMenuItem_Click;
            // 
            // fitToolStripMenuItem
            // 
            fitToolStripMenuItem.Name = "fitToolStripMenuItem";
            fitToolStripMenuItem.Size = new Size(157, 22);
            fitToolStripMenuItem.Text = "F&it";
            fitToolStripMenuItem.Click += fitToolStripMenuItem_Click;
            // 
            // spanToolStripMenuItem
            // 
            spanToolStripMenuItem.Name = "spanToolStripMenuItem";
            spanToolStripMenuItem.Size = new Size(157, 22);
            spanToolStripMenuItem.Text = "S&pan";
            spanToolStripMenuItem.Click += spanToolStripMenuItem_Click;
            // 
            // clearWallpaperToolStripMenuItem
            // 
            clearWallpaperToolStripMenuItem.Name = "clearWallpaperToolStripMenuItem";
            clearWallpaperToolStripMenuItem.Size = new Size(157, 22);
            clearWallpaperToolStripMenuItem.Text = "Clea&r Wallpaper";
            clearWallpaperToolStripMenuItem.Click += clearWallpaperToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem1
            // 
            aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            aboutToolStripMenuItem1.Size = new Size(52, 20);
            aboutToolStripMenuItem1.Text = "About";
            aboutToolStripMenuItem1.Click += aboutToolStripMenuItem1_Click;
            // 
            // lblFilename
            // 
            lblFilename.AllowDrop = true;
            lblFilename.AutoSize = true;
            lblFilename.Location = new Point(52, 0);
            lblFilename.Name = "lblFilename";
            lblFilename.Size = new Size(68, 15);
            lblFilename.TabIndex = 12;
            lblFilename.Text = "lblFilename";
            // 
            // btnCopyPrompt
            // 
            btnCopyPrompt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCopyPrompt.Location = new Point(496, 11);
            btnCopyPrompt.Name = "btnCopyPrompt";
            btnCopyPrompt.Size = new Size(122, 25);
            btnCopyPrompt.TabIndex = 13;
            btnCopyPrompt.Text = "Copy Prompt";
            btnCopyPrompt.UseVisualStyleBackColor = true;
            btnCopyPrompt.Click += btnCopyPrompt_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(624, 11);
            button1.Name = "button1";
            button1.Size = new Size(122, 25);
            button1.TabIndex = 14;
            button1.Text = "Copy Prompt + Neg";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // chkTag
            // 
            chkTag.AllowDrop = true;
            chkTag.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkTag.AutoSize = true;
            chkTag.CheckAlign = ContentAlignment.MiddleRight;
            chkTag.Location = new Point(1142, 30);
            chkTag.Name = "chkTag";
            chkTag.Size = new Size(67, 19);
            chkTag.TabIndex = 15;
            chkTag.Text = "Tagged:";
            chkTag.UseVisualStyleBackColor = true;
            chkTag.Click += chkTag_Click;
            // 
            // panMain
            // 
            panMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panMain.BorderStyle = BorderStyle.FixedSingle;
            panMain.Controls.Add(lblLoading);
            panMain.Controls.Add(progressBar1);
            panMain.Controls.Add(picbImageDisplay);
            panMain.Location = new Point(4, 18);
            panMain.Name = "panMain";
            panMain.Size = new Size(870, 325);
            panMain.TabIndex = 16;
            panMain.Resize += panMain_Resize;
            // 
            // lblLoading
            // 
            lblLoading.AllowDrop = true;
            lblLoading.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblLoading.AutoSize = true;
            lblLoading.Location = new Point(244, 281);
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new Size(144, 15);
            lblLoading.TabIndex = 19;
            lblLoading.Text = "Loading Image Previews...";
            lblLoading.Visible = false;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(244, 297);
            progressBar1.MinimumSize = new Size(100, 23);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(387, 23);
            progressBar1.TabIndex = 18;
            progressBar1.Visible = false;
            // 
            // lstbFilelist
            // 
            lstbFilelist.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstbFilelist.FormattingEnabled = true;
            lstbFilelist.HorizontalScrollbar = true;
            lstbFilelist.ItemHeight = 15;
            lstbFilelist.Location = new Point(3, 18);
            lstbFilelist.Name = "lstbFilelist";
            lstbFilelist.Size = new Size(275, 514);
            lstbFilelist.TabIndex = 2;
            lstbFilelist.SelectedIndexChanged += lstbFilelist_SelectedIndexChanged;
            // 
            // dgvMain
            // 
            dgvMain.AllowUserToAddRows = false;
            dgvMain.AllowUserToDeleteRows = false;
            dgvMain.AllowUserToResizeRows = false;
            dgvMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMain.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMain.Location = new Point(3, 18);
            dgvMain.MultiSelect = false;
            dgvMain.Name = "dgvMain";
            dgvMain.ReadOnly = true;
            dgvMain.RowHeadersVisible = false;
            dgvMain.RowTemplate.Height = 50;
            dgvMain.ScrollBars = ScrollBars.Vertical;
            dgvMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMain.Size = new Size(275, 522);
            dgvMain.TabIndex = 11;
            dgvMain.Visible = false;
            dgvMain.CellContentClick += dgvMain_CellContentClick;
            dgvMain.SelectionChanged += dgvMain_SelectionChanged;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.BackColor = SystemColors.ControlLight;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(12, 55);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.AllowDrop = true;
            splitContainer1.Panel1.BackColor = SystemColors.Control;
            splitContainer1.Panel1.Controls.Add(dgvMain);
            splitContainer1.Panel1.Controls.Add(lstbFilelist);
            splitContainer1.Panel1.Controls.Add(lblFilesInFolder);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.AllowDrop = true;
            splitContainer1.Panel2.BackColor = SystemColors.Control;
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1201, 545);
            splitContainer1.SplitterDistance = 281;
            splitContainer1.SplitterWidth = 6;
            splitContainer1.TabIndex = 17;
            // 
            // splitContainer2
            // 
            splitContainer2.AllowDrop = true;
            splitContainer2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer2.BackColor = SystemColors.ControlLight;
            splitContainer2.FixedPanel = FixedPanel.Panel2;
            splitContainer2.Location = new Point(3, 3);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.BackColor = SystemColors.Control;
            splitContainer2.Panel1.Controls.Add(lblStatus);
            splitContainer2.Panel1.Controls.Add(lblImage);
            splitContainer2.Panel1.Controls.Add(lblFilename);
            splitContainer2.Panel1.Controls.Add(panMain);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.AllowDrop = true;
            splitContainer2.Panel2.BackColor = SystemColors.Control;
            splitContainer2.Panel2.Controls.Add(btnCopyImage);
            splitContainer2.Panel2.Controls.Add(txtParameters);
            splitContainer2.Panel2.Controls.Add(button1);
            splitContainer2.Panel2.Controls.Add(btnCopy);
            splitContainer2.Panel2.Controls.Add(btnCopyPrompt);
            splitContainer2.Panel2.Controls.Add(lblParameters);
            splitContainer2.Size = new Size(877, 539);
            splitContainer2.SplitterDistance = 346;
            splitContainer2.SplitterWidth = 6;
            splitContainer2.TabIndex = 17;
            // 
            // lblStatus
            // 
            lblStatus.AllowDrop = true;
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblStatus.Location = new Point(498, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(376, 15);
            lblStatus.TabIndex = 18;
            lblStatus.Text = "Status";
            lblStatus.TextAlign = ContentAlignment.TopRight;
            // 
            // btnCopyImage
            // 
            btnCopyImage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCopyImage.Location = new Point(368, 11);
            btnCopyImage.Name = "btnCopyImage";
            btnCopyImage.Size = new Size(122, 25);
            btnCopyImage.TabIndex = 15;
            btnCopyImage.Text = "Copy Image";
            btnCopyImage.UseVisualStyleBackColor = true;
            btnCopyImage.Click += btnCopyImage_Click;
            // 
            // frmMain
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1225, 612);
            Controls.Add(lblFolderSelected);
            Controls.Add(chkTag);
            Controls.Add(btnSelectFolder);
            Controls.Add(menuStrip1);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Name = "frmMain";
            Text = "PNG-SD-Info-Viewer, for Stable Diffusion Generated Images";
            Load += frmMain_Load_1;
            KeyDown += frmMain_KeyDown;
            ((System.ComponentModel.ISupportInitialize)picbImageDisplay).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panMain.ResumeLayout(false);
            panMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMain).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private ToolStripMenuItem folderToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem1;
    }
}
