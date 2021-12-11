using System.Linq;
using Microsoft.ML;
using static Microsoft.ML.Transforms.Image.ImageResizingEstimator;
using System.Collections.Generic;
using MLtest.DataStructures;
using MLForm.MLModel;

namespace MLtest.DataModel
{
    public class Trainer
    {
        private readonly MLContext mlContext;
        private MLProcessData state;
        public Trainer()
        {
            mlContext = new();
        }

        public Trainer(MLProcessData inputState)
        {
            mlContext = new();
            state = inputState;
        }

        public MLProcessData Start()
        {
            state.Model = ApplyModel(state.ModelPath);
            Predictor predictor = new(state);
            return predictor.Start();
        }

        public ITransformer ApplyModel(string modelPath)
        {
            var pipeline = mlContext.Transforms
                .ResizeImages(
                    inputColumnName: "image",
                    outputColumnName: "input_1:0",
                    imageWidth: ImageNetSettings.imageWidth,
                    imageHeight: ImageNetSettings.imageHeight,
                    resizing: ResizingKind.IsoPad)
                .Append(mlContext.Transforms
                    .ExtractPixels(
                        outputColumnName: "input_1:0",
                        scaleImage: 1f / 255f,
                        interleavePixelColors: true))
                .Append(mlContext.Transforms.ApplyOnnxModel(
                    outputColumnNames: new[]
                    {
                        "Identity:0",
                        "Identity_1:0",
                        "Identity_2:0"
                    },
                    inputColumnNames: new[]
                    {
                        "input_1:0"
                    },
                    modelFile: modelPath,
                    shapeDictionary: new Dictionary<string, int[]>()
                    {
                        { "input_1:0", new[] { 1, 416, 416, 3 } },
                        { "Identity:0", new[] { 1, 52, 52, 3, 85 } },
                        { "Identity_1:0", new[] { 1, 26, 26, 3, 85 } },
                        { "Identity_2:0", new[] { 1, 13, 13, 3, 85 } }
                    },
                    gpuDeviceId: null,
                    fallbackToCpu: false
                    ));
            return pipeline.Fit(mlContext.Data.LoadFromEnumerable(new List<ImageNetData>()));
        }
    }
}
