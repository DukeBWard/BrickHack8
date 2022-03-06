using ModSynth.Common;
using ModSynth.Graph;

namespace ModSynth.Rendering
{
    public abstract class AudioRenderer
    {
        public SynthGraph Graph { get; set; }

        protected AudioFrame GenerateFrame(AudioFrame frame)
        {
            Graph.OutputNode.Execute(frame);
            return frame;
        }

        public abstract bool Play();
    }
}
