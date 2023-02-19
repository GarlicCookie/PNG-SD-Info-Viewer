using MetadataExtractor;
using MetadataExtractor.Formats.FileSystem;
using System.Collections;
using System.ComponentModel;
using System.Data.Common;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace PNG_SD_Info_Viewer
{
    public partial class frmMain : Form
    {
        // ImageList object, used to fill in a DataGridView for image list mode (no longer used)
        //ImageList imgList = new ImageList();

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

        // Launchpoint
        public frmMain()
        {
            InitializeComponent();

            // Empty some of the textboxes.
            lblFolderSelected.Text = "";
            lblFilename.Text = "";

            // Fire up the mousewheel detection on the picturebox
            picbImageDisplay.MouseWheel += PicbImageDisplay_MouseWheel;
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
                    if (dgvCurrentRowIndex != dgvLength-1) 
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
                DataGridViewTextBoxColumn txtColumn = new DataGridViewTextBoxColumn();
                dgvMain.Columns.Add(iconColumn);
                dgvMain.Columns.Add(txtColumn);
                iconColumn.Name = "Images";
                iconColumn.HeaderText = "Images:";
                iconColumn.ImageLayout = DataGridViewImageCellLayout.Normal;
                //iconColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                iconColumn.Description = "Zoomed";
                txtColumn.Name = "Filename:";
                txtColumn.HeaderText = "Filename:";
            }

            // Get all the png files from the provided path and put into array
            DirectoryInfo dinfo = new DirectoryInfo(path);
            FileInfo[] Files = dinfo.GetFiles("*.png");

            // Populate items into the Listbox, and the ImageList which we'll use for the DGV, using each file
            foreach (FileInfo file in Files)
            {
                // Add item to listbox
                lstbFilelist.Items.Add(file.Name);

                // Add filename to imgList object, with the full path as a key.  Might use the keyname later to lookup an image.  Only do this if we are using a DGV to save CPU and memory!
                if (dgvMain.Visible == true)
                {
                    // Add image to ImageList using memory optimization method.  Converts to resized bitmap then adds.
                    // inprogress: check fullname length!                

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

                    // If we didn't set our image pathlength as bad, continue.
                    if (badImage == false)
                    {
                        // Convert our image to a smaller bitmap, then add it to the ImageList
                        using (var tempImage = Image.FromFile(file.FullName))       //FromFile method has a path limit!
                        {
                            int hSize2 = hSize;
                            int wSize2 = wSize;

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
                    // If we do not have a good image because the filepath is too long, show error
                    else
                    {
                        MessageBox.Show(errorNotifier);
                    }
                    
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
                    // Add a row and set its value to the image in first column, and filename in second
                    dgvMain.Rows.Add();
                    //dgvMain.Rows[j].Cells[0].Value = imgList.Images[j];
                    dgvMain.Rows[j].Cells[0].Value = arList[j];
                    dgvMain.Rows[j].Cells[1].Value = Files[j].Name;

                    // Update cellsize for each row
                    DataGridViewCell cell = dgvMain.Rows[j].Cells[0];

                    // Set the Row height.
                    dgvMain.Rows[cell.RowIndex].Height = hSize;

                    // Set the Column height.
                    dgvMain.Columns[0].Width = wSize;
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
                // If the value in the second column isn't null (and it shouldn't be, it should have the filename text), then store the filename as a string.
                if (dgvMain[1, selectedRow.Index].Value != null)
                {
                    selectedImage = dgvMain[1, selectedRow.Index].Value.ToString()!;
                }
            }

            // Update our picturebox and parameters boxes!
            updateBoxes(selectedImage);
        }


        // Call this when a new row is selected in our DataGridView - TODO:  Delete this*************
        private void dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the stuffs
            txtParameters.Text = "";

            // Set a string for the selected image filename
            string selectedImage = "";
            
            // Pull out any selected rows. There should only be one since we limit it to single row selection.  TODO: Replace the foreach, we don't need to iterate.
            foreach (DataGridViewRow selectedRow in dgvMain.SelectedRows)
            {
                // If the value in the second column isn't null (and it shouldn't be, it should have the filename text), then store the filename as a string.
                if (dgvMain[1, selectedRow.Index].Value.ToString() != null)
                {
                    selectedImage = dgvMain[1, selectedRow.Index].Value.ToString()!;
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
            txtParameters.Text = "PNG-SD-Info-Viewer is a program designed to quickly allow the browsing of PNG files with associated metadata from Stable Diffusion generated images.\r\nIt now also allows quick image tagging so favorites can be copied out to a new location.\r\nThere is a filename list view, and, an image preview view.  Image preview size can be adjusted.\r\nMouse scrolling over the image will go to next or previous image.\r\nLeft-clicking on the image will zoom.\r\nHolding middle-mouse button and dragging will move the image.\r\n - By Omnia the Garlic Cookie\r\nhttps://github.com/GarlicCookie/PNG-SD-Info-Viewer\r\nGNU GPL3";
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
            wSize= 64;
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
            // Copies to clipboard
            Clipboard.SetText(txtParameters.Text);
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
                if ((component.Length >=12) && (component.Substring(0, 12) == "parameters: "))
                {
                    // Copies to clipboard
                    Clipboard.SetText(component);
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
            Clipboard.SetText(stringToCopy);
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
                    // If the value in the second column isn't null (and it shouldn't be, it should have the filename text), then store the filename as a string.
                    if (dgvMain[1, selectedRow.Index].Value.ToString() != null)
                    {
                        selectedImage = dgvMain[1, selectedRow.Index].Value.ToString()!;
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
                // If already in 'zoom' view mode (which is actually the fullsize view)
                if (picbImageDisplay.SizeMode == PictureBoxSizeMode.Zoom)
                {
                    // Change to non-zoom mode, called Normal.  This puts the image at its true 1:1 resolution and size.
                    picbImageDisplay.SizeMode = PictureBoxSizeMode.Normal;
                    
                    // Resize the picturebox to match the new image size
                    picbImageDisplay.Width = picbImageDisplay.Image.Width;
                    picbImageDisplay.Height= picbImageDisplay.Image.Height;

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
            if (sender != null) { 
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
    }

}