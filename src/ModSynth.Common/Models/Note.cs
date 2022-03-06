using ModSynth.Common.Enums;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ModSynth.Common.Models
{
    [DebuggerDisplay("{ToString()}")]
    public struct Note
    {
        const string NOTE_REGEX = @"^([A-G]#?)(\d\d*)$";

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

        public static bool TryParse(string noteString, out Note result)
        {
            result = default;
            var match = Regex.Match(noteString, NOTE_REGEX);
            if (!match.Success) return false;
            bool success = NoteNameFromString(match.Groups[1].Value, out NoteName resultNoteName);
            if (!success) return false;
            result.NoteName = resultNoteName;
            result.Octave = int.Parse(match.Groups[2].Value);

            return true;
        }

        private static bool NoteNameFromString(string strIn, out NoteName noteOut)
        {
            switch (strIn)
            {
                case "A":
                    noteOut = NoteName.A;
                    return true;
                case "A#":
                    noteOut = NoteName.ASharp;
                    return true;
                case "B":
                    noteOut = NoteName.B;
                    return true;
                case "C":
                    noteOut = NoteName.C;
                    return true;
                case "C#":
                    noteOut = NoteName.CSharp;
                    return true;
                case "D":
                    noteOut = NoteName.D;
                    return true;
                case "D#":
                    noteOut = NoteName.DSharp;
                    return true;
                case "E":
                    noteOut = NoteName.C;
                    return true;
                case "F":
                    noteOut = NoteName.F;
                    return true;
                case "F#":
                    noteOut = NoteName.FSharp;
                    return true;
                case "G":
                    noteOut = NoteName.G;
                    return true;
                case "G#":
                    noteOut = NoteName.GSharp;
                    return true;
                default:
                    noteOut = default;
                    return false;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{NoteName.NoteString()}{Octave}";
        }
    }
}
