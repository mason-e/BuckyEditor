using System;
using System.Windows.Forms;

namespace BuckyEditor
{
    public partial class OpenFile : Form
    {
        public OpenFile()
        {
            InitializeComponent();
        }

        private void tbFileName_Click(object sender, EventArgs e)
        {
            ofOpenDialog.Filter = "";
            if (ofOpenDialog.ShowDialog() == DialogResult.OK)
            {
                tbFileName.Text = ofOpenDialog.FileName;
            }
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            fileName = tbFileName.Text;
            string lastConfig = Properties.Settings.Default["ConfigName"].ToString();
            configName = lastConfig != "" ? lastConfig : $"{FormMain.settingsDir}\\Green\\g1.cs";
            DialogResult = DialogResult.OK;
            Close();

            Properties.Settings.Default["FileName"] = fileName;
            Properties.Settings.Default.Save();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public static string fileName = "";
        public static string configName = "";

        private void OpenFile_Load(object sender, EventArgs e)
        {
            tbFileName.Text = Properties.Settings.Default["FileName"].ToString();
        }
    }
}
