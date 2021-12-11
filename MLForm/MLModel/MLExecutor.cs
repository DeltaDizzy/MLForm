using Microsoft.ML;
using MLtest;
using MLtest.DataModel;
using System.Drawing.Imaging;

namespace MLForm.MLModel
{
    public class MLExecutor
    {
        public static MLProcessData Start(MLProcessData state)
        {
            List<Bitmap> predictedImage;
            Trainer trainer = new(state);
            return SaveImages(trainer.Start());
        }

        public static MLProcessData SaveImages(MLProcessData state)
        {
            state.Image.Save(state.OutputPath + $"\\ML_IMG_{new DirectoryInfo(state.OutputPath).GetFiles().Length + 1}.jpg");
            return state;
        }
    }
}
