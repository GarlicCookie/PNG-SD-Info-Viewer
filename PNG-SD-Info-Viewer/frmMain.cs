using MetadataExtractor;
using MetadataExtractor.Formats.FileSystem;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace PNG_SD_Info_Viewer
{
    public partial class frmMain : Form
    {

        List<string> Imagefiles = new List<string>();
        
        
        string openPath = "test";



        public frmMain()
        {
            InitializeComponent();
            
        }

        private void findImagesInDirectory(string path)
        {
            

            // Get all the png files from the provided path and put into array
            
            DirectoryInfo dinfo = new DirectoryInfo(path);
            FileInfo[] Files = dinfo.GetFiles("*.png");
            
            // Populate the listbox
            foreach (FileInfo file in Files)
            {
                lstbFilelist.Items.Add(file.Name);
            }

            /*foreach (string s in files)
            {
                if (s.EndsWith(".jpg") || s.EndsWith(".png")) //add more format files here
                {
                    Imagefiles.Add(s);
                }
            }


            try
            {
                pictureBox1.ImageLocation = Imagefiles.First();
            }
            catch { MessageBox.Show("No files found!"); }*/

        }



        private void btnSelectFolder_Click(object sender, EventArgs e)
        {

            // Grab the folder
            var fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {

                // Got a new folder so clear the stuffs
                // Clear the stuffs
                lstbFilelist.Items.Clear();
                txtParameters.Text = "";
                picbImageDisplay.Image = null;


                // Store the path selected
                openPath = fbd.SelectedPath;
                lblFolderSelected.Text = openPath;

                // Pull up the image list in the folder
                findImagesInDirectory(fbd.SelectedPath);
            }
        }

        private void lstbFilelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear the stuffs
            txtParameters.Text = "";


            string selectedImage = lstbFilelist.GetItemText(lstbFilelist.SelectedItem);

            picbImageDisplay.ImageLocation = openPath + "\\" + selectedImage;



            // EXIF
            IEnumerable<MetadataExtractor.Directory> directories = ImageMetadataReader.ReadMetadata(openPath + "\\" + selectedImage);


            foreach (var directory in directories)
                foreach (var tag in directory.Tags)
                {
                    if (tag.Name == "Textual Data")
                    {
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

                        //txtParameters.Text += ($"{tag.Description}");
                        txtParameters.Text += parsed;
                    }
                }

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtParameters.Text);
        }
    }
}