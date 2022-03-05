using ModSynth.Common;
using ModSynth.Graph;

namespace ModSynth.Rendering
{
    public class AudioRenderer
    {
        private SynthGraph outputNode = new SynthGraph();

        protected AudioFrame GenerateFrame(AudioFrame frame)
        {
            outputNode.OutputNode.Execute(frame);
            return frame;
        }
    }
}
