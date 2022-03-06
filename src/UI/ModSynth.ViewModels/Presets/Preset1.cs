using ModSynth.Graph.Nodes.PCM;
using ModSynth.ViewModels.Presets.Abstract;

namespace ModSynth.ViewModels.Presets
{
    public class Preset1 : Preset
    {
        public Preset1() : base()
        {
            WaveGeneratorNode wave = new WaveGeneratorNode();
            wave.FrequencyInPort.Fallback = 440;
            SynthGraph.CreateOutputConnection(wave.WaveOutPort);
        }
    }
}
