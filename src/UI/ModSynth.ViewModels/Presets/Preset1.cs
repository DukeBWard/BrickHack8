using ModSynth.Graph.Nodes.PCM;
using ModSynth.ViewModels.Presets.Abstract;

namespace ModSynth.ViewModels.Presets
{
    public class Preset1 : Preset
    {
        public Preset1() : base()
        {
            WaveGeneratorNode = new WaveGeneratorNode();
            WaveGeneratorNode.FrequencyInPort.Fallback = 440;
            SynthGraph.CreateOutputConnection(WaveGeneratorNode.WaveOutPort);
        }

        public WaveGeneratorNode WaveGeneratorNode { get; }
    }
}
