using ModSynth.Graph.Nodes.PCM;
using ModSynth.ViewModels.Presets.Abstract;

namespace ModSynth.ViewModels.Presets
{
    public class Preset3 : Preset
    {
        public Preset3() : base()
        {
            WaveGeneratorNode1 = new WaveGeneratorNode();
            WaveGeneratorNode1.FrequencyInPort.Fallback = 5f;
            WaveGeneratorNode2 = new WaveGeneratorNode();
            WaveGeneratorNode2.FrequencyInPort.Fallback = 440;
            CreateConnection(WaveGeneratorNode1.WaveOutPort, WaveGeneratorNode2.FrequencyInPort);
            SynthGraph.CreateOutputConnection(WaveGeneratorNode2.WaveOutPort);
        }

        public WaveGeneratorNode WaveGeneratorNode1 { get; }

        public WaveGeneratorNode WaveGeneratorNode2 { get; }
    }
}
