using ModSynth.Common;
using ModSynth.Graph.Connections.Interfaces;
using ModSynth.Graph.Nodes.Interfaces;
using ModSynth.Graph.Ports.Interfaces;
using System.Collections.Generic;

namespace ModSynth.Graph.Ports
{
    public class OutPort<T> : IPortOut<T>
    {
        public OutPort(INode owner)
        {
            Owner = owner;
            Value = default;
        }

        public INode Owner { get; }

        public List<IConnectionOut<T>> Connection { get; }

        public T Value { get; set; }

        public T Execute(float sample)
        {
            Owner.Execute(sample);
            return Value;
        }
    }
}
