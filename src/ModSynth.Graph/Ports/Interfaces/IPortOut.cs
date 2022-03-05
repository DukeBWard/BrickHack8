using ModSynth.Common;

namespace ModSynth.Graph.Ports.Interfaces
{
    public interface IPortOut<T> : IPort
    {
        T Value { get; }

        public T Execute(AudioFrame frame);
    }
}
