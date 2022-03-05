namespace ModSynth.Common
{
    /// <summary>
    /// A frame of PCM audio data.
    /// </summary>
    public class AudioFrame
    {
        public AudioFrame(double theta, int samples, double sampleIncrement)
        {
            Theta = theta;
            Payload = new float[samples];
            SampleIncrement = sampleIncrement;
        }

        /// <summary>
        /// The playback position.
        /// </summary>
        public double Theta { get; }

        public float[] Payload { get; }

        public int Samples => Payload.Length;

        public double SampleIncrement { get; }

        public AudioFrame Clone()
        {
            AudioFrame frame = new AudioFrame(Theta, Samples, SampleIncrement);
            Payload.CopyTo(frame.Payload, 0);
            return frame;
        }
    }
}
