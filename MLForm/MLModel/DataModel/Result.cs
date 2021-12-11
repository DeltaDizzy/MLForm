namespace MLtest.DataModel
{
    public class Result
    {
        /// <summary>
        /// x1, y1, x2, y2 in page coordinates.
        /// </summary>
        public float[] BoundingBox { get; }

        /// <summary>
        /// The bounding box category
        /// </summary>
        public string Label { get; }

        /// <summary>
        /// Confidence level.
        /// </summary>
        public float Confidence { get; }

        /// <summary>
        /// Bounding Box Color
        /// </summary>
        public Color Color { get; }

        public Result(float[] boundingBox, string label, float confidence)
        {
            BoundingBox = boundingBox;
            Label = label;
            Confidence = confidence;
            Color = Color.Red;
        }
    }
}