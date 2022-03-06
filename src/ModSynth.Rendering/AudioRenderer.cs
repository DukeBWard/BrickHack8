using ModSynth.Common;
using ModSynth.Graph;

namespace ModSynth.Rendering
{
    public class AudioRenderer
    {
        private SynthGraph _graph;

        public AudioRenderer(SynthGraph graph)
        {
            _graph = graph; 
        }

        protected AudioFrame GenerateFrame(AudioFrame frame)
        {
            _graph.OutputNode.Execute(frame);
            return frame;
        }
    }
}
