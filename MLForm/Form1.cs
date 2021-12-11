using MLForm.MLModel;
using MLtest;
using System.Diagnostics;
using System.Reflection;

namespace MLForm
{
    public partial class Form1 : Form
    {
        public static DirectoryInfo? inputDir;
        public static DirectoryInfo? outputDir;
        public static string modelPath;
        MLExecutor mle = new();
        
        public Form1()
        {
            InitializeComponent();
            inputDir = new DirectoryInfo(Assembly.GetExecutingAssembly().Location)
                .Parent.Parent.Parent.Parent
                .GetDirectories("Assets").FirstOrDefault()
                .GetDirectories("InputImages").FirstOrDefault();
            if (inputDir is null)
            {
                throw new DirectoryNotFoundException("Input is null!");
            }
            outputDir = new DirectoryInfo(Assembly.GetExecutingAssembly().Location)
                .Parent.Parent.Parent.Parent
                .GetDirectories("Assets").FirstOrDefault()
                .GetDirectories("OutputImages").FirstOrDefault();
            if (outputDir is null)
            {
                throw new DirectoryNotFoundException("Output is null!");
            }

            modelPath = new DirectoryInfo(Assembly.GetExecutingAssembly().Location)
                .Parent.Parent.Parent.Parent
                .GetDirectories("Assets").FirstOrDefault()
                .GetFiles("yolov4.onnx").FirstOrDefault()
                .FullName;

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = inputDir.FullName;   
            //MessageBox.Show(openFileDialog.InitialDirectory);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(openFileDialog.FileName);
                File.Copy(Path.Combine(openFileDialog.FileName), inputDir.FullName + $"\\ML_{fi.Name}");
                pbFresh.Image = new Bitmap(inputDir.FullName + $"\\ML_{fi.Name}");
            }
        }

        private void btnDetect_Click(object sender, EventArgs e)
        {
            Bitmap src = pbFresh.Image as Bitmap;
            Bitmap dst = new Bitmap(src);
            mle.Run(modelPath, inputDir.FullName, outputDir.FullName, out dst);
            pbMLd.Image = dst;
        }
    }
}
