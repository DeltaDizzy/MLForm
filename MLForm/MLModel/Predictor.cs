using Microsoft.ML;
using MLtest.DataModel;
using MLtest.DataStructures;
using System.Drawing;

namespace MLtest
{
    public class Predictor
    {
        private readonly MLContext _mlContext;
        private readonly PredictionEngine<ImageNetData, ImagePrediction> _predictor;

        public Predictor(ITransformer trainedModel)
        {
            _mlContext = new MLContext();
            _predictor = _mlContext.Model.CreatePredictionEngine<ImageNetData, ImagePrediction>(trainedModel);
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
