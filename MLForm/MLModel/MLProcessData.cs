using Microsoft.ML;
using MLtest;
using MLtest.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLForm.MLModel
{
    public struct MLProcessData
    {
        public ITransformer? Model { get; set; }
        public IReadOnlyList<Result>? Results;
        public Bitmap? Image { get; set; }
        public string NextStage { get; set; }
        public string ModelPath { get; set; }
        public string InputPath { get; set; }
        public string OutputPath { get; set; }

        public string[] MLStage = new string[5]
        {
            nameof(Form1),
            nameof(MLExecutor),
            nameof(Trainer),
            nameof(Predictor),
            nameof(Annotator)
        };
    }
}
