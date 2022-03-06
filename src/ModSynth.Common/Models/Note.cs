using ModSynth.Common.Enums;
using System.Diagnostics;

namespace ModSynth.Common.Models
{
    [DebuggerDisplay("{ToString()}")]
    public struct Note
    {
        public Note(NoteName name, int octave)
        {
            NoteName = name;
            Octave = octave;
        }

        public NoteName NoteName { get; set; }

        public int Octave { get; set; }

        /// <summary>
        /// The number of semitones between note <paramref name="a"/> and <paramref name="b"/>.
        /// </summary>
        /// <param name="a">The note to find the distance.</param>
        /// <param name="b">The basis note.</param>
        /// <returns>The number of semitones note <paramref name="a"/> is from note <paramref name="a"/> is.</returns>
        public static int operator -(Note a, Note b)
        {
            int octaveDiff = a.Octave - b.Octave;
            int noteDiff = a.NoteName - b.NoteName;
            return octaveDiff * 12 + noteDiff;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{NoteName.NoteString()}{Octave}";
        }
    }
}
