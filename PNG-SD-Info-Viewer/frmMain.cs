using MetadataExtractor;
using MetadataExtractor.Formats.FileSystem;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static PNG_SD_Info_Viewer.frmMain;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace PNG_SD_Info_Viewer
{
    public partial class frmMain : Form
    {
        // ImageList object, used to fill in a DataGridView for image list mode (no longer used)
        //ImageList imgList = new ImageList();

        // Timer for text fading effect
        System.Windows.Forms.Timer labelFader = new System.Windows.Forms.Timer();

        // Array of images
        ArrayList arList = new ArrayList();

        // A string to hold the open path
        string openPath = "";

        // Default size of the image previews in image list mode
        int wSize = 64;
        int hSize = 64;

        // List to hold tagged image paths
        List<string> taggedImages = new List<string>();

        // Bool to check if mouse is pressed and moving
        bool isMouseDragging;

        // Mouse x pos when draggins
        int xPos;

        // Mouse y pos when dragging
        int yPos;

        // Bools on whether or not columns are active
        bool imageColumnActive = true;
        bool filenameColumnActive = true;
        bool createDateColumnActive = true;
        bool modifiedDateColumnActive = false;
        bool modelNameColumnActive = false;
        bool modelHashColumnActive = false;
        bool seedColumnActive = false;

        // View mode
        string UIviewMode = "lightmode";

        // Launchpoint
        public frmMain()
        {
            AllowDrop = true; //////////////////// added toadcode
            // Setup event handler for timer, used for text fade effect
            labelFader.Tick += new EventHandler(labelFader_Tick!);

            InitializeComponent();

            // Empty some of the textboxes.
            lblFolderSelected.Text = "";
            lblFilename.Text = "";
            lblStatus.Text = "";

            // Load saved settings
            loadSettings();

            // Set the view mode
            if (UIviewMode == "darkmode")
            {
                darkMode();
            }
            else
            {
                lightMode();
            }

            // Set menu checkmarks on the menubar accordingly.
            setMenuChecks();

            // Fire up the mousewheel detection on the picturebox
            picbImageDisplay.MouseWheel += PicbImageDisplay_MouseWheel;

        }


        // this is my custom toad code toadcode /////////////////////////////////////////////////////
        private void frmMain_Load_1(object sender, EventArgs e)
        {
            picbImageDisplay.AllowDrop = true;
            picbImageDisplay.DragEnter += new DragEventHandler(frmMain_DragEnter);
            picbImageDisplay.DragDrop += new DragEventHandler(frmMain_DragDrop);
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(frmMain_DragEnter);
            this.DragDrop += new DragEventHandler(frmMain_DragDrop);
        }

        private void frmMain_DragEnter(object? sender, DragEventArgs e)
        {
            //lblFolderSelected.Text = openPath;
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void frmMain_DragDrop(object? sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                string path = files[0];

                // Check if the path is a directory or a file
                if (System.IO.Directory.Exists(path))
                {
                    // The path is a directory
                    openPath = path;
                }
                else if (File.Exists(path))
                {
                    // The path is a file, so extract the directory path from it
                    openPath = Path.GetDirectoryName(path);
                }

                // Show the selected path in the UI
                lblFolderSelected.Text = openPath;

                // Go find images!
                findImagesInDirectory(openPath);

                // Load the image into the picturebox
                picbImageDisplay.ImageLocation = files[0];

                // Select the filename in the DataGridView
                string filename = Path.GetFileName(files[0]);

                lblFilename.Text = filename;
                //updateTagBox(filename);

                string selectedImage = lblFilename.Text;
                IEnumerable<MetadataExtractor.Directory> directories = ImageMetadataReader.ReadMetadata(openPath + "\\" + selectedImage);
                foreach (var directory in directories)
                    foreach (var tag in directory.Tags)
                    {
                        if (tag.Name == "Textual Data")
                        {
                            // Old style of EXIF pull.  Left for reference.
                            //textBox1.Text += ($"{directory.Name} \r\n - {tag.Name} = {tag.Description}");
                            //textBox1.Text += "\n";

                            // Parse text
                            string parsed = ($"{tag.Description}").Replace("Negative prompt:", "\r\n\r\nNegative Prompt:");
                            parsed = parsed.Replace("Steps:", "\r\n\r\nSteps:");
                            parsed = parsed.Replace("Sampler:", "\r\nSampler:");
                            parsed = parsed.Replace("CFG scale:", "\r\nCFG scale:");
                            parsed = parsed.Replace("Seed:", "\r\nSeed:");
                            parsed = parsed.Replace("Size:", "\r\nSize:");
                            parsed = parsed.Replace("Model hash:", "\r\nModel hash:");
                            parsed = parsed.Replace("Model:", "\r\nModel:");
                            parsed = parsed.Replace("Denoising strength:", "\r\nDenoising strength:");

                            // Update the textbox with the parsed string
                            txtParameters.Text += parsed;
                        }
                    }


            }
        }









        // Mousewheel detection
        private void PicbImageDisplay_MouseWheel(object? sender, MouseEventArgs e)
        {

            if (e.Delta < 0)
            {
                // Go to next file
                // Make sure list view is on and has items
                if (lstbFilelist.Items.Count > 0 && lstbFilelist.Visible == true)
                {
                    // If so, make sure that we aren't already at the end
                    if (lstbFilelist.SelectedIndex != lstbFilelist.Items.Count - 1)
                    {
                        // Advance
                        lstbFilelist.SelectedIndex = lstbFilelist.SelectedIndex + 1;
                    }
                }
                // Make sure DGV view is on and has items
                else if (dgvMain.RowCount > 0 && dgvMain.Visible == true)
                {
                    // Get the row index and length
                    if (dgvMain.SelectedRows.Count == 0) { return; }
                    DataGridViewRow r = dgvMain.SelectedRows[0];
                    int dgvCurrentRowIndex = r.Index;
                    int dgvLength = dgvMain.RowCount;

                    // Make sure we aren't at the end already
                    if (dgvCurrentRowIndex != dgvLength - 1)
                    {
                        // Advance
                        dgvMain[1, dgvCurrentRowIndex + 1].Selected = true;
                    }

                    // Cleanup
                    r.Dispose();
                }
            }
            else
            {
                // Go to previous file
                // Ensure the list is visible and has items
                if (lstbFilelist.Items.Count > 0 && lstbFilelist.Visible == true)
                {
                    // Ensure we are not at the beginning, or nothing selected
                    if (lstbFilelist.SelectedIndex != 0 && lstbFilelist.SelectedIndex != -1)
                    {
                        // Go back one
                        lstbFilelist.SelectedIndex = lstbFilelist.SelectedIndex - 1;
                    }
                }
                // Enure DGV has items and is on
                else if (dgvMain.RowCount > 0 && dgvMain.Visible == true)
                {
                    // Get row index and length
                    if (dgvMain.SelectedRows.Count == 0) { return; }
                    DataGridViewRow r = dgvMain.SelectedRows[0];
                    int dgvCurrentRowIndex = r.Index;
                    int dgvLength = dgvMain.RowCount;

                    // Verify not already at the beginning, or nothing selected
                    if (dgvCurrentRowIndex != 0 && dgvCurrentRowIndex != -1)
                    {
                        // Go back one
                        dgvMain[1, dgvCurrentRowIndex - 1].Selected = true;
                    }

                    // Cleanup
                    r.Dispose();
                }
            }
        }


        // Method when folder button is selected.  Gathers the path to use and passes it along to the find method.
        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            // Grab the folder from a dialog box
            var fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                // TODO - do I need this?  Got a new folder so clear the stuffs
                //lstbFilelist.Items.Clear();
                //txtParameters.Text = "";
                //picbImageDisplay.Image = null;

                // Store the path selected, it comes in handy.
                openPath = fbd.SelectedPath;

                // Show the selected path in the UI
                lblFolderSelected.Text = openPath;

                // Go find images!
                findImagesInDirectory(fbd.SelectedPath);
            }
        }


        // Comb the selected folder and pull images into the ListBox and DataGridView objects
        private void findImagesInDirectory(string path)
        {
            // Reset lists and parameters box
            taggedImages.Clear();
            lstbFilelist.Items.Clear();
            dgvMain.DataSource = null;
            dgvMain.Columns.Clear();
            dgvMain.Rows.Clear();
            //imgList.Images.Clear();
            arList.Clear();
            txtParameters.Text = "";
            picbImageDisplay.Image = null;

            // Set the side of the images in the imagelist (no longer used)
            //imgList.ImageSize = new Size(wSize, hSize);



            // Setup datagridview columns if DGV is active
            if (dgvMain.Visible == true)
            {
                DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
                DataGridViewTextBoxColumn filenameColumn = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn createdColumn = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn modifiedColumn = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn modelHashColumn = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn modelNameColumn = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn seedColumn = new DataGridViewTextBoxColumn();
                if (imageColumnActive == true) { dgvMain.Columns.Add(iconColumn); }
                if (filenameColumnActive == true) { dgvMain.Columns.Add(filenameColumn); }
                if (createDateColumnActive == true) { dgvMain.Columns.Add(createdColumn); }
                if (modifiedDateColumnActive == true) { dgvMain.Columns.Add(modifiedColumn); }
                if (modelHashColumnActive == true) { dgvMain.Columns.Add(modelHashColumn); }
                if (modelNameColumnActive == true) { dgvMain.Columns.Add(modelNameColumn); }
                if (seedColumnActive == true) { dgvMain.Columns.Add(seedColumn); }
                iconColumn.Name = "Images";
                iconColumn.HeaderText = "Images:";
                iconColumn.ImageLayout = DataGridViewImageCellLayout.Normal;
                iconColumn.Description = "Zoomed";
                filenameColumn.Name = "Filename:";
                filenameColumn.HeaderText = "Filename:";
                createdColumn.Name = "Created:";
                createdColumn.HeaderText = "Created:";
                modifiedColumn.Name = "Modified:";
                modifiedColumn.HeaderText = "Modified:";
                modelHashColumn.Name = "Model hash:";
                modelHashColumn.HeaderText = "Model hash:";
                modelNameColumn.Name = "Model:";
                modelNameColumn.HeaderText = "Model:";
                seedColumn.Name = "Seed:";
                seedColumn.HeaderText = "Seed:";
            }

            // Get all the png files from the provided path and put into array
            DirectoryInfo dinfo = new DirectoryInfo(path);
            FileInfo[] Files = dinfo.GetFiles("*.png");

            // Populate items into the Listbox, and the ImageList which we'll use for the DGV, using each file
            foreach (FileInfo file in Files)
            {
                // Add item to listbox      ** TODO: Only do this if the listbox is visible?  Might be a slight optimization.
                lstbFilelist.Items.Add(file.Name);

                // Add filename to imgList/arList object, with the full path as a key.  Might use the keyname later to lookup an image.  Only do this if we are using a DGV to save CPU and memory!
                if (dgvMain.Visible == true)
                {
                    // Add image to ImageList using memory optimization method.  Converts to resized bitmap then adds.            

                    // Turn on progress bar
                    if (imageColumnActive == true)
                    {
                        progressBar1.Visible = true;
                        lblLoading.Visible = true;
                        lblLoading.Refresh();
                        progressBar1.Maximum = Files.Length - 1;
                        progressBar1.Value = arList.Count;
                    }

                    // Set a bool for checking if we have a path that's too long
                    bool badImage = false;

                    // Setup our string to display is it's too long
                    string errorNotifier = "Certain images were not loaded because their filepath and filename are too long for your OS:\r\n";

                    // Check if the full path is over 256 characters
                    if (file.FullName.Length > 256)
                    {
                        // Add the filepath and filename to the error message
                        errorNotifier += file.FullName + "\r\n";

                        // Set that this iteration through the foreach is no good
                        badImage = true;
                    }

                    // If we didn't set our image pathlength as bad, and if the image column is enabled, continue.
                    if (badImage == false && imageColumnActive == true)
                    {
                        // Convert our image to a smaller bitmap, then add it to the ImageList
                        using (var tempImage = Image.FromFile(file.FullName))       //FromFile method has a path limit!
                        {
                            int hSize2 = hSize;
                            int wSize2 = wSize;

                            // Maintain aspect ratio (this isn't perfect but works pretty well)
                            if (tempImage.Width > tempImage.Height)
                            {
                                int wDiff = tempImage.Width / wSize;
                                hSize2 = tempImage.Height / wDiff;
                            }
                            else if (tempImage.Width < tempImage.Height)
                            {
                                int hDiff = tempImage.Height / hSize;
                                wSize2 = tempImage.Width / hDiff;
                            }

                            // Create new image in memory to store
                            Bitmap bmp = new Bitmap(wSize2, hSize2);
                            using (Graphics g = Graphics.FromImage(bmp))
                            {
                                g.DrawImage(tempImage, new Rectangle(0, 0, bmp.Width, bmp.Height));
                            }

                            // Add the resized bitmap to our imagelist
                            // imgList.Images.Add(bmp);
                            arList.Add(bmp);
                        }
                    }
                    // Else, if image column is off, we still want to build the array we need so it is sized accordingly.  Just add the filename instead of the image.
                    else if (imageColumnActive == false)
                    {
                        arList.Add(file.FullName);
                    }
                    // If we do not have a good image because the filepath is too long, show error
                    else if (badImage == true)
                    {
                        MessageBox.Show(errorNotifier);
                    }

                    // Turn off progress bar
                    progressBar1.Visible = false;
                    lblLoading.Visible = false; ;

                    // Reset the bad image indicator for the next iteration
                    badImage = false;

                    // Commented out the original add line to use the above more memory-efficient method.  Keeping here in case we need to revert.
                    //imgList.Images.Add(file.FullName, Image.FromFile(file.FullName));

                }
            }

            // Add items to the DGV if it is active
            if (dgvMain.Visible == true)
            {
                //for (int j = 0; j < imgList.Images.Count; j++)
                for (int j = 0; j < arList.Count; j++)
                {
                    // Index for cell column.  TODO:  Use this to toggle columns on/off
                    int cellCol = 0;

                    // Add a row and set its value to the image in first column, and filename in second
                    dgvMain.Rows.Add();
                    //dgvMain.Rows[j].Cells[0].Value = imgList.Images[j];
                    if (imageColumnActive == true)
                    {
                        dgvMain.Rows[j].Cells[cellCol].Value = arList[j];
                        cellCol++;
                    }
                    if (filenameColumnActive == true)
                    {
                        dgvMain.Rows[j].Cells[cellCol].Value = Files[j].Name;
                        cellCol++;
                    }

                    // Add additional file metadata
                    // Dates (currently using created date only).  Get file info for created and modified dates and store into vars.
                    var created = Files[j].CreationTime;
                    var lastmodified = Files[j].LastWriteTime;      // not used yet

                    // Add column value for created date
                    if (createDateColumnActive == true)
                    {
                        dgvMain.Rows[j].Cells[cellCol].Value = created;
                        cellCol++;
                    }
                    if (modifiedDateColumnActive == true)
                    {
                        dgvMain.Rows[j].Cells[cellCol].Value = lastmodified;
                        cellCol++;
                    }

                    // Grab the EXIF data for columns
                    IEnumerable<MetadataExtractor.Directory> directories = ImageMetadataReader.ReadMetadata(Files[j].FullName);
                    foreach (var directory in directories)
                        foreach (var tag in directory.Tags)
                        {
                            if (tag.Name == "Textual Data")
                            {
                                // Parse text
                                string parsed = ($"{tag.Description}").Replace("Negative prompt:", "\r\n\r\nNegative Prompt:");
                                parsed = parsed.Replace("Steps:", "\r\n\r\nSteps:");
                                parsed = parsed.Replace("Sampler:", "\r\nSampler:");
                                parsed = parsed.Replace("CFG scale:", "\r\nCFG scale:");
                                parsed = parsed.Replace("Seed:", "\r\nSeed:");
                                parsed = parsed.Replace("Size:", "\r\nSize:");
                                parsed = parsed.Replace("Model hash:", "\r\nModel hash:");
                                parsed = parsed.Replace("Model:", "\r\nModel:");
                                parsed = parsed.Replace("Denoising strength:", "\r\nDenoising strength:");

                                // Grab the full prompt text, leave if it is empty
                                string s = parsed;
                                if (s != "")
                                {

                                    // Split the text at line breaks
                                    string[] components = s.Split("\r\n");

                                    // Loop through each split spot and pull out what we need
                                    foreach (string component in components)
                                    {
                                        // Check if column is active
                                        if (modelHashColumnActive == true)
                                        {
                                            // If the string is at least 12 long, and starts this way, we found our column
                                            if ((component.Length >= 12) && (component.Substring(0, 12) == "Model hash: "))
                                            {
                                                // Add to column
                                                string modelHashTrim = component.Replace(",", "");
                                                modelHashTrim = modelHashTrim.Replace("Model hash: ", "");
                                                dgvMain.Rows[j].Cells[cellCol].Value = modelHashTrim;
                                                cellCol++;

                                            }
                                        }
                                        // Check if column is active
                                        if (modelNameColumnActive == true)
                                        {
                                            bool controlnetModel = false;
                                            // Check if this is a controlnet model.  If so, skip it.
                                            // If the string is at least 14 long, and starts this way, we found our column
                                            if ((component.Length >= 14) && (component.Substring(0, 14) == "Model: control"))
                                            {
                                                controlnetModel = true;

                                            }

                                            // If the string is at least 7 long, and starts this way, we found our column
                                            if ((component.Length >= 7) && (component.Substring(0, 7) == "Model: ") && (controlnetModel == false))
                                            {
                                                // Add to column
                                                string modelTrim = component.Replace(",", "");
                                                modelTrim = modelTrim.Replace("Model: ", "");
                                                dgvMain.Rows[j].Cells[cellCol].Value = modelTrim;
                                                cellCol++;

                                            }
                                        }
                                        // Check if column is active
                                        if (seedColumnActive == true)
                                        {
                                            // If the string is at least 12 long, and starts this way, we found our column
                                            if ((component.Length >= 6) && (component.Substring(0, 6) == "Seed: "))
                                            {
                                                // Add to column
                                                string seedTrim = component.Replace(",", "");
                                                seedTrim = seedTrim.Replace("Seed: ", "");
                                                dgvMain.Rows[j].Cells[cellCol].Value = seedTrim;
                                                cellCol++;

                                            }
                                        }
                                    }
                                }

                            }
                        }






                    // Update cellsize for each row
                    DataGridViewCell cell = dgvMain.Rows[j].Cells[0];

                    // Set the Row height.
                    dgvMain.Rows[cell.RowIndex].Height = hSize;

                    // Set the Column width for the image column if it is displayed.  You can just use index 0 since it is always in that spot if it is active.
                    if (imageColumnActive == true)
                    {
                        dgvMain.Columns[0].Width = wSize;
                    }
                }

                // All items added, now select nothing.  Otherwise, DGV selects first row by default but doesn't update.
                dgvMain.ClearSelection();

                // Set focus to the active control.  This doesn't work perfectly but it's ok.
                if (dgvMain.Visible == true)
                {
                    dgvMain.Focus();
                }
                else
                {
                    lstbFilelist.Focus();
                }
            }
        }


        // Call when a new item is selected in our ListBox
        private void lstbFilelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear the stuffs
            txtParameters.Text = "";

            // Get the filename selected in the listbox
            string selectedImage = lstbFilelist.GetItemText(lstbFilelist.SelectedItem);

            // Update our picturebox and parameters boxes!
            updateBoxes(selectedImage);
        }

        // Call this when a new row is selected in our DataGridView
        private void dgvMain_SelectionChanged(object sender, EventArgs e)
        {
            // Clear the stuffs
            txtParameters.Text = "";

            // Set a string for the selected image filename
            string selectedImage = "";

            // Pull out any selected rows. There should only be one since we limit it to single row selection.  TODO: Replace the foreach, we don't need to iterate.
            foreach (DataGridViewRow selectedRow in dgvMain.SelectedRows)
            {
                // If the value in the filename column isn't null (and it shouldn't be, it should have the filename text), then store the filename as a string.
                var dataGridViewColumn = dgvMain.Columns["Filename:"];
                int filenameIndex = 0;
                if (dataGridViewColumn != null)
                {
                    filenameIndex = dgvMain.Columns.IndexOf(dataGridViewColumn);
                }

                if (dgvMain[filenameIndex, selectedRow.Index].Value != null)
                {

                    selectedImage = dgvMain[filenameIndex, selectedRow.Index].Value.ToString()!;
                }
            }

            // Update our picturebox and parameters boxes!
            updateBoxes(selectedImage);
        }




        private void updateBoxes(string selectedImage)
        {
            // Ensure we have an image to use
            if (selectedImage == "")
            {
                return;
            }

            // Set the picturebox to display the image based on the stored path plus the selected filename
            picbImageDisplay.ImageLocation = openPath + "\\" + selectedImage;

            // Reset the picturebox style and location
            resetPB();

            // Show the selected filename on the UI
            lblFilename.Text = selectedImage;

            // Show the tag checkbox accordingly
            updateTagBox(selectedImage);

            // Grab the EXIF data and show it in the parameters textbox
            //IEnumerable<MetadataExtractor.Directory> directories = ImageMetadataReader.ReadMetadata(openPath + "\\" + selectedImage);

            //IEnumerable<MetadataExtractor.Directory> directories;
            //try
            //{
            //    directories = ImageMetadataReader.ReadMetadata(openPath + "\\" + selectedImage);
            //}
            //catch (System.IO.IOException)
            //{
            //    directories = ImageMetadataReader.ReadMetadata(selectedImage);
            //}

            IEnumerable<MetadataExtractor.Directory> directories = ImageMetadataReader.ReadMetadata(openPath + "\\" + selectedImage);

            foreach (var directory in directories)
                foreach (var tag in directory.Tags)
                {
                    if (tag.Name == "Textual Data")
                    {
                        // Old style of EXIF pull.  Left for reference.
                        //textBox1.Text += ($"{directory.Name} \r\n - {tag.Name} = {tag.Description}");
                        //textBox1.Text += "\n";

                        // Parse text
                        string parsed = ($"{tag.Description}").Replace("Negative prompt:", "\r\n\r\nNegative Prompt:");
                        parsed = parsed.Replace("Steps:", "\r\n\r\nSteps:");
                        parsed = parsed.Replace("Sampler:", "\r\nSampler:");
                        parsed = parsed.Replace("CFG scale:", "\r\nCFG scale:");
                        parsed = parsed.Replace("Seed:", "\r\nSeed:");
                        parsed = parsed.Replace("Size:", "\r\nSize:");
                        parsed = parsed.Replace("Model hash:", "\r\nModel hash:");
                        parsed = parsed.Replace("Model:", "\r\nModel:");
                        parsed = parsed.Replace("Denoising strength:", "\r\nDenoising strength:");

                        // Update the textbox with the parsed string
                        txtParameters.Text += parsed;
                    }
                }
        }


        // Method to show listbox and populate it with the selected folder if there is one
        private void fileListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Hide DataGridView and Show Listbox
            dgvMain.Hide();
            lstbFilelist.Show();

            // Populate the Listbox if a path is selected
            if (openPath != "")
            {
                findImagesInDirectory(openPath);
            }
        }


        // Method to show DataGridView and populate it with the selected folder if there is one
        private void imageListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Hide Listbox and Show DataGridview
            dgvMain.Show();
            lstbFilelist.Hide();

            // Populate the DGV if a path is selected
            if (openPath != "")
            {
                findImagesInDirectory(openPath);
            }
        }


        // Quit button
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Empty memory.  Probably not really necessary, but whatever.
            //imgList.Dispose();
            arList.Clear();
            lstbFilelist.Items.Clear();
            dgvMain.DataSource = null;
            dgvMain.Columns.Clear();
            dgvMain.Rows.Clear();
            openPath = "";

            // Close
            this.Close();
        }


        // About button
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtParameters.Text = "PNG-SD-Info-Viewer is a program designed to quickly allow the browsing of PNG files with associated metadata from Stable Diffusion generated images.\r\nIt now also allows quick image tagging so favorites can be copied out to a new location.\r\nThere is a filename list view, and, an image preview view.  Image preview size can be adjusted.\r\nMouse scrolling over the image will go to next or previous image.\r\nLeft-clicking on the image will zoom.\r\nHolding middle-mouse button and dragging will move the image.\r\nRight-clicking the image will copy the image to your clipboard.\r\n - By Omnia, the Garlic Cookie\r\nhttps://github.com/GarlicCookie/PNG-SD-Info-Viewer\r\nGNU GPL3";
        }


        // Set to 32px and go repopulate the list
        private void pxToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            hSize = 32;
            wSize = 32;
            if (openPath != "")
            {
                findImagesInDirectory(openPath);
            }
        }


        // Set to 64px and go repopulate the list
        private void pxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hSize = 64;
            wSize = 64;
            if (openPath != "")
            {
                findImagesInDirectory(openPath);
            }
        }


        // Set to 128px and go repopulate the list
        private void pxToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            hSize = 128;
            wSize = 128;
            if (openPath != "")
            {
                findImagesInDirectory(openPath);
            }
        }


        // Set to 256px and go repopulate the list
        private void pxToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            hSize = 256;
            wSize = 256;
            if (openPath != "")
            {
                findImagesInDirectory(openPath);
            }
        }


        // Simple method to copy parameters to clipboard
        private void btnCopy_Click(object sender, EventArgs e)
        {
            // Grab the full prompt text, leave if it is empty
            string s = txtParameters.Text;
            if (s == "") { return; }

            // Copies to clipboard
            Clipboard.SetText(s);
            // Status Update
            updateStatusBox("Copied to clipboard");
        }

        // Copy prompt button
        private void btnCopyPrompt_Click(object sender, EventArgs e)
        {
            // Grab the full prompt text, leave if it is empty
            string s = txtParameters.Text;
            if (s == "") { return; }

            // Split the text at line breaks
            string[] components = s.Split("\r\n");

            // Loop through each split spot and pull out what we need
            foreach (string component in components)
            {
                // If the string is at least 12 long, and starts this way, we found our prompt
                if ((component.Length >= 12) && (component.Substring(0, 12) == "parameters: "))
                {
                    // Copies to clipboard
                    Clipboard.SetText(component);

                    // Status Update
                    updateStatusBox("Prompt copied to clipboard");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Grab the full prompt text, leave if it is empty
            string s = txtParameters.Text;
            if (s == "") { return; }

            // Set up a string to hold both parts, positive and negative
            string stringToCopy = "";

            // Split the text at line breaks
            string[] components = s.Split("\r\n");

            // Loop through each split spot and pull out what we need
            foreach (string component in components)
            {
                // If the string is at least 12 long, and starts this way, we found our prompt
                if ((component.Length >= 12) && (component.Substring(0, 12) == "parameters: "))
                {
                    // Add to our copy string
                    stringToCopy += component;
                }
                // If the string is at least 17 long, and starts this way, we found our negative prompt
                if ((component.Length >= 17) && (component.Substring(0, 17) == "Negative Prompt: "))
                {
                    // Add to our copy string
                    stringToCopy += component;
                }
            }

            // Copies to clipboard
            if (stringToCopy != "")
            {
                Clipboard.SetText(stringToCopy);
            }

            // Status Update
            updateStatusBox("Prompt + Neg copied to clipboard");
        }


        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Oemtilde)
            {
                // Call the tag check if we press ~
                tagger();
            }
        }


        private void tagger()
        {
            // Set a string for the selected image filename
            string selectedImage = "";

            // Get the filename selected in the listbox
            selectedImage = lstbFilelist.GetItemText(lstbFilelist.SelectedItem);

            // Still no image, so we must be in DGV mode
            if (selectedImage == "")
            {
                // Pull out any selected rows. There should only be one since we limit it to single row selection.  TODO: Replace the foreach, we don't need to iterate.
                foreach (DataGridViewRow selectedRow in dgvMain.SelectedRows)
                {
                    // If the value in the filename column isn't null (and it shouldn't be, it should have the filename text), then store the filename as a string.
                    var dataGridViewColumn = dgvMain.Columns["Filename:"];
                    int filenameIndex = 0;
                    if (dataGridViewColumn != null)
                    {
                        filenameIndex = dgvMain.Columns.IndexOf(dataGridViewColumn);
                    }

                    if (dgvMain[filenameIndex, selectedRow.Index].Value != null)
                    {

                        selectedImage = dgvMain[filenameIndex, selectedRow.Index].Value.ToString()!;
                    }



                }
            }

            // Check if image is selected, leave if not.
            if (selectedImage == "")
            {
                return;
            }

            // var used to keep track if we already know it is tagged
            bool found = false;

            // Still here, so get the file path and file name
            foreach (string s in taggedImages)
            {
                if (s == selectedImage)
                {
                    // We found it, so we need to untag it below.
                    found = true;
                    // Quit looking, we already found it.
                    break;
                }
            }

            // Not found, so tag it.
            if (found == false)
            {
                taggedImages.Add(selectedImage);
            }

            // Found, so untag it
            if (found == true)
            {
                taggedImages.Remove(selectedImage);
            }

            updateTagBox(selectedImage);
        }

        private void updateTagBox(string selectedImage)
        {
            bool found = false;

            // Show tag if the image is in our tag list
            foreach (string s in taggedImages)
            {
                if (s == selectedImage)
                {
                    // We found it, so we need to untag it below.
                    found = true;
                    // Quit looking, we already found it.
                    break;
                }
            }

            // Not found, so not checked
            if (found == false)
            {
                chkTag.Checked = false;
            }

            // Found, so checked
            if (found == true)
            {
                chkTag.Checked = true;
            }

        }



        private void chkTag_Click(object sender, EventArgs e)
        {
            tagger();
        }

        private void copyTaggedImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Grab the folder from a dialog box
            var fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                // Display
                txtParameters.Text = "Copying your tagged files to specified location.  This will NOT overwrite existing files.\r\n\r\n";

                // Store the path selected
                string saveToPath = fbd.SelectedPath;

                // Save tagged images
                foreach (string s in taggedImages)
                {

                    if (File.Exists(saveToPath + "\\" + s) == false)
                    {
                        txtParameters.Text += "Copying: " + s + " to: " + saveToPath + "\r\n";
                        File.Copy(openPath + "\\" + s, saveToPath + "\\" + s);
                    }
                    else
                    {
                        txtParameters.Text += "Skipping, file already exists: " + s + " to: " + saveToPath + "\r\n";
                    }
                }
            }
        }


        private void picbImageDisplay_Click(object sender, MouseEventArgs e)
        {
            // Left click the image, so zoom in.
            if (e.Button == MouseButtons.Left)
            {
                // Ensure a picture is even loaded
                if (picbImageDisplay.Image == null) { return; }

                // If already in 'zoom' view mode (which is actually the fullsize view)
                if (picbImageDisplay.SizeMode == PictureBoxSizeMode.Zoom)
                {
                    // Change to non-zoom mode, called Normal.  This puts the image at its true 1:1 resolution and size.
                    picbImageDisplay.SizeMode = PictureBoxSizeMode.Normal;

                    // Resize the picturebox to match the new image size
                    picbImageDisplay.Width = picbImageDisplay.Image.Width;
                    picbImageDisplay.Height = picbImageDisplay.Image.Height;

                    // Put it at the center of the panel container
                    picbImageDisplay.Location = new Point((picbImageDisplay.Parent.ClientSize.Width / 2) - (picbImageDisplay.Width / 2),
                              (picbImageDisplay.Parent.ClientSize.Height / 2) - (picbImageDisplay.Height / 2));

                    // Refresh
                    picbImageDisplay.Refresh();

                    // debug text 
                    /*txtParameters.Text = "picb width: " + picbImageDisplay.Width.ToString() + "\r\n";
                    txtParameters.Text += "picb height: " + picbImageDisplay.Height.ToString() + "\r\n";
                    txtParameters.Text += "pan width: " + panMain.Width.ToString() + "\r\n";
                    txtParameters.Text += "pan height :" + panMain.Height.ToString() + "\r\n";
                    txtParameters.Text += "picb top: " + picbImageDisplay.Top.ToString() + "\r\n";
                    txtParameters.Text += "picb left: " + picbImageDisplay.Left.ToString() + "\r\n";*/
                }
                // Already in "Normal" 1:1 mode, so reset it to default view
                else
                {
                    // Reset our PB to zoomed mode at 0,0
                    resetPB();
                }
            }
            // Right click the image, so copy to clipboard
            else if (e.Button == MouseButtons.Right)
            {
                if (picbImageDisplay.Image != null)
                {
                    // Copy if image is loaded
                    Clipboard.SetImage(picbImageDisplay.Image);

                    // Status Update
                    updateStatusBox("Image copied to clipboard");
                }
            }
        }


        // Update the lblStatus label with passed text, and fade it out
        private void updateStatusBox(string s)
        {
            if (UIviewMode == "lightmode")
            {
                lblStatus.ForeColor = Color.Black;
            }
            else
            {
                lblStatus.ForeColor = SystemColors.ControlText;
            }

            lblStatus.Text = s;
            labelFader.Start();
        }


        // Fadeout timer
        private void labelFader_Tick(object sender, EventArgs e)
        {
            // Set the speed
            int fadingSpeed = 20;

            if (UIviewMode == "lightmode")
            {
                // Setup the color RGB to move from black to background color over time
                lblStatus.ForeColor = Color.FromArgb(lblStatus.ForeColor.R + fadingSpeed, lblStatus.ForeColor.G + fadingSpeed, lblStatus.ForeColor.B + fadingSpeed);

                // Stop when the color reaches where it needs to go
                if (lblStatus.ForeColor.R >= this.BackColor.R)
                {
                    labelFader.Stop();
                    lblStatus.ForeColor = this.BackColor;
                    lblStatus.Text = "";
                }
            }
            else
            {
                // Setup the color RGB to move from black to background color over time
                lblStatus.ForeColor = Color.FromArgb(lblStatus.ForeColor.R + fadingSpeed, lblStatus.ForeColor.G + fadingSpeed, lblStatus.ForeColor.B + fadingSpeed);

                // Stop when the color reaches where it needs to go
                if (lblStatus.ForeColor.R >= 200)
                {
                    labelFader.Stop();
                    lblStatus.ForeColor = this.BackColor;
                    lblStatus.Text = "";
                }
            }
        }


        // Resets the picturebox in the panel to normal view
        private void resetPB()
        {
            // Change dimensions to fit panel
            picbImageDisplay.Width = panMain.Width;
            picbImageDisplay.Height = panMain.Height;

            // Put the picturebox back where it belongs, at the top left of the panel
            picbImageDisplay.Top = 0;
            picbImageDisplay.Left = 0;

            // Change to zoom mode, which fits the image to the picturebox
            picbImageDisplay.SizeMode = PictureBoxSizeMode.Zoom;
        }


        // Detect movement in the picturebox
        private void picbImageDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // Simple null check, but should never be null anyways
            if (sender != null)
            {
                Control? c = sender as Control;             // Added "?" to allow nullable to correct intellisense error
                // Are we dragging the mouse with the button held down?
                if (isMouseDragging && c != null)
                {
                    // Adjust the coordinates of the picturebox
                    c.Top = e.Y + c.Top - yPos;
                    c.Left = e.X + c.Left - xPos;
                }
            }
        }

        // Detect mouse press
        private void picbImageDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            // If the middle button is pressed
            if (e.Button == MouseButtons.Middle)
            {
                // Turn on drag mode and get the mouse coordinates for the adjustment
                isMouseDragging = true;
                xPos = e.X;
                yPos = e.Y;
            }
        }

        // Detect mouse lift
        private void picbImageDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            // Turn off drag mode
            isMouseDragging = false;
        }



        private void panMain_Resize(object sender, EventArgs e)
        {
            resetPB();
        }

        private void btnCopyImage_Click(object sender, EventArgs e)
        {
            if (picbImageDisplay.Image != null)
            {
                // Copy if image is loaded
                Clipboard.SetImage(picbImageDisplay.Image);

                // Status Update
                updateStatusBox("Image copied to clipboard");
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshFolder();
        }

        private void refreshFolder()
        {
            // Go find images if the path is set
            if (openPath != "")
            {
                // Status Update
                updateStatusBox("Refreshing open path");

                findImagesInDirectory(openPath);
            }
        }

        private void createdDateToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle the column on or off by setting the appropriate bool based on the check value
            if (createdDateToolStripMenuItem.Checked == true)
            {
                createDateColumnActive = true;
            }
            if (createdDateToolStripMenuItem.Checked == false)
            {
                createDateColumnActive = false;
            }
            refreshFolder();
        }

        private void imageToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle the column on or off by setting the appropriate bool based on the check value
            if (imageToolStripMenuItem.Checked == true)
            {
                imageColumnActive = true;
            }
            if (imageToolStripMenuItem.Checked == false)
            {
                imageColumnActive = false;
            }
            refreshFolder();
        }


        private void modifiedDateToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle the column on or off by setting the appropriate bool based on the check value
            if (modifiedDateToolStripMenuItem.Checked == true)
            {
                modifiedDateColumnActive = true;
            }
            if (modifiedDateToolStripMenuItem.Checked == false)
            {
                modifiedDateColumnActive = false;
            }
            refreshFolder();
        }

        private void modelToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle the column on or off by setting the appropriate bool based on the check value
            if (modelToolStripMenuItem.Checked == true)
            {
                modelNameColumnActive = true;
            }
            if (modelToolStripMenuItem.Checked == false)
            {
                modelNameColumnActive = false;
            }
            refreshFolder();
        }

        private void modelHashToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle the column on or off by setting the appropriate bool based on the check value
            if (modelHashToolStripMenuItem.Checked == true)
            {
                modelHashColumnActive = true;
            }
            if (modelHashToolStripMenuItem.Checked == false)
            {
                modelHashColumnActive = false;
            }
            refreshFolder();
        }

        private void seedToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle the column on or off by setting the appropriate bool based on the check value
            if (seedToolStripMenuItem.Checked == true)
            {
                seedColumnActive = true;
            }
            if (seedToolStripMenuItem.Checked == false)
            {
                seedColumnActive = false;
            }
            refreshFolder();
        }


        private void setMenuChecks()
        {
            if (imageColumnActive == true) { imageToolStripMenuItem.Checked = true; } else { imageToolStripMenuItem.Checked = false; }
            if (createDateColumnActive == true) { createdDateToolStripMenuItem.Checked = true; } else { createdDateToolStripMenuItem.Checked = false; }
            if (modifiedDateColumnActive == true) { modifiedDateToolStripMenuItem.Checked = true; } else { modifiedDateToolStripMenuItem.Checked = false; }
            if (modelHashColumnActive == true) { modelHashToolStripMenuItem.Checked = true; } else { modelHashToolStripMenuItem.Checked = false; }
            if (modelNameColumnActive == true) { modelToolStripMenuItem.Checked = true; } else { modelToolStripMenuItem.Checked = false; }
            if (seedColumnActive == true) { seedToolStripMenuItem.Checked = true; } else { seedToolStripMenuItem.Checked = false; }
        }


        public async Task saveSettings()
        {
            string viewMode = "simple";
            if (dgvMain.Visible == true)
            {
                viewMode = "detailed";
            }

            string[] lines =
            {
                "PNG-SD-Info-Viewer Settings File.  Do not Modify!  Deleting this file will reset your settings.",
                "------------------",
                imageColumnActive.ToString(),
                filenameColumnActive.ToString(),
                createDateColumnActive.ToString(),
                modifiedDateColumnActive.ToString(),
                modelNameColumnActive.ToString(),
                modelHashColumnActive.ToString(),
                seedColumnActive.ToString(),
                viewMode,
                hSize.ToString(),
                wSize.ToString(),
                UIviewMode
            };
            try
            {
                await File.WriteAllLinesAsync("PNG-SD-Info-Viewer.cfg", lines);
                updateStatusBox("Settings saved to disk.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save file." + ex.ToString());
            }
        }

        private void loadSettings()
        {
            // Check for file
            if (File.Exists("PNG-SD-Info-Viewer.cfg") == false)
            {
                return;
            }

            try
            {
                // Read file
                string[] lines = System.IO.File.ReadAllLines(@"PNG-SD-Info-Viewer.cfg");

                if (lines.Length != 13)
                {
                    // unexpected cfg length
                    MessageBox.Show("Your config file is an unexpected length.  Loading default.");
                    return;
                }

                imageColumnActive = bool.Parse(lines[2]);
                filenameColumnActive = bool.Parse(lines[3]);
                createDateColumnActive = bool.Parse(lines[4]);
                modifiedDateColumnActive = bool.Parse(lines[5]);
                modelNameColumnActive = bool.Parse(lines[6]);
                modelHashColumnActive = bool.Parse(lines[7]);
                seedColumnActive = bool.Parse(lines[8]);
                string viewMode = lines[9];
                hSize = int.Parse(lines[10]);
                wSize = int.Parse(lines[11]);
                UIviewMode = lines[12];

                if (viewMode == "detailed")
                {
                    dgvMain.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Your config file is corrupt.  It is suggested to remove it.  A new one will be generated the next time you launch the program." + ex.ToString());
                return;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadSettings();
        }



        private void saveSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveSettings();
        }



        public void SetWallpaper(Style style, bool clearWallpaper)
        {
            // Ensure we have an image to use, or that we are clearing it to blank
            if (picbImageDisplay.Image == null && clearWallpaper == false)
            {
                return;
            }

            // Setup variables for system API call
            const int SPI_SETDESKWALLPAPER = 20;
            const int SPIF_UPDATEINIFILE = 0x01;
            const int SPIF_SENDWININICHANGE = 0x02;
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

            // Set path to image
            // Path via listbox
            string selectedImage = lstbFilelist.GetItemText(lstbFilelist.SelectedItem);

            // Path via DGV if seen
            if (dgvMain.Visible == true)
            {
                foreach (DataGridViewRow selectedRow in dgvMain.SelectedRows)
                {
                    // If the value in the filename column isn't null (and it shouldn't be, it should have the filename text), then store the filename as a string.
                    var dataGridViewColumn = dgvMain.Columns["Filename:"];
                    int filenameIndex = 0;
                    if (dataGridViewColumn != null)
                    {
                        filenameIndex = dgvMain.Columns.IndexOf(dataGridViewColumn);
                    }

                    if (dgvMain[filenameIndex, selectedRow.Index].Value != null)
                    {
                        selectedImage = dgvMain[filenameIndex, selectedRow.Index].Value.ToString()!;
                    }

                }
            }

            string tempPath = openPath + "\\" + selectedImage;





            // Check for clear
            if (clearWallpaper == true)
            {
                tempPath = "";
            }

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true)!;
            if (style == Style.Stretched)
            {
                key.SetValue(@"WallpaperStyle", 2.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (style == Style.Centered)
            {
                key.SetValue(@"WallpaperStyle", 1.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (style == Style.Tiled)
            {
                key.SetValue(@"WallpaperStyle", 1.ToString());
                key.SetValue(@"TileWallpaper", 1.ToString());
            }

            if (style == Style.Fill)
            {
                key.SetValue(@"WallpaperStyle", 10.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (style == Style.Fit)
            {
                key.SetValue(@"WallpaperStyle", 6.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (style == Style.Span)
            {
                key.SetValue(@"WallpaperStyle", 22.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, tempPath, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);


            updateStatusBox("Setting Wallpaper");
        }

        public enum Style : int
        {
            Tiled,
            Centered,
            Stretched,
            Span,
            Fill,
            Fit
        }

        private void centeredToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWallpaper(Style.Centered, false);
        }

        private void stretchedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWallpaper(Style.Stretched, false);
        }

        private void tiledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWallpaper(Style.Tiled, false);
        }

        private void clearWallpaperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWallpaper(Style.Centered, true);
        }

        private void fillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWallpaper(Style.Fill, false);
        }

        private void fitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWallpaper(Style.Fit, false);
        }

        private void spanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWallpaper(Style.Span, false);
        }

        private void lightMode()
        {


            // Form
            this.BackColor = SystemColors.Control;

            // Panels
            panMain.BackColor = SystemColors.Control;

            splitContainer1.BackColor = SystemColors.ControlLight;
            splitContainer1.Panel1.BackColor = SystemColors.Control;
            splitContainer1.Panel2.BackColor = SystemColors.Control;


            splitContainer2.BackColor = SystemColors.ControlLight;
            splitContainer2.Panel1.BackColor = SystemColors.Control;
            splitContainer2.Panel2.BackColor = SystemColors.Control;

            // Menu
            menuStrip1.BackColor = SystemColors.ControlLight;
            menuStrip1.ForeColor = SystemColors.ControlText;

            // Buttons
            btnCopy.FlatStyle = FlatStyle.Standard;
            btnCopy.BackColor = SystemColors.Control;
            btnCopy.ForeColor = SystemColors.ControlText;

            btnCopyImage.FlatStyle = FlatStyle.Standard;
            btnCopyImage.BackColor = SystemColors.Control;
            btnCopyImage.ForeColor = SystemColors.ControlText;

            btnCopyPrompt.FlatStyle = FlatStyle.Standard;
            btnCopyPrompt.BackColor = SystemColors.Control;
            btnCopyPrompt.ForeColor = SystemColors.ControlText;

            btnSelectFolder.FlatStyle = FlatStyle.Standard;
            btnSelectFolder.BackColor = SystemColors.Control;
            btnSelectFolder.ForeColor = SystemColors.ControlText;

            button1.FlatStyle = FlatStyle.Standard;
            button1.BackColor = SystemColors.Control;
            button1.ForeColor = SystemColors.ControlText;


            // Labels
            lblFilename.BackColor = SystemColors.Control;
            lblFilename.ForeColor = SystemColors.ControlText;

            lblFilesInFolder.BackColor = SystemColors.Control;
            lblFilesInFolder.ForeColor = SystemColors.ControlText;

            lblFolderSelected.BackColor = SystemColors.Control;
            lblFolderSelected.ForeColor = SystemColors.ControlText;

            lblImage.BackColor = SystemColors.Control;
            lblImage.ForeColor = SystemColors.ControlText;

            lblLoading.BackColor = SystemColors.Control;
            lblLoading.ForeColor = SystemColors.ControlText;

            lblParameters.BackColor = SystemColors.Control;
            lblParameters.ForeColor = SystemColors.ControlText;

            lblStatus.BackColor = SystemColors.Control;
            lblStatus.ForeColor = SystemColors.ControlText;

            // Tag box
            chkTag.BackColor = SystemColors.Control;
            chkTag.ForeColor = SystemColors.ControlText;
            chkTag.FlatStyle = FlatStyle.Standard;

            // Lists
            lstbFilelist.BackColor = SystemColors.Window;
            lstbFilelist.ForeColor = SystemColors.WindowText;
            lstbFilelist.BorderStyle = BorderStyle.Fixed3D;


            dgvMain.BackColor = SystemColors.Control;
            dgvMain.ForeColor = SystemColors.ControlText;
            dgvMain.BackgroundColor = SystemColors.ControlDark;


            dgvMain.DefaultCellStyle.ForeColor = SystemColors.ControlText;
            dgvMain.DefaultCellStyle.BackColor = SystemColors.Window;
            dgvMain.EnableHeadersVisualStyles = true;

            dgvMain.DefaultCellStyle.SelectionBackColor = Color.Gray;


            // Txts
            txtParameters.BackColor = SystemColors.Window;
            txtParameters.ForeColor = SystemColors.WindowText;
            txtParameters.BorderStyle = BorderStyle.Fixed3D;


            UIviewMode = "lightmode";
        }

        private void darkMode()
        {
            // Form
            this.BackColor = Color.Black;

            // Panels
            panMain.BackColor = Color.Black;

            Color bars = Color.FromArgb(30, 30, 30);

            splitContainer1.BackColor = bars;
            splitContainer1.Panel1.BackColor = Color.Black;
            splitContainer1.Panel2.BackColor = Color.Black;


            splitContainer2.BackColor = Color.Black;
            splitContainer2.Panel1.BackColor = Color.Black;
            splitContainer2.Panel2.BackColor = Color.Black;

            // Menu
            menuStrip1.BackColor = Color.Black;
            menuStrip1.ForeColor = Color.DarkGray;


            // Buttons
            btnCopy.FlatStyle = FlatStyle.Flat;
            btnCopy.FlatAppearance.BorderColor = Color.DimGray;
            btnCopy.BackColor = Color.DimGray;
            btnCopy.ForeColor = Color.LightGray;

            btnCopyImage.FlatStyle = FlatStyle.Flat;
            btnCopyImage.FlatAppearance.BorderColor = Color.DimGray;
            btnCopyImage.BackColor = Color.DimGray;
            btnCopyImage.ForeColor = Color.LightGray;

            btnCopyPrompt.FlatStyle = FlatStyle.Flat;
            btnCopyPrompt.FlatAppearance.BorderColor = Color.DimGray;
            btnCopyPrompt.BackColor = Color.DimGray;
            btnCopyPrompt.ForeColor = Color.LightGray;

            btnSelectFolder.FlatStyle = FlatStyle.Flat;
            btnSelectFolder.FlatAppearance.BorderColor = Color.DimGray;
            btnSelectFolder.BackColor = Color.DimGray;
            btnSelectFolder.ForeColor = Color.LightGray;

            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderColor = Color.DimGray;
            button1.BackColor = Color.DimGray;
            button1.ForeColor = Color.LightGray;


            // Labels
            lblFilename.BackColor = Color.Black;
            lblFilename.ForeColor = Color.LightGray;

            lblFilesInFolder.BackColor = Color.Black;
            lblFilesInFolder.ForeColor = Color.LightGray;

            lblFolderSelected.BackColor = Color.Black;
            lblFolderSelected.ForeColor = Color.LightGray;

            lblImage.BackColor = Color.Black;
            lblImage.ForeColor = Color.LightGray;

            lblLoading.BackColor = Color.Black;
            lblLoading.ForeColor = Color.LightGray;

            lblParameters.BackColor = Color.Black;
            lblParameters.ForeColor = Color.LightGray;

            lblStatus.BackColor = Color.Black;
            lblStatus.ForeColor = Color.LightGray;

            // Tag box
            chkTag.BackColor = Color.Black;
            chkTag.ForeColor = Color.LightGray;
            chkTag.FlatStyle = FlatStyle.Flat;

            // Lists
            lstbFilelist.BackColor = Color.Black;
            lstbFilelist.ForeColor = Color.Gray;
            lstbFilelist.BorderStyle = BorderStyle.None;


            dgvMain.BackColor = Color.Black;
            dgvMain.ForeColor = Color.LightGray;
            dgvMain.BackgroundColor = Color.Black;

            dgvMain.ColumnHeadersDefaultCellStyle.ForeColor = Color.LightGray;
            dgvMain.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dgvMain.EnableHeadersVisualStyles = false;
            dgvMain.DefaultCellStyle.ForeColor = Color.DimGray;
            dgvMain.DefaultCellStyle.BackColor = Color.Black;


            // Txts
            txtParameters.BackColor = Color.Black;
            txtParameters.ForeColor = Color.Gray;
            txtParameters.BorderStyle = BorderStyle.FixedSingle;

            UIviewMode = "darkmode";

        }

        private void lightModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lightMode();
        }

        private void darkModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            darkMode();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void folderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Grab the folder from a dialog box
            var fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                // TODO - do I need this?  Got a new folder so clear the stuffs
                //lstbFilelist.Items.Clear();
                //txtParameters.Text = "";
                //picbImageDisplay.Image = null;

                // Store the path selected, it comes in handy.
                openPath = fbd.SelectedPath;

                // Show the selected path in the UI
                lblFolderSelected.Text = openPath;

                // Go find images!
                findImagesInDirectory(fbd.SelectedPath);
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            txtParameters.Text = "(Modified by Toad 7/10/2023). PNG-SD-Info-Viewer is a program designed to quickly allow the browsing of PNG files with associated metadata from Stable Diffusion generated images.\r\nIt now also allows quick image tagging so favorites can be copied out to a new location.\r\nThere is a filename list view, and, an image preview view.  Image preview size can be adjusted.\r\nMouse scrolling over the image will go to next or previous image.\r\nLeft-clicking on the image will zoom.\r\nHolding middle-mouse button and dragging will move the image.\r\nRight-clicking the image will copy the image to your clipboard.\r\n - By Omnia, the Garlic Cookie\r\nhttps://github.com/GarlicCookie/PNG-SD-Info-Viewer\r\nGNU GPL3";
        }
    }
}
