using MLForm.MLModel;
using MLtest;
using System.Diagnostics;
using System.Reflection;

namespace MLForm
{
    public partial class Form1 : Form
    {
        //TODO: switch to faster model or model with more classes? adjust program structure to make model swaps easier
        private static DirectoryInfo? inputDir;
        private static DirectoryInfo? outputDir;
        private static string modelPath = "";
        private static Func<object, bool> NullResultCheck = (p) => { if (p is null) return true; else return false; };
        
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
            inputDir.GetFiles().ToList().ForEach(f => f.Delete());
            outputDir.GetFiles().ToList().ForEach(f => f.Delete());

        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            //TODO: keep track of the submitted image and only ingest/process that one instead of everything in the folder
            openFileDialog.InitialDirectory = inputDir.FullName;   
            //MessageBox.Show(openFileDialog.InitialDirectory);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new(openFileDialog.FileName);
                File.Copy(Path.Combine(openFileDialog.FileName), inputDir.FullName + $"\\ML_{fi.Name}");
                pbFresh.Image = new Bitmap(inputDir.FullName + $"\\ML_{fi.Name}");
            }
        }

        private void BtnDetect_Click(object sender, EventArgs e)
        {
            Bitmap src = pbFresh.Image as Bitmap ?? new Bitmap(1,1) { Tag="null source image" };
            MLProcessData startState = new()
            {
                Model = null,
                Results = null,
                Image = src,
                ModelPath = Form1.modelPath,
                InputPath = inputDir.FullName,
                OutputPath = outputDir.FullName
                //NextStage = MLProcessData.MLStage.MLExecutor
            };
            MLProcessData endState = MLExecutor.Start(startState);
            //MLExecutor.Run(modelPath, inputDir.FullName, outputDir.FullName, out Bitmap dst);
            pbMLd.Image = endState.Image;
            lblPredict.Text = $"Predictions: {(NullResultCheck(endState.Results) ? 0 : endState.Results.Count)}";
            //pbMLd.Image = endState.image;
        }
    }
}
