using Microsoft.ML;
using MLForm.MLModel;
using MLtest.DataModel;
using MLtest.DataStructures;
using System.Drawing;

namespace MLtest
{
    public class Predictor
    {
        private readonly MLContext _mlContext;
        private readonly PredictionEngine<ImageNetData, ImagePrediction> _predictor;
        private MLProcessData inputState;

        public Predictor(ITransformer trainedModel)
        {
            _mlContext = new MLContext();
            _predictor = _mlContext.Model.CreatePredictionEngine<ImageNetData, ImagePrediction>(trainedModel);
        }

        public Predictor(MLProcessData state)
        {
            _mlContext = new();
            inputState = state;
            _predictor = _mlContext.Model.CreatePredictionEngine<ImageNetData, ImagePrediction>(state.Model);
        }

        public MLProcessData Start()
        {
            DirectoryInfo di = new(inputState.InputPath);
            FileInfo[] images = di.GetFiles("ML_*.*");
            foreach (FileInfo file in images)
            {
                using (Bitmap img = new(Image.FromFile(Path.Combine(inputState.InputPath, file.Name))))
                {
                    ImagePrediction prediction = Predict(img);
                    IReadOnlyList<Result> results = prediction.GetResults(inputState.CategoryNames) ?? new List<Result>();
                    inputState.ProcessedImages.Add(new Bitmap(Annotator.Draw(results, img)));
                }
            }
            return inputState;
        }
        public ImagePrediction Predict(Bitmap image)
        {
            return _predictor.Predict(new ImageNetData()
            {
                Image = image
            });
        }
    }
}
