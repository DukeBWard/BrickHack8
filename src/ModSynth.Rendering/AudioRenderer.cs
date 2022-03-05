using ModSynth.Common;
using ModSynth.Graph;

namespace ModSynth.Rendering
{
    public class AudioRenderer
    {
        private SynthGraph graph = new SynthGraph();

        protected AudioFrame GenerateFrame(AudioFrame frame)
        {
            graph.OutputNode.Execute(frame);
            return frame;
        }
    }
}
