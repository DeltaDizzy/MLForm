using MLForm.MLModel;
using MLtest;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace MLForm
{
    public partial class Form1 : Form
    {
        //TODO: switch to faster model or model with more classes? adjust program structure to make model swaps easier
        private static DirectoryInfo? inputDir;
        private static DirectoryInfo? outputDir;
        private static string modelPath = "";
        
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
            foreach (var file in inputDir.GetFiles())
            {
                file.Delete();
            }
            foreach (var file in outputDir.GetFiles())
            {
                file.Delete();
            }

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
            //Bitmap src = pbFresh.Image as Bitmap ?? new Bitmap(1,1) { Tag="null source image" };
            MLExecutor.Run(modelPath, inputDir.FullName, outputDir.FullName, out Bitmap dst);
            pbMLd.Image = dst;
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach(string s in _classNames.OrderBy(x => x))
            {
                sb.Append($"{s.ToTitleCase()}, ");
            }
            sb.Remove(sb.Length - 2, 2);
            MessageBox.Show(sb.ToString());
        }

        private static readonly string[] _classNames = new string[]
        {
            "person", "bicycle", "car", "motorbike", "aeroplane", "bus", "train", "truck", "boat", "traffic light", "fire hydrant", "stop sign", "parking meter",
            "bench", "bird", "cat", "dog", "horse", "sheep", "cow", "elephant", "bear", "zebra", "giraffe", "backpack", "umbrella", "handbag", "tie", "suitcase",
            "frisbee", "skis", "snowboard", "sports ball", "kite", "baseball bat", "baseball glove", "skateboard", "surfboard", "tennis racket", "bottle", "wine glass",
            "cup", "fork", "knife", "spoon", "bowl", "banana", "apple", "sandwich", "orange", "broccoli", "carrot", "hot dog", "pizza", "donut", "cake", "chair", "sofa",
            "pottedplant", "bed", "diningtable", "toilet", "tvmonitor", "laptop", "mouse", "remote", "keyboard", "cell phone", "microwave", "oven", "toaster", "sink",
            "refrigerator", "book", "clock", "vase", "scissors", "teddy bear", "hair drier", "toothbrush"
        };
    }
}
