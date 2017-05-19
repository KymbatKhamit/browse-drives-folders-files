using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Browse_drives__files__directories
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (DriveInfo di in DriveInfo.GetDrives())
                driveList.Items.Add(di);
        }

        private void driveList_SelectedIndexChanged(object sender, EventArgs e)
        {
            foldersList.Items.Clear();

            try
            {
                DriveInfo drive = (DriveInfo)driveList.SelectedItem;

                foreach (DirectoryInfo dirInfo in drive.RootDirectory.GetDirectories())
                    foldersList.Items.Add(dirInfo);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void foldersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            filesList.Items.Clear();

            DirectoryInfo dir = (DirectoryInfo)foldersList.SelectedItem;

            foreach (FileInfo fi in dir.GetFiles())
                filesList.Items.Add(fi);
        }
    }
}
