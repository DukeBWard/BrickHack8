using ModSynth.Common;
using ModSynth.Graph;

namespace ModSynth.Rendering
{
    public abstract class AudioRenderer
    {
        public SynthGraph Graph { get; set; }

        protected AudioFrame GenerateFrame(AudioFrame frame)
        {
            for (int i = 0; i < frame.Payload.Length; i++)
            {
                frame.Payload[i] = Graph.OutputNode.ExecuteOutput((float)(frame.Theta + (i * frame.SampleIncrement)));
            }
            return frame;
        }

        public abstract bool Play();
    }
}
