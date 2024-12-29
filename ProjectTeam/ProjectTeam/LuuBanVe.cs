using ProjectTeam.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTeam
{
    public partial class LuuBanVe : Form
    {
        private user_info user;
        private string path;
        string ftpHost = ConfigurationManager.AppSettings["FtpUrl"];

        public LuuBanVe(user_info truyenUser)
        {
            InitializeComponent();
            user = new user_info();
            user = truyenUser;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void DownloadFromFTP(string localFilePath, string ftpUrl, string username, string password)
        {
            using (WebClient client = new WebClient())
            {
                // Set FTP credentials
                client.Credentials = new NetworkCredential(username, password);

                // Download the file
                client.DownloadFile(ftpUrl, localFilePath);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            //string path = @"C:\\Users\\ASUS\\Documents\\downloaded_screenshot.png";

            //DisplayImage(path, pictureBox1);
            DisplayUserImages(user.user_id, panel1);
        }

        public void DisplayUserImages(int userId, System.Windows.Forms.Panel imagePanel)
        {
            // Example of image filenames pattern: userId_image1.png, userId_image2.png, etc.
            List<string> fileUrls = GetUploadedImageUrlsForUser();  // Retrieve a list of file URLs from FTP server

            // Clear previous images from the panel
            imagePanel.Controls.Clear();

            int x = 0;
            int y = 0;
            int padding = 10;

            foreach (var fileUrl in fileUrls)
            {
                if (!fileUrl.Contains(userId.ToString()))
                {
                    continue;
                }
                string localPath = Path.Combine(path, Path.GetFileName(fileUrl)); //
                //string ftpUrl = $"ftp://eu-central-1.sftpcloud.io/uploads/{fileUrl}";
                string ftpUrl = $"ftp://103.216.118.185/{user.user_id}/screen/{fileUrl}";

                // Download each image
                DownloadFromFTP(localPath, ftpUrl, "", "");

                // Create a PictureBox to display the image
                PictureBox pictureBox = new PictureBox
                {
                    Image = System.Drawing.Image.FromFile(localPath),  // Load image from local file
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle,
                    Width = 300,  // Set appropriate size
                    Height = 300,
                    Location = new System.Drawing.Point(x, y)
                };

                Label fileNameLabel = new Label
                {
                    Text = fileUrl,
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new System.Drawing.Point(x, y + pictureBox.Height + 5) // Position below the PictureBox
                };

                // Center the label below the PictureBox
                fileNameLabel.Width = pictureBox.Width;
                fileNameLabel.Location = new System.Drawing.Point(
                    pictureBox.Location.X + (pictureBox.Width - fileNameLabel.Width) / 2,
                    pictureBox.Location.Y + pictureBox.Height + 5
                );

                // Add PictureBox and Label to the panel
                imagePanel.Controls.Add(pictureBox);
                imagePanel.Controls.Add(fileNameLabel);


                x += pictureBox.Width + padding;

                // Move to the next row if the current row is full
                if (x + pictureBox.Width > imagePanel.Width)
                {
                    x = 0; // Reset x to start a new row
                    y += pictureBox.Height + padding;
                }
            }
        }

        private List<string> GetUploadedImageUrlsForUser()
        {
            // In a real-world application, you would retrieve the list from the FTP server
            // Here we use a placeholder list for demonstration purposes.

           // string ftpUrl = "ftp://eu-central-1.sftpcloud.io/uploads/";
            
            string ftpUrl = $"{ftpHost}{user.user_id}/screen/";
            List<string> imageUrls = ListFilesOnFtp(ftpUrl, "", "");
            string list_file = "";

            foreach (string fileUrl in imageUrls)
            {
                list_file += fileUrl + "\n";
            }

            return imageUrls;
        }

        public List<string> ListFilesOnFtp(string ftpUrl, string username, string password)
        {
            List<string> fileList = new List<string>();


            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrl);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = new NetworkCredential(username, password);

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    fileList.Add(line);  // Add each file in the directory
                }
            }

            return fileList;
        }

        private void LuuBanVe_Load(object sender, EventArgs e)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Directory.GetParent(basePath).Parent.Parent.FullName;
            path = Path.Combine(projectDirectory, "Download");
            
            
        }
    }
}
