using System.Reflection;

namespace MLForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = ProjectFolders.inputDir.FullName;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(openFileDialog.FileName);
                File.Copy(Path.Combine(openFileDialog.FileName), ProjectFolders.inputDir.FullName + $"{fi.Name}_ML{fi.Extension}");

            }
        }
    }
}