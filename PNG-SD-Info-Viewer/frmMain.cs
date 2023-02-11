using MetadataExtractor;
using MetadataExtractor.Formats.FileSystem;
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
        // ImageList object, used to fill in a DataGridView for image list mode
        ImageList imgList = new ImageList();
        
        // A string to hold the open path
        string openPath = "";
        
        // Default size of the image previews in image list mode
        int wSize = 128;
        int hSize = 128;


        // Launchpoint
        public frmMain()
        {
            InitializeComponent();

            // Empty some of the textboxes.
            lblFolderSelected.Text = "";
            lblFilename.Text = "";
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
            lstbFilelist.Items.Clear();
            dgvMain.DataSource = null;
            dgvMain.Columns.Clear();
            dgvMain.Rows.Clear();
            imgList.Images.Clear();
            txtParameters.Text = "";
            picbImageDisplay.Image = null;

            // Set the side of the images in the imagelist
            imgList.ImageSize = new Size(wSize, hSize);

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
                    imgList.Images.Add(file.FullName, Image.FromFile(file.FullName));
                }
            }

            // Add items to the DGV if it is active
            if (dgvMain.Visible == true)
            {
                for (int j = 0; j < imgList.Images.Count; j++)
                {
                    // Add a row and set its value to the image in first column, and filename in second
                    dgvMain.Rows.Add();
                    dgvMain.Rows[j].Cells[0].Value = imgList.Images[j];
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


        // Call this when a new row is selected in our DataGridView
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

            // Show the selected filename on the UI
            lblFilename.Text = selectedImage;

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
            imgList.Dispose();
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
            txtParameters.Text = "PNG-SD-Info-Viewer is a program designed to quickly allow the browsing of PNG files with associated metadata from Stable Diffusion generated images.\r\n - By Omnia the Garlic Cookie\r\nhttps://github.com/GarlicCookie/PNG-SD-Info-Viewer\r\nGNU GPL3";
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
    }

}