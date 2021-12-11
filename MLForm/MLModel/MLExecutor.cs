using Microsoft.ML;
using MLtest;
using MLtest.DataModel;
using System.Drawing.Imaging;

namespace MLForm.MLModel
{
    public class MLExecutor
    {

        private static readonly string[] _classNames = new string[] 
        {
            "person", "bicycle", "car", "motorbike", "aeroplane", "bus", "train", "truck", "boat", "traffic light", "fire hydrant", "stop sign", "parking meter",
            "bench", "bird", "cat", "dog", "horse", "sheep", "cow", "elephant", "bear", "zebra", "giraffe", "backpack", "umbrella", "handbag", "tie", "suitcase",
            "frisbee", "skis", "snowboard", "sports ball", "kite", "baseball bat", "baseball glove", "skateboard", "surfboard", "tennis racket", "bottle", "wine glass",
            "cup", "fork", "knife", "spoon", "bowl", "banana", "apple", "sandwich", "orange", "broccoli", "carrot", "hot dog", "pizza", "donut", "cake", "chair", "sofa",
            "pottedplant", "bed", "diningtable", "toilet", "tvmonitor", "laptop", "mouse", "remote", "keyboard", "cell phone", "microwave", "oven", "toaster", "sink",
            "refrigerator", "book", "clock", "vase", "scissors", "teddy bear", "hair drier", "toothbrush" 
        };

        

        public static MLProcessData Start(MLProcessData state)
        {
            List<Bitmap> predictedImages = new();
        }

        public static void Run(string modelPath, string inputPath, string outputPath, out Bitmap bm)
        {
            
            Trainer trainer = new();
            // build and train model
            ITransformer? trainedModel = trainer.ApplyModel(modelPath);
            //create predictor
            Predictor predictor = new(trainedModel);
            //run predictions
            DirectoryInfo di = new(inputPath);
            FileInfo[] images = di.GetFiles("ML_*.*");
            foreach (FileInfo file in images)
            {
                using (Bitmap img = new(Image.FromFile(Path.Combine(inputPath, file.Name))))
                {
                    ImagePrediction prediction = predictor.Predict(img);
                    IReadOnlyList<Result> results = prediction.GetResults(_classNames);
                    predictedImages.Add(new Bitmap(Annotator.Draw(results, img)));
                }
            }
            bm = predictedImages.FirstOrDefault() ?? new Bitmap(1,1) { Tag = "Predict=0" };
            DirectoryInfo dio = new(outputPath);
            foreach (Bitmap image in predictedImages)
            {
                string imgstr = outputPath + $"\\ML_IMG_{dio.GetFiles().Length+1}.jpg";
                image.Save(imgstr, image.RawFormat);
            }
            //done

        }
    }
}
